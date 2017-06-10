using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DAO;
using Common.Entities;
using Common.Shared;
using System.ComponentModel;

namespace Common.Metier
{
    [DataObject(true)]
    public class UserMetier : AbstractMetier<User>
    {
        private static readonly UserMetier instance = new UserMetier(new UserDAO());

        private UserMetier(AbstractDAO<User> dao) : base(dao)
        {
            InsertGenerator += (Dictionary<string, object> sqlParams) => GenerateInsertUser(sqlParams);
            UpdateGenerator += (Dictionary<string, object> sqlParams) => GenerateUpdateUser(sqlParams); 
        }

        private string GenerateInsertUser(Dictionary<string, object> sqlParams)
        {
            var cols = String.Empty;
            var vals = String.Empty;
            foreach (var p in sqlParams)
            {
                vals += "@" + p.Key + ",";
            }
            vals = vals.TrimEnd(',');
            cols = vals.Replace("@", null);
            return String.Format("INSERT IGNORE INTO {0} ({1}) VALUES ({2})", Constants.BaseJDL.UserTable, cols, vals);
        }

        private string GenerateUpdateUser(Dictionary<string, object> sqlParams)
        {
            var vals = String.Empty;
            foreach (var p in sqlParams)
            {
                vals += p.Key + "=@" + p.Key + ",";
            }
            vals = vals.TrimEnd(',');
            return String.Format("UPDATE IGNORE {0} SET {1} WHERE Id=@Id", Constants.BaseJDL.UserTable, vals);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static User GetUser(string login, string mdp)
        {
            var sqlParams = new Dictionary<string, object>(2)
            {
                {"Login", login },
                {"Pass", mdp },
            };
            return instance.Dao.GetObject(sqlParams, Queries.Select_User_ByLoginPass);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static User GetUser(int IdUser)
        {
            var sqlParams = new Dictionary<string, object>(1) {{"Id", IdUser } };
            return instance.Dao.GetObject(sqlParams, Queries.Select_User_ById);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static User GetUser(string login)
        {
            var sqlParams = new Dictionary<string, object>(1) { { "Login", login } };
            return instance.Dao.GetObject(sqlParams, Queries.Select_User_ByLogin);
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static int InsertUser(Dictionary<string, object> sqlParams)
        {
            var query = instance.InsertGenerator(sqlParams);
            return (sqlParams.Count > 0) ? instance.Dao.InsertObject(sqlParams, query) : 0;
        }


        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static int DeleteUser(int Id)
        {
            var sqlParams = new Dictionary<string, object>(1) { { "Id", Id } };
            return instance.Dao.UpdateDeleteObject(sqlParams, Queries.Delete_User);
        }

        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public static int UpdateUser(Dictionary<string, object> sqlParams)
        {
            var query = instance.UpdateGenerator(sqlParams);
            return (sqlParams.Count > 0) ? instance.Dao.UpdateDeleteObject(sqlParams, query) : 0;
        }
    }
}

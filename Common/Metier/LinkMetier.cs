using Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.DAO;
using Common.Shared;
using System.ComponentModel;

namespace Common.Metier
{
    [DataObject(true)]
    public class LinkMetier : AbstractMetier<Link>
    {
        private static readonly LinkMetier instance = new LinkMetier(new LinkDAO());

        private LinkMetier(AbstractDAO<Link> daoInstance) : base(daoInstance)
        {
            InsertGenerator = (Dictionary<string, object> sqlParams) => GenerateInsertLink(sqlParams);
        }

        private string GenerateInsertLink(Dictionary<string, object> sqlParams)
        {
            var cols = String.Empty;
            var vals = String.Empty;
            foreach (var p in sqlParams)
            {
                vals += "@" + p.Key + ",";
            }
            vals = vals.TrimEnd(',');
            cols = vals.Replace("@", null);
            return String.Format("INSERT IGNORE INTO {0} ({1}) VALUES ({2})", Constants.BaseJDL.LinkTable, cols, vals);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static Link GetLink(string Url, int IdUser)
        {
            var sqlParams = new Dictionary<string, object>(2) { { "IdUser", IdUser }, { "Url", Url } };
            return instance.Dao.GetObject(sqlParams, Queries.Select_Link);
        }

        [DataObjectMethod (DataObjectMethodType.Select, true)]
        public static List<Link> GetLinks(int IdUser)
        {
            var sqlParams = new Dictionary<string, object>(1) { { "IdUser", IdUser } };
            return instance.Dao.GetObjects(sqlParams, Queries.Select_ListLinkUser);
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static int InsertOrUpdateLink(Dictionary<string, object> sqlParams)
        {
            return instance.Dao.InsertOrUpdateObject(sqlParams, "Id", Constants.BaseJDL.LinkTable.Name, "Url=@Url AND IdUser=@IdUser");
        }

        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public static int InsertLink(Dictionary<string, object> sqlParams)
        {
            var query = instance.InsertGenerator(sqlParams);
            return instance.Dao.InsertObject(sqlParams, query);
        }

        [DataObjectMethod(DataObjectMethodType.Update, true)]
        public static int DeleteLink(int IdLink)
        {
            var sqlParams = new Dictionary<string, object>(1) { { "Id", IdLink } };
            return instance.Dao.UpdateDeleteObject(sqlParams, Queries.Delete_Link);
        }

    }
}

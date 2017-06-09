using Common.Entities;
using System;
using System.Data.Common;

namespace Common.DAO
{
    public class UserDAO : AbstractDAO<User>
    {
        public UserDAO()
        {
            this.resultReader = (DbDataReader r) => GetUserData(r);
        }

        private User GetUserData(DbDataReader r)
        {
            var user = new User();
            user.Id = r["Id"] != DBNull.Value ? Convert.ToInt32(r["Id"]) : 0;
            user.IdType = r["IdType"] != DBNull.Value ? Convert.ToInt32(r["IdType"]) : 0;
            user.Nom = r["Nom"] != DBNull.Value ? r["Nom"].ToString() : String.Empty;
            user.Prenom = r["Prenom"] != DBNull.Value ? r["Prenom"].ToString() : String.Empty;
            user.Pass = r["Pass"] != DBNull.Value ? r["Pass"].ToString() : String.Empty;
            user.Login = r["Login"] != DBNull.Value ? r["Login"].ToString() : String.Empty;
            user.DateRegister = r["DateRegister"] != DBNull.Value ? Convert.ToDateTime(r["DateRegister"]) : DateTime.MinValue;
            user.UserType.Id = user.IdType;
            user.UserType.NameStr = r["NameStr"].ToString();
            return user;
        }

    }
}

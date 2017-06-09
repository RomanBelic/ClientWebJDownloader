using Common.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DAO
{
    public class UserTypeDAO : AbstractDAO<UserType>
    {

        public UserTypeDAO()
        {
            this.resultReader = (DbDataReader r) => GetUserTypeData(r);
        }

        private UserType GetUserTypeData(DbDataReader r)
        {
            return new UserType()
            {
                Id = r["Id"] != DBNull.Value ? Convert.ToInt32(r["Id"]) : 0,
                NameStr = r["NameStr"].ToString(),
            };
        }

    }
}

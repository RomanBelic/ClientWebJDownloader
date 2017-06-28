using Common.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DAO
{
    public class LinkDAO : AbstractDAO<Link>
    {
        public LinkDAO()
        {
            this.resultReader = (DbDataReader r) => GetLinkData(r);
        }

        private Link GetLinkData(DbDataReader r)
        {
            return new Link()
            {
                Id = r["Id"] != DBNull.Value ? Convert.ToInt32(r["Id"]) : 0,
                IdUser = r["IdUser"] != DBNull.Value ? Convert.ToInt32(r["IdUser"]) : 0,
                Url = r["Url"] != DBNull.Value ? r["Url"].ToString() : String.Empty,
                DateCreated = r["DateCreated"] != DBNull.Value ? Convert.ToDateTime(r["DateCreated"]) : DateTime.MinValue,
                Name = r["Name"] != DBNull.Value ? r["Name"].ToString() : String.Empty,
            };
        }
    }
}

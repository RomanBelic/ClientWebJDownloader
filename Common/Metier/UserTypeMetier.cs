using Common.DAO;
using Common.Entities;
using Common.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Metier
{
    [DataObject(true)]
    public class UserTypeMetier : AbstractMetier<UserType>
    {
        private static readonly UserTypeMetier instance = new UserTypeMetier(new UserTypeDAO());

        public UserTypeMetier(AbstractDAO<UserType> dao) : base(dao)
        {
            
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static List<UserType> GetUserTypes()
        {
            return instance.Dao.GetObjects(new Dictionary<string, object>(), Queries.Select_ListUserType);
        }

        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public static UserType GetUserType(int IdType)
        {
            var sqlParam = new Dictionary<string, object>(1)
            {
                {"Id", IdType}
            };
            return instance.Dao.GetObject(sqlParam, Queries.Select_ListUserType);
        }
    }
}

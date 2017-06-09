using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Shared
{
    public class Constants
    {
        public enum UserTypeId { Free = 1, Premium = 2, Admin = 3 };

        public static readonly string UserKey = "current_logged_user";
        public static readonly string SessionKey = "current_session_id";
        public static readonly string UserIdKey = "current_logged_id";

        private static JDLBase baseJDL;
        public static JDLBase BaseJDL { get => baseJDL; }

        public static void Init()
        {
            var dbName = (ConfigurationManager.AppSettings["DataBase"] != null) ? ConfigurationManager.AppSettings["DataBase"].ToString() : "jdownloader";
            var user = (ConfigurationManager.AppSettings["usertable"] != null) ? ConfigurationManager.AppSettings["usertable"].ToString() : "user";
            var usertype = (ConfigurationManager.AppSettings["usertypetable"] != null) ? ConfigurationManager.AppSettings["usertypetable"].ToString() : "usertype";
            var link = (ConfigurationManager.AppSettings["linktable"] != null) ? ConfigurationManager.AppSettings["linktable"].ToString() : "link";
            baseJDL = new JDLBase(dbName);
            baseJDL.LinkTable = new DataTable(baseJDL + "." + link);
            baseJDL.UserTable = new DataTable(baseJDL + "." + user);
            baseJDL.UserTypeTable = new DataTable(baseJDL + "." + usertype);
        }
    }

    public class DataBase
    {
        private string name;
        public string Name { get => name; set => name = value; }

        public DataBase(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }

    }

    public class JDLBase : DataBase
    {
        public JDLBase(string name) : base(name)
        {
        }

        private DataTable userTable;
        public DataTable UserTable { get => userTable; set => userTable = value; }
       
        private DataTable userTypeTable;
        public DataTable UserTypeTable { get => userTypeTable; set => userTypeTable = value; }
        
        private DataTable linkTable;
        public DataTable LinkTable { get => linkTable; set => linkTable = value; }

    }

    public class DataTable
    {
        private string name;
        public string Name { get => name; set => name = value; }

        public DataTable(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }
    }
}

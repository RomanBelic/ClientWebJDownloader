using System;
using System.Data.Common;
using System.Configuration;

namespace Common.Connection
{
    public class SqlAdapter
    {
        private static IConnection connection;
        public static string LastInsertIdSelector = String.Empty;

        protected SqlAdapter()
        {

        }

        public static void Init()
        { 
            var driver = ConfigurationManager.AppSettings["DbDriver"].ToString();
            switch (driver)
            {
                case "MySql":
                    var cnString = ConfigurationManager.ConnectionStrings["MySqlConnection"].ConnectionString;
                    LastInsertIdSelector = ";SELECT LAST_INSERT_ID();";
                    connection = new MySqlAdapter(cnString);
                    break;
                default: throw new NotImplementedException("Unsupported driver");
            }
        }

        public static DbConnection GetNewConnection()
        {
            if (connection == null)
                 Init();
            return connection.OpenNewConnection();
        }
    }
}

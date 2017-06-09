using MySql.Data.MySqlClient;
using System;
using System.Data.Common;
using System.Linq;

namespace Common.Connection
{
    public class MySqlAdapter : IConnection
    {
        private string cnString;
        public string CnString { get => cnString; set => cnString = value; }

        public MySqlAdapter(string cnString)
        {
            this.cnString = cnString;
        }

        public DbConnection OpenNewConnection()
        {
            var connection = new MySqlConnection(this.cnString);
            connection.InfoMessage += (sender, arg) =>
            {
                var msg = (arg.errors.Length > 0) ? arg.errors.Select(e => new { Error = "Error : " + e.Code + " " + e.Message }).
                                                    Select(e => e.Error).Aggregate((x, y) => x + Environment.NewLine + y)
                                                    : String.Empty;
                System.Diagnostics.Debug.WriteLine(msg);
            };
            connection.Open();
            return connection;
        }
    }
}

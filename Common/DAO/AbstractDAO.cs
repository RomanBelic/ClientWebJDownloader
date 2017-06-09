using System;
using System.Collections.Generic;
using Common.Connection;
using Common.Entities;
using System.Data.Common;

namespace Common.DAO
{
    public delegate T ReaderDelegate<T>(DbDataReader reader);

    public abstract class AbstractDAO<T> where T : DefaultEntity, new()
    {
        protected ReaderDelegate<T> resultReader = (r) => new T();

        public virtual T GetObject(Dictionary<string, object> sqlParams, string query)
        {
            T obj = new T();
            using (var cn = SqlAdapter.GetNewConnection())
            {
                var cmd = cn.CreateCommand();
                cmd.CommandText = query;

                foreach (var p in sqlParams)
                {
                    cmd.Parameters.Add(CreateSQLParam(cmd, "@" + p.Key, p.Value));
                }

                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        obj = resultReader(r);
                    }
                }
            }

            return obj;
        }

        public virtual List<T> GetObjects(Dictionary<string, object> sqlParams, string query)
        {
            List<T> lstObj = new List<T>(64);
            using (var cn = SqlAdapter.GetNewConnection())
            {
                var cmd = cn.CreateCommand();
                cmd.CommandText = query;

                foreach (var p in sqlParams)
                {
                    cmd.Parameters.Add(CreateSQLParam(cmd, "@" + p.Key, p.Value));
                }

                using (var r = cmd.ExecuteReader())
                {
                    T obj;
                    while (r.Read())
                    {
                        obj = resultReader(r);
                        lstObj.Add(obj);
                    }
                }
            }

            return lstObj;
        }

        public virtual int UpdateDeleteObject(Dictionary<string, object> sqlParams, string query)
        {
            int row = -1;
            using (var cn = SqlAdapter.GetNewConnection())
            {
                var cmd = cn.CreateCommand();
                cmd.CommandText = query;

                foreach (var p in sqlParams)
                {
                    cmd.Parameters.Add(CreateSQLParam(cmd, "@" + p.Key, p.Value));
                }

                row = cmd.ExecuteNonQuery();
            }

            return row;
        }

        public virtual int InsertObject(Dictionary<string, object> sqlParams, string query)
        {
            int id = -1;
            using (var cn = SqlAdapter.GetNewConnection())
            {
                var cmd = cn.CreateCommand();
                cmd.Transaction = cn.BeginTransaction(System.Data.IsolationLevel.Serializable);
                cmd.CommandText = query + SqlAdapter.LastInsertIdSelector;

                foreach (var p in sqlParams)
                {
                    cmd.Parameters.Add(CreateSQLParam(cmd, "@" + p.Key, p.Value));
                }

                var result = cmd.ExecuteScalar();
                cmd.Transaction.Commit();
                id = (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : 0;
            }
            return id;
        }


        public virtual int InsertOrUpdateObject(Dictionary<string,object> sqlParams, string key, string databaseTable, string condition)
        {
            var cols = String.Empty;
            var vals = String.Empty;
            var updvals = String.Empty;
            int rows = -1;

            using (var cn = SqlAdapter.GetNewConnection())
            {
                var cmd = cn.CreateCommand();

                foreach (var p in sqlParams)
                {
                    cmd.Parameters.Add(CreateSQLParam(cmd, "@" + p.Key, p.Value));
                    vals += "@" + p.Key + ",";
                    updvals += p.Key + "=@" + p.Key + ",";
                }

                vals = vals.TrimEnd(',');
                updvals = updvals.TrimEnd(',');
                cols = vals.Replace("@", null);

                cmd.CommandText = "SELECT " + key + " FROM " + databaseTable + @" WHERE 1=1 AND " + condition;
                var result = cmd.ExecuteScalar();
                cmd.CommandText = (result == null || result == DBNull.Value) ? "INSERT INTO " + databaseTable + "(" + cols + ") VALUES(" + vals + ")" + SqlAdapter.LastInsertIdSelector
                                                                             : "UPDATE " + databaseTable + " SET " + updvals + " WHERE 1=1 AND " + condition + "; SELECT 1;";

                result = cmd.ExecuteScalar();
                rows = (result != null && result != DBNull.Value) ? Convert.ToInt32(result) : 0;
            }

            return rows;
        }

        protected DbParameter CreateSQLParam(DbCommand cmd, string name, object value)
        {
            DbParameter param = cmd.CreateParameter();
            param.ParameterName = name;
            param.Value = value ?? DBNull.Value;
            if (value.GetType() == typeof(string))
                param.DbType = System.Data.DbType.String;
            if (value.GetType() == typeof(Int32))
                param.DbType = System.Data.DbType.Int32;
            if (value.GetType() == typeof(Int64))
                param.DbType = System.Data.DbType.Int64;
            if (value.GetType() == typeof(Int16))
                param.DbType = System.Data.DbType.Int16;
            if (value.GetType() == typeof(double))
                param.DbType = System.Data.DbType.Double;
            if (value.GetType() == typeof(float))
                param.DbType = System.Data.DbType.Double;
            if (value.GetType() == typeof(DateTime))
                param.DbType = System.Data.DbType.DateTime;
            if (value.GetType() == typeof(char))
                param.DbType = System.Data.DbType.String;
            if (value.GetType() == typeof(object))
                param.DbType = System.Data.DbType.Object;
            return param;
        }
    }
}

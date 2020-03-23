using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;


namespace _350Project.DataAccess
{
    public class SqlAccess
    {
        public static String GetConnectionString(string connectionName = "350ProjectDatabase") {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        public static List<T> LoadData<T>(string sql) {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString())) {
                return cnn.Query<T>(sql).ToList();
            }
        }

        public static int SaveData<T>(string sql, T data) {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql,data);
            }
        }
    }
}
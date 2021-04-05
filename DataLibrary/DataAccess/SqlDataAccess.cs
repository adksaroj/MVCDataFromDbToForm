using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace DataLibrary.DataAccess
{
    public static class SqlDataAccess
    {
        public static string GetConnectionString(string name = "MVCAppDB")
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public static List<T> LoadData<T>(string sql)
        {
            using (IDbConnection dbConnection = new SqlConnection(GetConnectionString()))
            {
                return dbConnection.Query<T>(sql).ToList();
            }
        }

        public static int SaveData<T>(string sql, T data) //T is the data to be saved
        {
            using (IDbConnection dbConnection = new SqlConnection(GetConnectionString()))
            {
                return dbConnection.Execute(sql,data);
            }
        }
    }
}

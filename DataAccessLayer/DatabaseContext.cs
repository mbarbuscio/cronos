using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DatabaseContext
    {
        public string ConnectionString { get; set; }

        public DatabaseContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}

using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gym_Application {
    public static class Database {

        private static readonly string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

        public static SqlConnection GetConnection() {
            return new SqlConnection(connectionString);
        }
    }
}

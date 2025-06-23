using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Gym_Application {
    public static class Database {

        private static readonly string connectionString =
            @"Data Source=195.159.227.100,5555;Initial Catalog=Kunstsilo_12122024;User ID=erpbo;Password=erpbo";


        public static SqlConnection GetConnection() {
            return new SqlConnection(connectionString);
        }
    }
}

//< add key = "ConnectionString" value = "server=195.159.227.100, 5555;Database=Kunstsilo_12122024;uid=erpbo;pwd=erpbo;Max Pool Size=1000;Connect Timeout=200;" />
﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wypozyczalnia.Database
{
    public class DatabaseConnection
    {
        public SqlConnection Connection { get; set; }
        public string ServerName { get; set; }
        public string DatabaseName { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }

        private string connectionString;

        public DatabaseConnection()
        {
            this.ServerName = ConfigurationManager.AppSettings["server"];//"HANIA-LAPTOP\\SQLEXPRESS";
            this.DatabaseName = ConfigurationManager.AppSettings["database"];//"Test2";
            this.UserId = ConfigurationManager.AppSettings["user"];//"sa";
            this.Password = ConfigurationManager.AppSettings["password"];//"Admin1";
            CreateConnectionString();
            Connection = new SqlConnection(connectionString);
        }

        public DatabaseConnection(string serverName, string databaseName, string userId, string password)
        {
            this.ServerName = serverName;
            this.DatabaseName = databaseName;
            this.UserId = userId;
            this.Password = password;
            CreateConnectionString();
            Connection = new SqlConnection(connectionString);
        }

        private void CreateConnectionString()
        {
            connectionString = "Server=" + ServerName + ";" +
                            "Database=" + DatabaseName + ";" +
                            "User Id=" + UserId + ";" +
                            "Password=" + Password + ";";
        }

        public void OpenConnection()
        {
            Connection.Open();
        }

        public void CloseConnection()
        {
            Connection.Close();
        }

        public void ExecuteQuery(SqlCommand command)
        {
            command.Connection = Connection;
            command.ExecuteNonQuery();
        }

        public SqlDataReader ExecuteQueryReader(SqlCommand command)
        {
            SqlDataReader myReader = null;
            command.Connection = Connection;
            myReader = command.ExecuteReader();
            return myReader;
        }

    }
}

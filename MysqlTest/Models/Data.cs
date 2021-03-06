﻿using MySql.Data;
using MySql.Data.MySqlClient;

namespace MysqlTest
{
    public class DBConnection
    {
        private DBConnection()
        {
        }

        private string databaseName = string.Empty;
        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }

        //public string Password { get; set; }
        private MySqlConnection connection = null;
        public MySqlConnection Connection
        {
            get { return connection; }
        }

        private static DBConnection _instance = null;
        public static DBConnection Instance()
        {
            if (_instance == null)
                _instance = new DBConnection();
            return _instance;
        }

        public bool IsConnect()
        {
            if (Connection == null)
            {
                if (string.IsNullOrEmpty(DatabaseName))
                    return false;
                string connstring = string.Format("Server=66.17.110.23 ;Port =3360; database={0}; UID=root; password=asd123", databaseName);
                connection = new MySqlConnection(connstring);
            }

            return true;
        }
        public bool Open(){
            connection.Open();
            return true;
        }

        public void Close()
        {
            connection.Close();
        }
    }
}

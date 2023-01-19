using MySql.Data.MySqlClient;
using ViewModel;
using System.Text.Json;
using System;

namespace Model
{

    public class UserLogin
    {
        public string Host { get; set; }
        public string Database { get; set; }
        public string LogTable{ get; set; }
        public string UserTable { get; set; }
        public string Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
    class SQLDatabase
    {
        public static string Database = "huberteats";
        public static string LogTable = "LogTable";
        public static string UserTable = "InternalUserTable";
        public static MySqlConnection GetDatabaseDBConnection()
        {
            string json = System.IO.File.ReadAllText("../../../Settings.json");
            UserLogin QueryInfo = JsonSerializer.Deserialize<UserLogin>(json);
            string host = QueryInfo.Host;
            string port = QueryInfo.Port;
            string database = QueryInfo.Database;
            string username = QueryInfo.Username;
            string password = EncryptClass.DecodeFrom64(QueryInfo.Password);
            // Hash and verify password using a secure library
            // Limit the database user's privileges
            string connString = $"Server={host};Database={database};port={port};User Id={username};password={password}";
            MySqlConnection conn = new(connString);
            return conn;
        }
        public static MySqlConnection GetMysqlDbConnection()
        {
            string json = System.IO.File.ReadAllText("../../../Settings.json");
            UserLogin QueryInfo = JsonSerializer.Deserialize<UserLogin>(json);
            string host = QueryInfo.Host;
            string port = QueryInfo.Port;
            string username = QueryInfo.Username;
            string password = EncryptClass.DecodeFrom64(QueryInfo.Password);
            // Hash and verify password using a secure library
            // Limit the database user's privileges
            string connString = $"Server={host};port={port};User Id={username};password={password}";
            MySqlConnection conn = new(connString);
            return conn;
        }
        public static MySqlConnection GetLogDBConnection()
        {
            string json = System.IO.File.ReadAllText("../../../Settings.json");
            UserLogin QueryInfo = JsonSerializer.Deserialize<UserLogin>(json);
            string host = QueryInfo.Host;
            string port = QueryInfo.Port;
            string database = QueryInfo.Database;
            string username = QueryInfo.Username;
            string password = EncryptClass.DecodeFrom64(QueryInfo.Password);
            // Hash and verify password using a secure library
            // Limit the database user's privileges
            string connString = $"Server={host};Database={database};port={port};User Id={username};password={password}";
            MySqlConnection conn = new(connString);
            return conn;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ViewModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Model
{   public class UserLogin
    {
        public string username { get; set; }
        public string password { get; set; }
    }
    class SQLDatabase
    {
        public static string Host { get; } = "localhost";
        public static int Port { get; } = 3306;
        public static string Database { get; } = "internalprofiles";
        public static string UserTable { get; } = "InternalUserTable";

        public static MySqlConnection GetDBConnection()
        {
            EncryptClass decryptpasswod = new();
            string JSONFile = System.IO.File.ReadAllText("C:/Users/Seb/Documents/GitHub/Hubert-eats/UserEatsManager/Settings.json");
            UserLogin test = JsonSerializer.Deserialize<UserLogin>(JSONFile);
            string connString = "Server=" + Host + ";Database=" + Database
                + ";port=" + Port + ";User Id=" + test.username + ";password=" + decryptpasswod.DecodeFrom64(test.password);
            MySqlConnection conn = new(connString);
            return conn;
        }
    }
}
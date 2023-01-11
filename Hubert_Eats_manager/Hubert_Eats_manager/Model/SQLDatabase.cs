using MySql.Data.MySqlClient;
using ViewModel;
using System.Text.Json;

namespace Model
{
    public class UserLogin
    {
        public string username { get; set; }
        public string password { get; set; }
    }
    class SQLDatabase
    {
        public static string Host { get; } = "db4free.net";
        public static int Port { get; } = 3306;
        public static string Database { get; } = "huberteats";
        public static string UserTable { get; } = "InternalUserTable";
        public static string LogTable { get; } = "InternalLogTable";

        public static MySqlConnection GetDBConnection()
        {
            EncryptClass decryptpasswod = new();
            string JSONFile = System.IO.File.ReadAllText("../../../Settings.json");
            UserLogin test = JsonSerializer.Deserialize<UserLogin>(JSONFile);
            string connString = "Server=" + Host + ";Database=" + Database
                + ";port=" + Port + ";User Id=" + test.username + ";password=" + decryptpasswod.DecodeFrom64(test.password);
            MySqlConnection conn = new(connString);
            return conn;
        }
    }
}
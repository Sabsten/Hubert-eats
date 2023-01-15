using MaterialDesignThemes.Wpf;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Windows.Markup;
using static ViewModel.DataBaseManagerClass;

namespace Model
{
    class SQLCommands
    {
        public static MySqlCommand FindUser(Dictionary<string, string> UserData)
        {
            MySqlCommand cmd = DataBaseConnection.CreateCommand();
            foreach (var item in UserData)
            {
                cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
            }
            cmd.CommandText = "SELECT * FROM " + SQLDatabase.UserTable + " WHERE identifiant = @identifiant";
            return cmd;
        }

        public static string FindUserSQLString(Dictionary<string, string> UserData)
        {
            return "SELECT * FROM " + SQLDatabase.UserTable + " WHERE identifiant = " + UserData["identifiant"];
        }
        public static MySqlCommand FindHashedPassword(Dictionary<string, string> UserData)
        {
            MySqlCommand cmd = DataBaseConnection.CreateCommand();
            foreach (var item in UserData)
            {
                cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
            }
            cmd.CommandText = "SELECT password FROM " + SQLDatabase.UserTable + " WHERE identifiant = @identifiant";
            return cmd;
        }

        public static string FindHashedPasswordSQLString(Dictionary<string, string> UserData)
        {
            return "SELECT password FROM " + SQLDatabase.UserTable + " WHERE identifiant = " + UserData["identifiant"];
        }

        public static MySqlCommand UpdateTable(Dictionary<string, string> UserData)
        {
            MySqlCommand cmd = DataBaseConnection.CreateCommand();
            foreach (var item in UserData)
            {
                cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
            }
            cmd.CommandText = "UPDATE " + SQLDatabase.UserTable + " SET @Key = @Value WHERE identifiant = @identifiant";
            return cmd;
        }

        public static string UpdateTableSqlString(Dictionary<string, string> UserData)
        {
            return "UPDATE " + SQLDatabase.UserTable + " SET " + UserData["Key"] + " = " + UserData["Value"] + " WHERE identifiant = " + UserData["Identifiant"];
        }


        public static MySqlCommand AllData()
        {
            MySqlCommand cmd = DataBaseConnection.CreateCommand();
            cmd.CommandText = "SELECT * FROM " + SQLDatabase.UserTable;
            return cmd;
        }
        public static string AllDataSQLString()
        {
            return "SELECT * FROM " + SQLDatabase.UserTable;
        }

        public static MySqlCommand AllLogDataSQLString()
        {
            MySqlCommand cmd = DataBaseConnection.CreateCommand();
            cmd.CommandText = "SELECT * FROM " + SQLDatabase.LogTable;
            return cmd;
        }



        public static MySqlCommand DeleteUser(Dictionary<string, string> UserData)
        {
            MySqlCommand cmd = DataBaseConnection.CreateCommand();
            foreach (var item in UserData)
            {
                cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
            }
            cmd.CommandText = "UPDATE " + SQLDatabase.UserTable + " SET isActive = FALSE WHERE identifiant = @identifiant";
            return cmd;
        }

        public static string DeleteUserSQLString(Dictionary<string, string> UserData)
        {
            return "DELETE FROM " + SQLDatabase.UserTable + " WHERE identifiant = " + UserData["identifiant"];
        }

        public static MySqlCommand FillTable(Dictionary<string, string> UserData)
        {
            MySqlCommand cmd = DataBaseConnection.CreateCommand();
            string sqlLine1 = "INSERT INTO " + SQLDatabase.UserTable + "(";
            string sqlLine2 = " VALUE (";
            foreach (var item in UserData)
            {
                if (item.Key == "Password" || item.Key == "password")
                {
                    cmd.Parameters.AddWithValue("@" + item.Key, EncryptClass.HashPassword(item.Value));
                }
                else if (item.Key == "role")
                {
                    if (!int.TryParse(item.Value, out int numValue))
                    {
                        cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
                    }
                    else
                    {
                        var role = (Role)int.Parse(numValue.ToString());
                        cmd.Parameters.AddWithValue("@" + item.Key, role.ToString());
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
                }
                sqlLine1 = sqlLine1 + item.Key + ", ";
                sqlLine2 = sqlLine2 + "@" + item.Key + ", ";
            }
            cmd.CommandText = sqlLine1[..^2] + ')' + sqlLine2[..^2] + ')';
            return cmd;
        }


        public static MySqlCommand Log_FillTable(Dictionary<string, string> UserData)
        {
            MySqlCommand cmd = DataBaseConnection.CreateCommand();
            string sqlLine1 = "INSERT INTO " + SQLDatabase.LogTable + " (";
            string sqlLine2 = " VALUE (";
            foreach (var item in UserData)
            {
                cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
                sqlLine1 = sqlLine1  + item.Key +", ";
                sqlLine2 = sqlLine2 + "@" + item.Key + ", ";
            }
            cmd.CommandText = sqlLine1[..^2] + ')' + sqlLine2[..^2] + ')';
            return cmd;
        }

        public static string FillTableSQLCommand(Dictionary<string, string> UserData)
        {
            MySqlCommand cmd = DataBaseConnection.CreateCommand();
            string sqlLine1 = "INSERT INTO " + SQLDatabase.UserTable + " (";
            string sqlLine2 = " VALUE (";
            foreach (var item in UserData)
            {
                sqlLine1 = sqlLine1 + item.Key + ", ";
                sqlLine2 = sqlLine2 + "'" + item.Value + "', ";
            }
            return sqlLine1[..^2] + ')' + sqlLine2[..^2] + ')';
        }
    }
}
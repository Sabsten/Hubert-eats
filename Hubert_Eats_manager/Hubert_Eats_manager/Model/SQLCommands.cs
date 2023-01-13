using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Text;
using System.Windows.Markup;
using static ViewModel.DataBaseManagerClass;

namespace Model
{
    class SQLCommands
    {
        public static MySqlCommand FindUserSQLString(Dictionary<string,string> UserData)
        {
            MySqlCommand cmd = DataBaseConnection.CreateCommand();
            foreach (var item in UserData)
            {
                cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
            }
            cmd.CommandText = "SELECT * FROM " + SQLDatabase.UserTable + " WHERE identifiant = @identifiant";
            return cmd;
        }
        public static MySqlCommand FindHashedPasswordSQLString(Dictionary<string, string> UserData)
        {
            MySqlCommand cmd = DataBaseConnection.CreateCommand();
            foreach (var item in UserData)
            {
                cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
            }
            cmd.CommandText = "SELECT password FROM " + SQLDatabase.UserTable + " WHERE identifiant = @identifiant";
            return cmd;
        }
        public static MySqlCommand UpdateTableSqlString(Dictionary<string, string> UserData)
        {
            MySqlCommand cmd = DataBaseConnection.CreateCommand();
            foreach (var item in UserData)
            {
                cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
            }
            cmd.CommandText = "UPDATE " + SQLDatabase.UserTable + " SET @Key = @Value WHERE identifiant = @identifiant";
            return cmd;
        }

        public static MySqlCommand AllDataSQLString()
        {
            MySqlCommand cmd = DataBaseConnection.CreateCommand();
            cmd.CommandText = "SELECT * FROM " + SQLDatabase.UserTable;
            return cmd;
        }

        public static MySqlCommand DeleteUserSQLString(Dictionary<string, string> UserData)
        {
            MySqlCommand cmd = DataBaseConnection.CreateCommand();
            foreach (var item in UserData)
            {
                cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
            }
            cmd.CommandText = "DELETE FROM " + SQLDatabase.UserTable + " WHERE identifiant = @identifiant";
            return cmd;
        }


        public static MySqlCommand FillTableSQLCommand(Dictionary<string, string> UserData)
        {
            MySqlCommand cmd = DataBaseConnection.CreateCommand();
            string sqlLine1 = "INSERT INTO " + SQLDatabase.UserTable + "(";
            string sqlLine2 = " VALUE (";
            foreach (var item in UserData)
            {
                if (item.Key == "Password")
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
                sqlLine1 = sqlLine1 + ("@"+item.Value, item.Key);
                sqlLine2 = sqlLine2 + ("@" + item.Value, item.Key);
            }
            sqlLine1.Substring(sqlLine1.Length - 2, 2);
            sqlLine2.Substring(sqlLine2.Length - 2, 2);
            sqlLine1 = sqlLine1 + ')';
            sqlLine2 = sqlLine2 +')';
            cmd.CommandText = sqlLine1 + sqlLine2;
            return cmd;
        }
    }

}
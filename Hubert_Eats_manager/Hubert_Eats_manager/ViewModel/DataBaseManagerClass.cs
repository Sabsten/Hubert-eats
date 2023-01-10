using System;
using System.Collections.Generic;
using Model;
using MySql.Data.MySqlClient;

namespace ViewModel
{
    class DataBaseManagerClass
    {
        public enum Role
        {
            Commercial,
            Developpeur,
            Technique,
            BddManager
        }
        public static MySqlConnection DataBaseConnection = SQLDatabase.GetDBConnection();
        public Tuple<bool, string> AddUser(Dictionary<string, string> UserInfo)
        {
            if (IsUserExists(UserInfo["Identifiant"]))
                return (false, "Existing User").ToTuple();
            else
            {
                FillTable(UserInfo);
                return (true, "L'utilisateur a bien été ajouté dans la base de donnée.").ToTuple();
            }
        }
        public Tuple<bool, string> ModifyUser(string modifiedparameter, int NumberSelected, List<List<string>> Data, string identifiant, string ModifiedBy)
        {
            ExecuteSQLCommand(SQLCommands.UpdateTableSqlString(Data[0][NumberSelected], modifiedparameter, identifiant));
            ExecuteSQLCommand(SQLCommands.UpdateTableSqlString(Data[0][8], ModifiedBy, identifiant));
            return (true, "Modification effectuée " + identifiant).ToTuple();
        }

        public Tuple<bool, string> DeleteUser(string identifiant)
        {
            ExecuteSQLCommand("delete from " + SQLDatabase.UserTable + " where Identifiant ='" + identifiant + "'");
            if (IsUserExists(identifiant) == false)
            {
                return (true, "l'utilisateur " + identifiant + " a été supprimé").ToTuple();
            }
            else
            {
                return (true, "l'utilisateur n'a pas pu être supprimé").ToTuple();
            }
        }

        public List<List<string>> FindUser(string identifiant)
        {
            MySqlDataReader readerID = GetReaderSQLCommand(SQLCommands.FindUserSQLString(identifiant));
            List<List<string>> UserInfos = new();
            int i = 0;
            while (readerID.Read())
            {
                List<string> User = new();
                while (i != readerID.FieldCount)
                {
                    if (!readerID.IsDBNull(i))
                    {
                        User.Add(readerID.GetString(i).ToString());
                    }
                    else
                    {
                        User.Add("");
                    }
                    i++;
                }
                i = 0;
                UserInfos.Add(User);
            }
            return UserInfos;
        }
        public static List<List<ExtractDatabase>> AllData()
        {
            DataBaseConnection.Open();
            MySqlDataReader readerID = GetReaderSQLCommand(SQLCommands.AllDataSQLString());
            List<List<ExtractDatabase>> UserInfos = new();
            int i = 0;
            while (readerID.Read())
            {
                List<ExtractDatabase> User = new();
                ExtractDatabase UserTest = new();
                if (!readerID.IsDBNull(1)) { UserTest.idInternalUser = readerID.GetString(0).ToString(); } else { UserTest.idInternalUser = ""; };
                if (!readerID.IsDBNull(2)) { UserTest.identifiant = readerID.GetString(1).ToString(); } else { UserTest.identifiant = ""; };
                if (!readerID.IsDBNull(3)) { UserTest.nom = readerID.GetString(2).ToString(); } else { UserTest.nom = ""; };
                if (!readerID.IsDBNull(4)) { UserTest.password = readerID.GetString(3).ToString(); } else { UserTest.password = ""; };
                if (!readerID.IsDBNull(5)) { UserTest.role = readerID.GetString(4).ToString(); } else { UserTest.role = ""; };
                User.Add(UserTest);
                UserInfos.Add(User);
            }
            DataBaseConnection.Close();
            return UserInfos;
        }
        public static void FillTable(Dictionary<string, string> Data)
        {
            DataBaseConnection.Open();
            MySqlCommand cmd = DataBaseConnection.CreateCommand();
            foreach (var item in Data)
            {
                if (item.Key == "password")
                {
                    EncryptClass hashPswd = new EncryptClass();
                    cmd.Parameters.AddWithValue("@" + item.Key, hashPswd.hashPassword(item.Value));
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
            }
            cmd.CommandText = SQLCommands.FillTableSQLCommand(Data);
            cmd.ExecuteNonQuery();
            DataBaseConnection.Close();
        }
        public static bool IsUserExists(string identifiant)
        {
            MySqlDataReader reader = GetReaderSQLCommand(SQLCommands.FindUserSQLString(identifiant));
            if (reader.HasRows) { return true; } else { return false; }
        }
        public static MySqlDataReader GetReaderSQLCommand(string SQLCommand)
        {
            MySqlCommand cmd = DataBaseConnection.CreateCommand();
            cmd.CommandText = SQLCommand;
            MySqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        public static void ExecuteSQLCommand(string SQLCommand)
        {
            DataBaseConnection.Open();
            MySqlCommand cmd = DataBaseConnection.CreateCommand();
            cmd.CommandText = SQLCommand;
            cmd.ExecuteNonQuery();
            DataBaseConnection.Close();
        }
    }
}
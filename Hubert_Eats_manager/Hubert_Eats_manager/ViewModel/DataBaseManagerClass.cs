using System;
using System.Collections.Generic;
using System.Data;
using Hubert_Eats_manager.Model;
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

        public static Tuple<bool, string> AddUser(Dictionary<string, string> UserInfo)
        {
            if (IsUserExists(UserInfo["Identifiant"]))
                return Tuple.Create(false, "Existing User");
            else
            {
                FillTable(UserInfo);
                return Tuple.Create(true, "L'utilisateur a bien été ajouté dans la base de donnée.");
            }
        }
        public static Tuple<bool, string> ModifyUser(string modifiedparameter, string selectedParameter, string identifiant)
        {
            Dictionary<string, string> UserInfo = new();
            UserInfo.Add("Key", selectedParameter);
            UserInfo.Add("Value", modifiedparameter);
            UserInfo.Add("Identifiant", identifiant);
            ExecuteSQLCommand(SQLCommands.UpdateTableSqlString(UserInfo));
            UserInfo.Clear();
            UserInfo.Add("ModifiedBy", UserLoggedClass.UserName);
            UserInfo.Add("Identifiant", identifiant);
            ExecuteSQLCommand(SQLCommands.UpdateTableSqlString(UserInfo));
            return Tuple.Create(true, "Modification effectuée pour" + identifiant);
        }

        public static Tuple<bool, string> DeleteUser(string identifiant)
        {
            Dictionary<string, string> UserInfo = new();
            UserInfo.Add("Identifiant", identifiant);
            ExecuteSQLCommand(SQLCommands.DeleteUserSQLString(UserInfo));
            if (IsUserExists(identifiant) == false)
            {
                return Tuple.Create(true, "l'utilisateur " + identifiant + " a été supprimé");
            }
            else
            {
                return Tuple.Create(true, "l'utilisateur n'a pas pu être supprimé");
            }
        }

        public static List<List<string>> FindUser(string identifiant)
        {
            Dictionary<string, string> UserInfo = new();
            UserInfo.Add("Identifiant", identifiant);
            DataBaseConnection.Open();
            MySqlDataReader readerID = GetReaderSQLCommand(SQLCommands.FindUserSQLString(UserInfo));
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
            DataBaseConnection.Close();
            return UserInfos;
        }
        
        public static List<ExtractDatabase> FindUserr(string identifiant)
        {
            Dictionary<string,string> UserInfo = new();
            UserInfo.Add("identifiant", identifiant);
            DataBaseConnection.Open();
            MySqlDataReader readerID = GetReaderSQLCommand(SQLCommands.FindUserSQLString(UserInfo));
            List<ExtractDatabase> User = new();
            while (readerID.Read())
            {
                ExtractDatabase UserTest = new();
                if (!readerID.IsDBNull(1)) { UserTest.idInternalUser = readerID.GetString(0).ToString(); } else { UserTest.idInternalUser = ""; };
                if (!readerID.IsDBNull(2)) { UserTest.identifiant = readerID.GetString(1).ToString(); } else { UserTest.identifiant = ""; };
                if (!readerID.IsDBNull(3)) { UserTest.nom = readerID.GetString(2).ToString(); } else { UserTest.nom = ""; };
                if (!readerID.IsDBNull(5)) { UserTest.role = readerID.GetString(4).ToString(); } else { UserTest.role = ""; };
                User.Add(UserTest);
            }
            DataBaseConnection.Close();
            return User;
        }
        public static string GetRole(string username)
        {
            Dictionary<string, string> UserInfo = new();
            UserInfo.Add("Identifiant", username);
            DataBaseConnection.Open();
            MySqlDataReader readerID = GetReaderSQLCommand(SQLCommands.FindUserSQLString(UserInfo));
            string role = "";
            while (readerID.Read())
            {
                if (!readerID.IsDBNull(4)) { role = readerID.GetString(4).ToString(); } else { role = ""; };
            }
            DataBaseConnection.Close();
            return role;

        }
        public static List<ExtractDatabase> SQLDataToDatagrid()
        {
            DataBaseConnection.Open();
            MySqlCommand test = SQLCommands.AllDataSQLString();
            MySqlDataReader readerID = GetReaderSQLCommand(test);
            List<ExtractDatabase> User = new();
            while (readerID.Read())
            {
                ExtractDatabase UserTest = new();
                if (!readerID.IsDBNull(1)) { UserTest.idInternalUser = readerID.GetString(0).ToString(); } else { UserTest.idInternalUser = ""; };
                if (!readerID.IsDBNull(2)) { UserTest.identifiant = readerID.GetString(1).ToString(); } else { UserTest.identifiant = ""; };
                if (!readerID.IsDBNull(3)) { UserTest.nom = readerID.GetString(2).ToString(); } else { UserTest.nom = ""; };
                if (!readerID.IsDBNull(5)) { UserTest.role = readerID.GetString(4).ToString(); } else { UserTest.role = ""; };
                User.Add(UserTest);
            }
            DataBaseConnection.Close();
            return User;
        }
        public static void FillTable(Dictionary<string, string> Data)
        {
            DataBaseConnection.Open();
            GetReaderSQLCommand(SQLCommands.FillTableSQLCommand(Data));
            DataBaseConnection.Close();
        }
        public static bool IsUserExists(string identifiant)
        {
            DataBaseConnection.Open();
            Dictionary<string, string> UserInfo = new();
            UserInfo.Add("Identifiant", identifiant);
            MySqlDataReader reader = GetReaderSQLCommand(SQLCommands.FindUserSQLString(UserInfo));
            if (reader.HasRows) { DataBaseConnection.Close(); return true; } else { DataBaseConnection.Close(); return false; }
        }
        public static MySqlDataReader GetReaderSQLCommand(MySqlCommand SQLCommand)
        {
            try
            {
                MySqlDataReader reader = SQLCommand.ExecuteReader();
                return reader;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public static void ExecuteSQLCommand(MySqlCommand SQLCommand)
        {
            try
            {
                if (DataBaseConnection.State == ConnectionState.Closed)
                {
                    DataBaseConnection.Open();
                }
                SQLCommand.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                DataBaseConnection?.Close();
            }
        }
    }
}
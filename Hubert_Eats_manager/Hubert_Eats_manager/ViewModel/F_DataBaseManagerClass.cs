using System;
using System.Collections.Generic;
using System.Data;
using Hubert_Eats_manager.Model;
using Hubert_Eats_manager.ViewModel;
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
        
        public static MySqlConnection DataBaseConnection = SQLDatabase.GetDatabaseDBConnection();

        public static Tuple<bool, string> AddUser(string identifiant, string username, string password, string role )
        {
            if (IsUserExists(identifiant))
                return Tuple.Create(false, "Existing User");
            else
            {
                AddUserClass userToAdd = new();
                userToAdd.Identifiant = identifiant;
                userToAdd.Username = username;
                userToAdd.Password = password;
                userToAdd.Role = role;
                userToAdd.AddUser();
                return Tuple.Create(true, MessageClass.GetConfirmationMessage("UserAdded"));
            }
        }
        public static Tuple<bool, string> ModifyUser(string modifiedparameter, string selectedParameter, string identifiant)
        {
            ModifyUserClass userToModify = new();
            userToModify.Value = modifiedparameter;
            userToModify.Key = selectedParameter;
            userToModify.Identifiant = identifiant;
            userToModify.ModifyTable();

            return Tuple.Create(true, MessageClass.GetConfirmationMessage("UserModified"));
        }

        public static Tuple<bool, string> DeleteUser(string identifiant)
        {
            DeleteUserClass userToDelete = new();
            userToDelete.Identifiant = identifiant;
            userToDelete.DeteteUser();

            if (IsUserExists(identifiant) == false)
            {
                return Tuple.Create(true, MessageClass.GetConfirmationMessage("UserDeleted"));
            }
            else
            {
                return Tuple.Create(true, MessageClass.GetErrorMessage("UserNotDeleted"));
            }
        }

        public static List<List<string>> FindUser(string identifiant)
        {
            Dictionary<string, string> UserInfo = new();
            UserInfo.Add("Identifiant", identifiant);
            DataBaseConnection.Open();
            MySqlDataReader readerID = GetReaderSQLCommand(SQLCommands.FindUser(UserInfo));
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
            Dictionary<string, string> UserInfo = new();
            UserInfo.Add("identifiant", identifiant);
            DataBaseConnection.Open();
            MySqlDataReader readerID = GetReaderSQLCommand(SQLCommands.FindUser(UserInfo));
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
            //ExecuteSQLCommand(SQLCommands.LogFindUserSQLString(UserInfo),DataBaseConnection);
            return User;
        }
        public static string GetRole(string username)
        {
            Dictionary<string, string> UserInfo = new();
            UserInfo.Add("Identifiant", username);
            DataBaseConnection.Open();
            MySqlDataReader readerID = GetReaderSQLCommand(SQLCommands.FindUser(UserInfo));
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
            MySqlDataReader readerID = GetReaderSQLCommand(SQLCommands.AllData());
            List<ExtractDatabase> User = new();
            while (readerID.Read())
            {
                ExtractDatabase UserTest = new();
                if (!readerID.IsDBNull(0)) { UserTest.idInternalUser = readerID.GetString(0).ToString(); } else { UserTest.idInternalUser = ""; };
                if (!readerID.IsDBNull(1)) { UserTest.identifiant = readerID.GetString(1).ToString(); } else { UserTest.identifiant = ""; };
                if (!readerID.IsDBNull(2)) { UserTest.nom = readerID.GetString(2).ToString(); } else { UserTest.nom = ""; };
                if (!readerID.IsDBNull(4)) { UserTest.role = readerID.GetString(4).ToString(); } else { UserTest.role = ""; };
                User.Add(UserTest);
            }
            DataBaseConnection.Close();
            //Dictionary<string, string> UserInfo = new();
            //UserInfo.Add("createdBy", UserLoggedClass.UserName);
            //UserInfo.Add("role", UserLoggedClass.UserRole);
            //UserInfo.Add("command", SQLCommands.AllDataSQLString());
            //ExecuteSQLCommand(SQLCommands.Log_FillTable(UserInfo), LogConnection);
            return User;
        }
        public static List<ExtractDatabase> LogSQLDataToDatagrid()
        {
            DataBaseConnection.Open();
            MySqlDataReader readerID = GetReaderSQLCommand(SQLCommands.AllLogDataSQLString());
            List<ExtractDatabase> User = new();
            while (readerID.Read())
            {
                ExtractDatabase UserTest = new();
                if (!readerID.IsDBNull(1)) { UserTest.idInternalUser = readerID.GetString(1).ToString(); } else { UserTest.idInternalUser = ""; };
                if (!readerID.IsDBNull(2)) { UserTest.identifiant = readerID.GetString(1).ToString(); } else { UserTest.identifiant = ""; };
                if (!readerID.IsDBNull(3)) { UserTest.nom = readerID.GetString(3).ToString(); } else { UserTest.nom = ""; };
                User.Add(UserTest);
            }
            DataBaseConnection.Close();

            //Dictionary<string, string> UserInfo = new();
            //UserInfo.Add("createdBy", UserLoggedClass.UserName);
            //UserInfo.Add("role", UserLoggedClass.UserRole);
            //UserInfo.Add("command", SQLCommands.AllDataSQLString());
            //ExecuteSQLCommand(SQLCommands.Log_FillTable(UserInfo), LogConnection);
            return User;
        }
        public static bool IsUserExists(string identifiant)
        {
            DataBaseConnection.Open();
            Dictionary<string, string> UserInfo = new();
            UserInfo.Add("Identifiant", identifiant);
            MySqlDataReader reader = GetReaderSQLCommand(SQLCommands.FindUser(UserInfo));
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
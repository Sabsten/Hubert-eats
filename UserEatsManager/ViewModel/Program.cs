using System;
using System.Collections.Generic;
using Model;
using MySql.Data.MySqlClient;

namespace ViewModel
{
    class Program
    {
        static readonly MySqlConnection DataBaseConnection = SQLDatabase.GetDBConnection();
        public Tuple<bool, string> addUser(Dictionary<string,string> UserInfo)
        {
            SeederClass db = new();
            if (SeederClass.CheckExistingAccount(UserInfo["Identifiant"]))
                return (false, "Existing User").ToTuple();
            else
            {
                db.FillTable(UserInfo);
                return (true, "L'utilisateur a bien été ajouté dans la base de donnée.").ToTuple();
            }
        }
        public Tuple<bool, string> modifyUser(string modifiedparameter, int NumberSelected, List<List<string>> Data, string identifiant, string ModifiedBy)
        {
            ExecuteSQLCommand("update " + SQLDatabase.UserTable + " set '" + Data[0][NumberSelected] + "' = '" + modifiedparameter + "' where 'Identifiant' = '" + identifiant + "'");
            ExecuteSQLCommand("update " + SQLDatabase.UserTable + " set '" + Data[0][8] + "' = '" + ModifiedBy + "' where Identifiant ='" + identifiant + "'");
            return (true, "Modification effectuée " + identifiant).ToTuple();
        }

        public Tuple<bool, string> deleteUser(string identifiant)
        {
            ExecuteSQLCommand("delete from " + SQLDatabase.UserTable + " where Identifiant ='" + identifiant + "'");
            return (true, "Utilisateur "+ identifiant + "supprimé de la base").ToTuple();
        }

        public List<List<string>> FindUser(string identifiant)
        {
            MySqlDataReader readerID = GetReaderSQLCommand("select * from " + SQLDatabase.UserTable + " where Identifiant = '" + identifiant + "'");
            List<List<string>> UserInfos = new();
            UserInfos.Add(DictionaryToListKeys(Usertable.GetUserTableToPrompt()));
            List<string> User = new();
            int i = 0;
            while (readerID.Read())
            {
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
        private static List<string> DictionaryToListKeys(Dictionary<string, string> dict)
        {
            List<string> list = new();
            foreach (var item in dict)
            {
                list.Add(item.Key);
            }
            return list;
        }
        public static MySqlDataReader GetReaderSQLCommand(string SQLCommand)
        {
            DataBaseConnection.Open();
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
        }
    }
}

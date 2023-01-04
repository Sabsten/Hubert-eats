using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using View;
using System.Data.Common;
using System.Data;
using MySql.Data.MySqlClient;
using System.Threading;
using System.Data.SqlTypes;
using UserEatsManager.Model.Tables;

namespace ViewModel
{
    class Program
    {
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
        public Tuple<bool, string> modifyUser(string modifiedparameter, int NumberSelected, List<List<string>> Data, string identifiant)
        {
            MySqlConnection connection = SQLDatabase.GetDBConnection();
            MySqlCommand cmd = connection.CreateCommand();
            string test = "update " + SQLDatabase.UserTable + " set " + Data[0][NumberSelected] + " = '" + modifiedparameter + "' where Identifiant ='" + identifiant + "'";
            cmd.CommandText = test;
            return (true, "Modification effectuée " + identifiant).ToTuple();
        }

        public Tuple<bool, string> deleteUser(string identifiant)
        {
            MySqlConnection connection = SQLDatabase.GetDBConnection();
            connection.Open();
            MySqlCommand IDcmd = connection.CreateCommand();
            IDcmd.CommandText = "delete from " + SQLDatabase.UserTable + " where Identifiant ='" + identifiant + "'";
            IDcmd.ExecuteNonQuery();
            MySqlDataReader readerID = IDcmd.ExecuteReader();
            while (readerID.Read())
            {
                int i = 0;
                while (readerID.FieldCount != i)
                {
                    if (!readerID.IsDBNull(i)) return (true,"Utilisateur " + identifiant + " supprimé").ToTuple();
                }
                
            }
            return (false, "Utilisateur non trouvé").ToTuple();
        }
        
        public List<List<string>> FindUser(string identifiant)
        {
            MySqlConnection connection = SQLDatabase.GetDBConnection();
            connection.Open();
            MySqlCommand IDcmd = connection.CreateCommand();
            IDcmd.CommandText = "select * from " + SQLDatabase.UserTable + " where Identifiant ='" + identifiant + "'";
            IDcmd.ExecuteNonQuery();
            MySqlDataReader readerID = IDcmd.ExecuteReader();
            List<List<string>> UserInfos = new();
            Usertable test = new();
            UserInfos.Add(DictionaryToListKeys(Usertable.GetUserTableDictionary()));
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
        private List<string> DictionaryToListKeys(Dictionary<string, string> dict)
        {
            List<string> list = new();
            foreach (var item in dict)
            {
                list.Add(item.Key);
            }
            return list;
        }

    }
}

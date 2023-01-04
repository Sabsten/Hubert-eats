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
        public Tuple<bool, string> modifyUser(string modifiedparameter, string modifiedvalue ,string identifiant)
        {
            MySqlConnection connection = SQLDatabase.GetDBConnection();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "update "+ SQLDatabase.UserTable +" set "+ modifiedparameter +" = '" + modifiedvalue  + "' where Identifiant ='" + identifiant + "'";
            return (true, "Modification effectuée " + identifiant).ToTuple();

            //return (false, "Utilisateur non trouvé").ToTuple();
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

        public List<Tuple<string, string, string, string, string>> FindUser(string identifiant)
        {
            MySqlConnection connection = SQLDatabase.GetDBConnection();
            connection.Open();
            MySqlCommand IDcmd = connection.CreateCommand();
            IDcmd.CommandText = "select * from " + SQLDatabase.UserTable + " where Identifiant ='" + identifiant + "'";
            IDcmd.ExecuteNonQuery();
            MySqlDataReader readerID = IDcmd.ExecuteReader();
            List<Tuple<string, string, string, string, string>> UserInfos = new();
            List<string> User = new();
            int i = 0;
            while (readerID.Read())
            {
                while (i != 5)
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
                UserInfos.Add((User[0], User[1], User[2], User[3], User[4]).ToTuple());
            }
            return UserInfos;
        }
    }
}

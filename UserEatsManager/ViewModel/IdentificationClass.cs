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

namespace ViewModel
{
    class IdentificationClass
    {
        public Tuple<bool, string> Login(string identifiant, string password)
        {
            if (identifiant == "42") //A supprimer pour le rendu
            {
                Console.WriteLine("Création de table :"); //A supprimer pour le rendu
                SeederClass seed = new(); //A supprimer pour le rendu
                seed.CreateTable(SQLDatabase.UserTable); //A supprimer pour le rendu
                Console.WriteLine("Table crée !"); //A supprimer pour le rendu
                seed.Seeder(); //A supprimer pour le rendu
                return (true,"La table" + SQLDatabase.UserTable + " a bien été crée!").ToTuple(); //A supprimer pour le rendu
            }
            MySqlConnection connection = SQLDatabase.GetDBConnection();
            connection.Open();
            MySqlCommand IDcmd = connection.CreateCommand();
            IDcmd.Parameters.AddWithValue("@Identifiant", identifiant);
            IDcmd.CommandText = "select password from "+ SQLDatabase.UserTable + " where Identifiant ='"+ identifiant +"'";
            IDcmd.ExecuteNonQuery();
            MySqlDataReader readerID = IDcmd.ExecuteReader();
            if (readerID.HasRows)
            {
                string dbPassword = "";
                while (readerID.Read())
                {
                    dbPassword = readerID.GetString(0);
                }
                EncryptClass encrypt = new();
                if (encrypt.hashPassword(password) == dbPassword)
                {
                    return (true, "Les mots de passes correspondent !").ToTuple(); ;
                }
                else
                {
                    return (false, "la confirmation a échoué").ToTuple();
                }
            }
            else
            {
                return (false, "Identifiant non trouvé dans la base de donnée").ToTuple();
            }
        }
    }
}
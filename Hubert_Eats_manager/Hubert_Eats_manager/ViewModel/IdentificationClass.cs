using System;
using Model;
using MySql.Data.MySqlClient;

namespace ViewModel
{
    class IdentificationClass
    {
        public Tuple<bool, string> Login(string identifiant, string password)
        {
            if (identifiant == "42") //A supprimer pour le rendu
            {
                Console.WriteLine("Mise en place du seeder"); //A supprimer pour le rendu
                SeederClass seed = new(); //A supprimer pour le rendu
                seed.InitDb(); //A supprimer pour le rendu
                return (true, "La table" + SQLDatabase.UserTable + " a bien été crée!").ToTuple(); //A supprimer pour le rendu
            }
            MySqlConnection connection = SQLDatabase.GetDBConnection();
            connection.Open();
            MySqlCommand IDcmd = connection.CreateCommand();
            IDcmd.CommandText = SQLCommands.FindHashedPasswordSQLString(identifiant);
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
                    connection.Close();
                    return (true, "Les mots de passes correspondent !").ToTuple(); ;
                }
                else
                {
                    connection.Close();
                    return (false, "la confirmation a échoué").ToTuple();
                }
            }
            else
            {
                connection.Close();
                return (false, "Identifiant non trouvé dans la base de donnée").ToTuple();
            }
        }
    }
}
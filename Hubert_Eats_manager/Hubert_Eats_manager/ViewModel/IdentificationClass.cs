using System;
using System.Collections.Generic;
using Hubert_Eats_manager.Model;
using Model;
using MySql.Data.MySqlClient;

namespace ViewModel
{
    class IdentificationClass
    {
        public static Tuple<bool, string> Login(string identifiant, string password)
        {
            if (identifiant == "hubert" && password == EncryptClass.DecodeFrom64("Y2VzaWh1YmVydA=="))
            {
                SeederClass.InitDb(); 
                return (false, "La table" + SQLDatabase.UserTable + " a bien été crée!").ToTuple(); 
            }
            Dictionary<string, string> UserInfo = new();
            UserInfo.Add("identifiant", identifiant);
            DataBaseManagerClass.DataBaseConnection.Open();
            MySqlCommand IDcmd = SQLCommands.FindHashedPasswordSQLString(UserInfo);

            MySqlDataReader readerID = IDcmd.ExecuteReader();
            if (readerID.HasRows)
            {
                string dbPassword = "";
                while (readerID.Read())
                {
                    dbPassword = readerID.GetString(0);
                }
                if (EncryptClass.HashPassword(password) == dbPassword)
                {
                    DataBaseManagerClass.DataBaseConnection.Close();
                    return (true, "").ToTuple();
                }
                else
                {
                    DataBaseManagerClass.DataBaseConnection.Close();
                    return (false, MessageClass.GetErrorMessage("PasswordIncorrect")).ToTuple();
                }
            }
            else
            {
                DataBaseManagerClass.DataBaseConnection.Close();
                return (false, MessageClass.GetErrorMessage("UserNotFound")).ToTuple();
            }
        }
    }
}
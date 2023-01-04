using Model;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ViewModel
{
    class SeederClass
    {
        public enum Role
        {
            Commercial,
            Developpeur,
            Technique,
            BddManager
        }
        public void CreateTable(string tableName)
        {
            // Étabilissez de la connexion à la base de données. 
            MySqlConnection connection = SQLDatabase.GetDBConnection();
            connection.Open();
            string sql = "CREATE TABLE `" + SQLDatabase.Database + "`.`" + SQLDatabase.UserTable + "` (" +
            "`idInternalUser` INT NOT NULL AUTO_INCREMENT," +
            "`identifiant` VARCHAR(45) NULL," +
            "`nom` VARCHAR(45) NULL," +
            "`password` VARCHAR(45) NULL," +
            "`role` VARCHAR(45) NULL," +
            "`createdAt` TIMESTAMP DEFAULT CURRENT_TIMESTAMP," +
            "`createdBy` VARCHAR(45) NULL," +
            "`modifiedAt` DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP," +
            "`modifiedBy` VARCHAR(45) NULL," +
            "PRIMARY KEY(`idInternalUser`))";
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }

        public void FillTable(Dictionary<string, string> Data)
        {
            MySqlConnection connection = SQLDatabase.GetDBConnection();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            string sqlLine1 = "Insert into " + SQLDatabase.UserTable + "(";
            string sqlLine2 = " values (";
            foreach (KeyValuePair<string, string> item in Data)
            {
                sqlLine1 += item.Key + ", ";
                sqlLine2 += "@" + item.Key + ", ";
                if (item.Key == "password")
                {
                    EncryptClass hashPswd = new EncryptClass();
                    cmd.Parameters.AddWithValue("@" + item.Key, hashPswd.hashPassword(item.Value));
                }
                else if (item.Key == "role")
                {
                    if (item.Value is string)
                    {
                        cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
                    }
                    else
                    {
                        var role = (Role)int.Parse(item.Value);
                        cmd.Parameters.AddWithValue("@" + item.Key, role.ToString());
                    }
                }
                else
                {
                    cmd.Parameters.AddWithValue("@" + item.Key, item.Value);
                }
            }
            sqlLine1 = sqlLine1.Substring(0, sqlLine1.Length - 2) + ")";
            sqlLine2 = sqlLine2.Substring(0, sqlLine2.Length - 2) + ")";

            cmd.CommandText = $"{sqlLine1}{sqlLine2}";
            cmd.ExecuteNonQuery();
        }

        public static bool CheckExistingAccount(string identifiant)
        {
            MySqlDataReader reader = ExecuteSQLCommand("select Identifiant from " + SQLDatabase.UserTable + " where Identifiant = '" + identifiant + "'");
            if(reader.HasRows) { return true; } else { return false; }
        }

        public void Seeder()
        {
            Dictionary<string, string> Info = new();
            Info.Add ("identifiant","m.galos@hubert.com");
            Info.Add("nom", "Mélissa GALOS");
            Info.Add("password", "MGALOS");
            Info.Add("role", Role.BddManager.ToString());
            FillTable(Info);

            Info.Clear();
            Info.Add("identifiant", "p.pierre@hubert.com");
            Info.Add("nom", "Paul PIERRE");
            Info.Add("password", "PPIERRE");
            Info.Add("role", Role.BddManager.ToString());
            FillTable(Info);

            Info.Clear();
            Info.Add("identifiant", "j.lafond@hubert.com");
            Info.Add("nom", "Jacques LAFOND");
            Info.Add("password", "JLAFOND");
            Info.Add("role", Role.Technique.ToString());
            FillTable(Info);

            Info.Clear();
            Info.Add("identifiant", "a.miller@hubert.com");
            Info.Add("nom", "Albert MILLER");
            Info.Add("password", "AMILLER");
            Info.Add("role", Role.Developpeur.ToString());
            FillTable(Info);

            Info.Clear();
            Info.Add("identifiant", "t.tometnana@hubert.com");
            Info.Add("nom", "Tom TOMETNANA");
            Info.Add("password", "TTOMETNANA");
            Info.Add("role", Role.Commercial.ToString());
            FillTable(Info);
        }

        private static MySqlDataReader ExecuteSQLCommand(string SQLCommand)
        {
            MySqlConnection connection = SQLDatabase.GetDBConnection();
            connection.Open();
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = SQLCommand;
            MySqlDataReader reader = cmd.ExecuteReader();
            return reader;
        }
    }
}


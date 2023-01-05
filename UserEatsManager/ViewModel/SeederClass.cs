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
            MySqlConnection connection = SQLDatabase.GetDBConnection();
            connection.Open();
            Dictionary<string, string> test = new(Usertable.GetUserTable());

            string sql = "CREATE TABLE `" + SQLDatabase.Database + "`.`" + SQLDatabase.UserTable + "` (";
            foreach(var item in test)
            {
                sql = sql + item.Key + " " + item.Value + " ";
            }
            sql = sql.Substring(0, sql.Length - 1) + ");";
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
            foreach (var item in Data)
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
            Info.Add("createdBy", "root");
            Info.Add("modifiedBy", "root");
            FillTable(Info);

            Info.Clear();
            Info.Add("identifiant", "p.pierre@hubert.com");
            Info.Add("nom", "Paul PIERRE");
            Info.Add("password", "PPIERRE");
            Info.Add("createdBy", "root");
            Info.Add("modifiedBy", "root");
            Info.Add("role", Role.BddManager.ToString());
            FillTable(Info);

            Info.Clear();
            Info.Add("identifiant", "j.lafond@hubert.com");
            Info.Add("nom", "Jacques LAFOND");
            Info.Add("password", "JLAFOND");
            Info.Add("createdBy", "root");
            Info.Add("modifiedBy", "root");
            Info.Add("role", Role.Technique.ToString());
            FillTable(Info);

            Info.Clear();
            Info.Add("identifiant", "a.miller@hubert.com");
            Info.Add("nom", "Albert MILLER");
            Info.Add("password", "AMILLER");
            Info.Add("role", Role.Developpeur.ToString());
            Info.Add("createdBy", "root");
            Info.Add("modifiedBy", "root");
            FillTable(Info);

            Info.Clear();
            Info.Add("identifiant", "t.tometnana@hubert.com");
            Info.Add("nom", "Tom TOMETNANA");
            Info.Add("password", "TTOMETNANA");
            Info.Add("role", Role.Commercial.ToString());
            Info.Add("createdBy", "root");
            Info.Add("modifiedBy", "root");
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


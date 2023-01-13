using Model;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace ViewModel
{
    class SeederClass
    {
        private static void CreateLogTable()
        {
            DataBaseManagerClass.DataBaseConnection.Open();
            Dictionary<string, string> test = new(Usertable.Seeder_GetLogTable());

            string sql = "CREATE TABLE " + SQLDatabase.LogTable + " (";
            foreach (var item in test)
            {
                sql = sql + item.Key + " " + item.Value + " ";
            }
            sql = sql.Substring(0, sql.Length - 1) + ");";
            MySqlCommand cmd = DataBaseManagerClass.DataBaseConnection.CreateCommand();

            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            DataBaseManagerClass.DataBaseConnection.Close();
        }

        private static void CreateUserTable()
        {
            DataBaseManagerClass.DataBaseConnection.Open();
            Dictionary<string, string> test = new(Usertable.Seeder_GetUserTable());

            string sql = "CREATE TABLE `" + SQLDatabase.Database + "`.`" + SQLDatabase.UserTable + "` (";
            foreach (var item in test)
            {
                sql = sql + item.Key + " " + item.Value + " ";
            }
            sql = sql.Substring(0, sql.Length - 1) + ");";
            MySqlCommand cmd = DataBaseManagerClass.DataBaseConnection.CreateCommand();

            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            DataBaseManagerClass.DataBaseConnection.Close();
        }

        public static void InitDb()
        {
            CreateLogTable();
            CreateUserTable();
            Seeder();
        }
        public static void Seeder()
        {

            Dictionary<string, string> Info = new();
            Info.Add("identifiant", "m.galos@hubert.com");
            Info.Add("nom", "Mélissa GALOS");
            Info.Add("password", "MGALOS");
            Info.Add("role", DataBaseManagerClass.Role.BddManager.ToString());
            Info.Add("createdBy", "root");
            Info.Add("modifiedBy", "root");
            DataBaseManagerClass.FillTable(Info);

            Info.Clear();
            Info.Add("identifiant", "p.pierre@hubert.com");
            Info.Add("nom", "Paul PIERRE");
            Info.Add("password", "PPIERRE");
            Info.Add("createdBy", "root");
            Info.Add("modifiedBy", "root");
            Info.Add("role", DataBaseManagerClass.Role.BddManager.ToString());
            DataBaseManagerClass.FillTable(Info);

            Info.Clear();
            Info.Add("identifiant", "j.lafond@hubert.com");
            Info.Add("nom", "Jacques LAFOND");
            Info.Add("password", "JLAFOND");
            Info.Add("createdBy", "root");
            Info.Add("modifiedBy", "root");
            Info.Add("role", DataBaseManagerClass.Role.Technique.ToString());
            DataBaseManagerClass.FillTable(Info);

            Info.Clear();
            Info.Add("identifiant", "a.miller@hubert.com");
            Info.Add("nom", "Albert MILLER");
            Info.Add("password", "AMILLER");
            Info.Add("role", DataBaseManagerClass.Role.Developpeur.ToString());
            Info.Add("createdBy", "root");
            Info.Add("modifiedBy", "root");
            DataBaseManagerClass.FillTable(Info);

            Info.Clear();
            Info.Add("identifiant", "t.tometnana@hubert.com");
            Info.Add("nom", "Tom TOMETNANA");
            Info.Add("password", "TTOMETNANA");
            Info.Add("role", DataBaseManagerClass.Role.Commercial.ToString());
            Info.Add("createdBy", "root");
            Info.Add("modifiedBy", "root");
            DataBaseManagerClass.FillTable(Info);
        }
    }
}

using Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace ViewModel
{
    class SeederClass
    {
        private static Tuple<bool, string> CreateTable(string TableName, Dictionary<string, string> TableShape)
        {
            try
            {
                DataBaseManagerClass.DataBaseConnection.Open();
                Dictionary<string, string> test = new(TableShape);

                string sql = "CREATE TABLE " + TableName + " (";
                foreach (var item in test)
                {
                    sql = sql + item.Key + " " + item.Value + " ";
                }
                sql = sql.Substring(0, sql.Length - 1) + ");";
                MySqlCommand cmd = DataBaseManagerClass.DataBaseConnection.CreateCommand();

                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                DataBaseManagerClass.DataBaseConnection.Close();
                return (true, "La table " + TableName + " a été créée avec succès").ToTuple();
            }
            catch (MySqlException e)
            {
                DataBaseManagerClass.DataBaseConnection.Close();
                return (false, e.Message).ToTuple();

            }
        }

        public static Tuple<bool, string> CreateLogTable()
        {
            return CreateTable(SQLDatabase.LogTable, Usertable.Seeder_GetLogTable());
        }

        public static Tuple<bool, string> CreateUserTable()
        {
            return CreateTable(SQLDatabase.UserTable, Usertable.Seeder_GetUserTable());
        }

        public static Tuple<bool, string> ApplySeeder()
        {
            try
            {
                AddUserClass userToAdd1 = new();
                userToAdd1.Identifiant = "m.galos@hubert.com";
                userToAdd1.Username = "Melissa Galos";
                userToAdd1.Password = "MGALOS";
                userToAdd1.Role = DataBaseManagerClass.Role.BddManager.ToString();
                userToAdd1.AddUser();


                AddUserClass userToAdd2 = new();
                userToAdd2.Identifiant = "p.pierre@hubert.com";
                userToAdd2.Username = "Paul PIERRE";
                userToAdd2.Password = "PPIERRE";
                userToAdd2.Role = DataBaseManagerClass.Role.BddManager.ToString();
                userToAdd2.AddUser();

                AddUserClass userToAdd3 = new();
                userToAdd3.Identifiant = "j.lafond@hubert.com";
                userToAdd3.Username = "Jacques LAFOND";
                userToAdd3.Password = "JLAFOND";
                userToAdd3.Role = DataBaseManagerClass.Role.Technique.ToString();
                userToAdd3.AddUser();

                AddUserClass userToAdd4 = new();
                userToAdd4.Identifiant = "a.miller@hubert.com";
                userToAdd4.Username = "Albert MILLER";
                userToAdd4.Password = "AMILLER";
                userToAdd4.Role = DataBaseManagerClass.Role.Developpeur.ToString();
                userToAdd4.AddUser();

                AddUserClass userToAdd5 = new();
                userToAdd5.Identifiant = "a.Cartier@hubert.com";
                userToAdd5.Username = "Alexandre Cartier";
                userToAdd5.Password = "ACARTIER";
                userToAdd5.Role = DataBaseManagerClass.Role.Commercial.ToString();
                userToAdd5.AddUser();
                return Tuple.Create(true, "Les utilisateurs ont été ajoutés avec succès");
            }
            catch (MySqlException e)
            {
                return e.Number switch
                {
                    1062 => Tuple.Create(true, "Les utilisateurs ont déjà été ajoutés"),
                    _ => Tuple.Create(false, "Erreur : " + e),
                };
            }
        }
    }
}

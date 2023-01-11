using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class SQLCommands
    {
        public static string FindUserSQLString(string identifiant)
        {
            return "SELECT * FROM " + SQLDatabase.UserTable + " WHERE identifiant = '" + identifiant + "'";
        }
        public static string FindHashedPasswordSQLString(string identifiant)
        {
            return "SELECT password FROM " + SQLDatabase.UserTable + " WHERE identifiant = '" + identifiant + "'";
        }
        public static string UpdateTableSqlString(string ColumnItem, string Value, string identifiant)
        {
            return "UPDATE " + SQLDatabase.UserTable + " SET " + ColumnItem + " = '" + Value + "' WHERE identifiant = '" + identifiant + "'";
        }

        public static string AllDataSQLString()
        {
            return "SELECT * FROM " + SQLDatabase.UserTable;
        }
        public static string FillTableSQLCommand(Dictionary<string, string> Data)
        {
            string sqlLine1 = "INSERT INTO " + SQLDatabase.UserTable + "(";
            string sqlLine2 = " VALUE (";
            foreach (var item in Data)
            {
                sqlLine1 += item.Key + ", ";
                sqlLine2 += "@" + item.Key + ", ";
            }
            return sqlLine1[0..^2] + ")" + sqlLine2[0..^2] + ")";
        }
    }
}
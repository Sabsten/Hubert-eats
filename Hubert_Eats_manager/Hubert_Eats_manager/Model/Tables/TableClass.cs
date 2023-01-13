using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;
using System.Data.Common;
using System.Data;
using MySql.Data.MySqlClient;
using System.Threading;
using System.Data.SqlTypes;

namespace Model
{
    public class ExtractDatabase
    {
        public string? idInternalUser { get; set; }
        public string? identifiant { get; set; }
        public string? nom { get; set; }
        public string? role { get; set; }

    }

    class Usertable
    {
        public static Dictionary<string, string> Seeder_GetUserTable()
        {
            Dictionary<string, string> TableInfo = new()
            {
                { "`idInternalUser`", "INT NOT NULL AUTO_INCREMENT," },
                { "`identifiant`", "VARCHAR(45) NULL," },
                { "`nom`" , "VARCHAR(45) NULL," },
                { "`password`", "VARCHAR(45) NULL," },
                { "`role`", "VARCHAR(45) NULL," },
                { "`createdAt`", "TIMESTAMP DEFAULT CURRENT_TIMESTAMP," },
                { "`createdBy`", "VARCHAR(45) NULL," },
                { "`modifiedAt`", "DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP," },
                { "`modifiedBy`", "VARCHAR(45) NULL," },
                { "`isActive`", "BOOLEAN DEFAULT TRUE," },
                { "`inactiveDate`", "DATETIME DEFAULT NULL," },
                { "PRIMARY KEY", "(`idInternalUser`)" }
            };
            return TableInfo;
        }
        public static Dictionary<string, string> Seeder_GetLogTable()
        {
            Dictionary<string, string> TableInfo = new()
            {
                { "`idTransaction`", "INT NOT NULL AUTO_INCREMENT," },
                { "`createdBy`", "VARCHAR(45) NULL," },
                { "`role`", "VARCHAR(45) NULL," },
                { "`command`", "VARCHAR(300) NULL," },
                { "`createdAt`", "TIMESTAMP DEFAULT CURRENT_TIMESTAMP," },
                { "PRIMARY KEY", "(`idTransaction`)" }
            };
            return TableInfo;
        }

        public static Dictionary<string, string> GetUserTableToPrompt()
        {
            Dictionary<string, string> TableInfo = new()
            {
                { "idInternalUser", "UserID" },
                { "identifiant", "Identifiant" },
                { "nom", "Nom Prénom" },
                { "password", "Password" },
                { "role", "Fonction" },
                { "createdAt", "Date de création" },
                { "createdBy", "Compte crée par" },
                { "modifiedAt", "Date de derniere modification" },
                { "modifiedBy", "Compte dernierement modifié par" }
            };
            return TableInfo;
        }
        public static Dictionary<string, string> GetUserTableToAsk()
        {
            Dictionary<string, string> TableInfo = GetUserTableToPrompt();
            TableInfo.Remove("createdAt");
            TableInfo.Remove("createdBy");
            TableInfo.Remove("modifiedAt");
            TableInfo.Remove("modifiedBy");
            return TableInfo;
        }
    }
}
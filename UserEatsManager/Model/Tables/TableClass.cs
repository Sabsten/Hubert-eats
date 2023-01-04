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

namespace UserEatsManager.Model.Tables
{
    class Usertable
    {
        public static Dictionary<string, string> ReturnData()
        {
            Dictionary<string, string> TableInfo = new Dictionary<string, string>();
            TableInfo.Add("idInternalUser", "INT NOT NULL AUTO_INCREMENT");
            //             tableName        valueType
            TableInfo.Add("`identifiant`", "VARCHAR(45) NULL");
            TableInfo.Add("`nom` VARCHAR(45)", "NULL");
            TableInfo.Add("`password` ", "VARCHAR(45) NULL,");
            TableInfo.Add("`role`", " VARCHAR(45) NULL");
            TableInfo.Add("`createdAt` ", "TIMESTAMP DEFAULT CURRENT_TIMESTAMP,");
            TableInfo.Add("`createdBy`", " VARCHAR(45) NULL,");
            TableInfo.Add("`modifiedAt`", "DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,");
            TableInfo.Add("`modifiedBy`", "VARCHAR(45) NULL,");
            TableInfo.Add("PRIMARY KEY", "(`idInternalUser`)");
            return TableInfo;
        }

    }
}

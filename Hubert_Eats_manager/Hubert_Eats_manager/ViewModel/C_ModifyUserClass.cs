using Model;
using System;
using System.Collections.Generic;
using ViewModel;

namespace Hubert_Eats_manager.ViewModel
{
    class ModifyUserClass
    {
        public string Key;
        public string Value { get; internal set; }
        public string Identifiant { get; internal set; }

        public void ModifyTable()
        {
            Dictionary<string, string> DataTable = new() {
                { "Key", Identifiant },
                { "Value", Value },
                { "Identifiant", Identifiant },
            };
            Dictionary<string, string> ModifyTable = new() {
                { "ModifiedBy", UserLoggedClass.UserName },
                { "Identifiant", Identifiant },
            };
            try
            {
                DataBaseManagerClass.DataBaseConnection.Open();
                DataBaseManagerClass.ExecuteSQLCommand(SQLCommands.UpdateTable(DataTable));
                DataBaseManagerClass.ExecuteSQLCommand(SQLCommands.UpdateTable(ModifyTable));
                DataBaseManagerClass.DataBaseConnection.Close();
            }
            catch (InvalidCastException e)
            {
                // recover from exception
            }
            finally
            {
                LogClass LogUpdate = new()
                {
                    Command = SQLCommands.UpdateTableSqlString(DataTable)
                };
                DataBaseManagerClass.ExecuteSQLCommand(SQLCommands.Log_FillTable(LogUpdate.GetPayload()));
            }
        }
    }
}

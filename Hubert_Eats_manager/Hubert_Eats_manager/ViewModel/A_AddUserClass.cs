using Model;
using System;
using System.Collections.Generic;
using static ViewModel.DataBaseManagerClass;

namespace ViewModel
{
    class AddUserClass
    {
        public string Identifiant;
        public string Username { get; internal set; }
        public string Password { get; internal set; }
        public string Role { get; internal set; }

        public void AddUser()
        {
            Dictionary<string, string> DataTable = new()
            {
                { "identifiant", Identifiant },
                { "nom", Username },
                { "password", Password },
                { "role", Role },
                {"createdBy", UserLoggedClass.UserName == "" ? "root" : UserLoggedClass.UserName },
                {"modifiedby", UserLoggedClass.UserName == "" ? "root" : UserLoggedClass.UserName },
            };
            try
            {
                DataBaseConnection.Open();
                GetReaderSQLCommand(SQLCommands.FillTable(DataTable));
                DataBaseConnection.Close();
            }
            catch (InvalidCastException e)
            {
                // recover from exception
            }
            finally
            {
                LogClass FillTable = new()
                {
                    Command = SQLCommands.FillTableSQLCommand(DataTable)
                };
                ExecuteSQLCommand(SQLCommands.Log_FillTable(FillTable.GetPayload()));
            }
        }
    }
}

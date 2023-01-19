using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Hubert_Eats_manager.ViewModel
{
    internal class DeleteUserClass
    {
        public string Identifiant { get; internal set; }

        public void DeteteUser()
        {
            Dictionary<string, string> UserInfo = new() {

                { "Identifiant", Identifiant },
            };
            try
            {
                DataBaseManagerClass.ExecuteSQLCommand(SQLCommands.DeleteUser(UserInfo));
            }
            catch (InvalidCastException e)
            {
                // recover from exception
            }
            finally
            {
                LogClass LogUpdate = new()
                {
                    Command = SQLCommands.DeleteUserSQLString(UserInfo)
                };
                DataBaseManagerClass.ExecuteSQLCommand(SQLCommands.Log_FillTable(LogUpdate.GetPayload()));
            }
        }
    }
}

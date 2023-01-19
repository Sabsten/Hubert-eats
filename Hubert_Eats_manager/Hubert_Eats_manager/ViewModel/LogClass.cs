using Model;
using System.Collections.Generic;


namespace ViewModel
{
    internal class LogClass
    {
        private readonly string CreatedBy = UserLoggedClass.UserName;
        private readonly string Role = UserLoggedClass.Role;
        public string Command;

        public Dictionary<string, string> GetPayload()
        {
            Dictionary<string, string> LogTable = new() { { "createdBy", CreatedBy }, { "role", Role }, { "command", Command }, };
            return LogTable;
        }
        
    }
}

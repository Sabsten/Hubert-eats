using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hubert_Eats_manager.Model
{
    class RolePermissionClass
    {
        private static readonly Dictionary<string, List<string>> RolePermissions = new()
        {
            {"Database Manager", new List<string>{"Add", "Delete", "Modify", "Consult","Log"}},
            {"Commercial", new List<string>{"Consult"}},
            {"Technique", new List<string>{"Modify", "Consult","Log"}},
            {"Developpeur", new List<string>{}}
        };
        public static List<string> GetPermission(string Role)
        {
            return RolePermissions[Role];
        }
    }
}

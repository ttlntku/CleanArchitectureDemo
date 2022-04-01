using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Helpers
{
    public struct EmployeeRole
    {
        public static readonly Int16 ROLE_ADMIN = 201;
        public static readonly Int16 ROLE_USER = 202;
        public const string ROLE_ADMIN_NAME = "Administrator";
        public const string ROLE_USER_NAME = "User";
        public static readonly Dictionary<int, string> RoleMapper = new Dictionary<int, string>() { { ROLE_ADMIN, ROLE_ADMIN_NAME }, { ROLE_USER, ROLE_USER_NAME } };
    }
}

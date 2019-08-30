using System.Collections.Generic;

namespace FlyLolo.JWT.API
{
    public class Permission
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public string Method { get; set; }
    }

    public class UserPermissions
    {
        public string Code { get; set; }
        public List<Permission> Permissions { get; set; }
    }
}

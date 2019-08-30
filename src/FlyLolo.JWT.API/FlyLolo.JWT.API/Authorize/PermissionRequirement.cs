using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyLolo.JWT.API.Authorize
{
    public class PermissionRequirement: IAuthorizationRequirement
    {
        public List<UserPermissions> UsePermissionList { get { return TemporaryData.UserPermissions; } }
    }
}

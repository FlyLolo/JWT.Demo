using System.Collections.Generic;
using System.Linq;

namespace FlyLolo.JWT.API
{
    /// <summary>
    /// 虚拟数据，模拟从数据库或缓存中读取用户相关的权限
    /// </summary>
    public static class TemporaryData
    {
        public readonly static List<UserPermissions> UserPermissions = new List<UserPermissions> {
            new UserPermissions {
                Code = "001",
                Permissions = new List<Permission> {
                    new Permission { Code = "A1", Name = "student.create", Url = "/api/student",Method="post" },
                    new Permission { Code = "A2", Name = "student.delete", Url = "/api/student",Method="delete"}
                }
            },
            new UserPermissions {
                Code = "002",
                Permissions = new List<Permission> {
                    new Permission { Code = "B1", Name = "book.create", Url = "/api/book" ,Method="post"},
                    new Permission { Code = "B2", Name = "book.delete", Url = "/api/book" ,Method="delete"}
                }
            },
        };

        public static UserPermissions GetUserPermission(string code)
        {
            return UserPermissions.FirstOrDefault(m => m.Code.Equals(code));
        }
    }
}

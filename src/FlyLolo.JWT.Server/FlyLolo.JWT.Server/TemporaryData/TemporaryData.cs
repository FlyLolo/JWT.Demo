using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlyLolo.JWT.Server
{
    /// <summary>
    /// 虚拟数据，模拟从数据库中读取用户
    /// </summary>
    public static class TemporaryData
    {
        private static List<User> Users = new List<User>() { new User { Code = "001", Name = "张三", Password = "111111" }, new User { Code = "002", Name = "李四", Password = "222222" } };

        public static User GetUser(string code)
        {
            return Users.FirstOrDefault(m => m.Code.Equals(code));
        }
    }
}

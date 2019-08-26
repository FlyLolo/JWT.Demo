using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FlyLolo.JWT.Server
{
    public class Token
    {
        public string TokenContent { get; set; }

        public DateTime Expires { get; set; }
    }

    public class ComplexToken
    {
        public Token AccessToken { get; set; }
        public Token RefreshToken { get; set; }
    }
}

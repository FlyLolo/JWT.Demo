using System.Security.Claims;

namespace FlyLolo.JWT.Server
{
    public interface ITokenHelper
    {
        Token CreateToken(User user);

    }
}

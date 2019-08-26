using System.Security.Claims;

namespace FlyLolo.JWT.Server
{
    public interface ITokenHelper
    {
        ComplexToken CreateToken(User user);
        ComplexToken CreateToken(Claim[] claims);
        Token RefreshToken(ClaimsPrincipal claimsPrincipal);

    }
}

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlyLolo.JWT.Server.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private ITokenHelper tokenHelper = null;
        public TokenController(ITokenHelper _tokenHelper)
        {
            tokenHelper = _tokenHelper;
        }

        [HttpGet]
        public IActionResult Get(string code, string pwd)
        {
            User user = TemporaryData.GetUser(code);
            if (null != user && user.Password.Equals(pwd))
            {
                return Ok(tokenHelper.CreateToken(user));
            }
            return BadRequest();
        }

[HttpPost]
[Authorize]
public IActionResult Post()
{
    return Ok(tokenHelper.RefreshToken(Request.HttpContext.User));
}
    }
}

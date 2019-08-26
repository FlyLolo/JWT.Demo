using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlyLolo.JWT.API.Controllers.Test
{
[Route("api/[controller]")]
[Authorize]
public class BookController : Controller
{
    // GET: api/<controller>
    [HttpGet]
    [AllowAnonymous]
    public IEnumerable<string> Get()
    {
        return new string[] { "ASP", "C#" };
    }

    // POST api/<controller>
    [HttpPost]
    public JsonResult Post()
    {
        return new JsonResult("Create  Book ...");
    }
}
}

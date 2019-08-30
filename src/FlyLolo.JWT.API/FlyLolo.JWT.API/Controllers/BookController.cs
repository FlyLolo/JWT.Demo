using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlyLolo.JWT.API.Controllers.Test
{
    [Route("api/[controller]")]
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
        [Authorize]
        public JsonResult Post()
        {
            return new JsonResult("Create  Book ...");
        }

        [HttpDelete]
        //[Authorize(Policy = "TestPolicy")]
        [Authorize(Policy = "Permission")]
        public JsonResult Delete()
        {
            return new JsonResult("Delete Book ...");
        }

        /// <summary>
        /// 测试在JWT的token中添加角色，在此验证  见TokenHelper
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Authorize(Roles = "TestPutBookRole")]
        public JsonResult Put()
        {
            return new JsonResult("Put  Book ...");
        }
    }
}

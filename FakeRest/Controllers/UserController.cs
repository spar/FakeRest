using FakeRest.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;

namespace FakeRest.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        public static IEnumerable<User> Users = JsonConvert.DeserializeObject<IEnumerable<User>>(
            File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Data/UserJsonData.json")));

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            return Ok(Users);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(Users.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        public IHttpActionResult Create(User user)
        {
            if (user == null)
                return BadRequest();
            return Ok(user);
        }

        [HttpPut]
        public IHttpActionResult Update(User user)
        {
            if (user == null)
                return BadRequest();
            if (Users.Any(x => x.Id == user.Id)) return Ok(user);
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            if (Users.Any(x => x.Id == id)) return Ok("Deleted");
            return NotFound();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Search(string q)
        {
            return Ok(Users.Where(x => x.GetSearchableText().Contains(q)));
        }
    }
}

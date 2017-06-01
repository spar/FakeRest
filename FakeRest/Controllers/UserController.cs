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
        public IHttpActionResult SearchPageSort(string q = "", int page = 0, int limit = 10, string sortField = "Id", string order = "desc")
        {
            var result = Users;
            if (!string.IsNullOrEmpty(q))
                result = Users.Where(x => x.GetSearchableText().Contains(q));

            if (page > 0)
                result = result.Skip((page - 1) * limit).Take(limit);

            if (string.IsNullOrEmpty(sortField)) return Ok(result);
            var p = typeof(User).GetProperty(sortField);
            if (p != null)
            {
                result = order.ToLower() == "desc"
                    ? result.OrderByDescending(x => p.GetValue(x))
                    : result.OrderBy(x => p.GetValue(x));
            }
            return Ok(result);
        }
    }
}

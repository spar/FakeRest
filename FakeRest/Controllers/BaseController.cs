using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using FakeRest.Models;
using Newtonsoft.Json;

namespace FakeRest.Controllers
{
    public class BaseController<T> : ApiController where T : BaseClass
    {
        public static IEnumerable<T> Entities = JsonConvert.DeserializeObject<IEnumerable<T>>(
            File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Data/" + typeof(T).Name + "JsonData.json")));

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(Entities.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create(T t)
        {
            if (t == null)
                return BadRequest();
            return Ok(t);
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult Update(T t)
        {
            if (t == null)
                return BadRequest();
            if (Entities.Any(x => x.Id == t.Id)) return Ok(t);
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            if (Entities.Any(x => x.Id == id)) return Ok("Deleted");
            return NotFound();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult SearchPageSort(string q = "", int page = 0, int limit = 10, string sortField = "Id", string order = "desc")
        {
            var result = Entities;
            if (!string.IsNullOrEmpty(q))
                result = Entities.Where(x => x.GetSearchableText().Contains(q));

            if (page > 0)
                result = result.Skip((page - 1) * limit).Take(limit);

            if (string.IsNullOrEmpty(sortField)) return Ok(result);
            var p = typeof(T).GetProperty(sortField);
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

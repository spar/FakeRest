using FakeRest.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;

namespace FakeRest.Controllers
{
    [RoutePrefix("api/JeopardyQ")]
    public class JeopardyQController : ApiController
    {
        public static IEnumerable<JeopardyQ> JeopardyQs = JsonConvert.DeserializeObject<IEnumerable<JeopardyQ>>(
            File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Data/JeopardyQJsonData.json")));

        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            return Ok(JeopardyQs.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Create(JeopardyQ jeopardyQ)
        {
            if (jeopardyQ == null)
                return BadRequest();
            return Ok(jeopardyQ);
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult Update(JeopardyQ jeopardyQ)
        {
            if (jeopardyQ == null)
                return BadRequest();
            if (JeopardyQs.Any(x => x.Id == jeopardyQ.Id)) return Ok(jeopardyQ);
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            if (JeopardyQs.Any(x => x.Id == id)) return Ok("Deleted");
            return NotFound();
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult SearchPageSort(string q = "", int page = 0, int limit = 10, string sortField = "Id", string order = "desc")
        {
            var result = JeopardyQs;
            if (!string.IsNullOrEmpty(q))
                result = JeopardyQs.Where(x => x.GetSearchableText().Contains(q));

            if (page > 0)
                result = result.Skip((page - 1) * limit).Take(limit);

            if (string.IsNullOrEmpty(sortField)) return Ok(result);
            var p = typeof(JeopardyQ).GetProperty(sortField);
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

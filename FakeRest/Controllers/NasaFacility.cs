using FakeRest.Models;
using System.Web.Http;

namespace FakeRest.Controllers
{
    [RoutePrefix("api/nasafacility")]
    public class NasaFacilityController : BaseController<NasaFacility>
    {
    }
}

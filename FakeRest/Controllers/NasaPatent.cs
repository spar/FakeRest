using FakeRest.Models;
using System.Web.Http;

namespace FakeRest.Controllers
{
    [RoutePrefix("api/nasapatent")]
    public class NasaPatentController : BaseController<NasaPatent>
    {
    }
}

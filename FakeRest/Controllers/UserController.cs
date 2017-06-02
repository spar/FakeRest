using FakeRest.Models;
using System.Web.Http;

namespace FakeRest.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : BaseController<User>
    {
    }
}

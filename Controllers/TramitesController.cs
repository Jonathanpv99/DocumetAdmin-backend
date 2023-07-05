using Microsoft.AspNetCore.Mvc;

namespace TramitesAPI.Controllers
{
    public class TramitesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

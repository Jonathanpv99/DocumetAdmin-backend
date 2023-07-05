using Microsoft.AspNetCore.Mvc;

namespace TramitesAPI.Controllers
{
    public class DocumentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

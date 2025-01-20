using Microsoft.AspNetCore.Mvc;

namespace testCoreWeb.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

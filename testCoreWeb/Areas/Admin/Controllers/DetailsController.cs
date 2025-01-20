using Microsoft.AspNetCore.Mvc;

namespace testCoreWeb.Areas.Admin.Controllers
{
    public class DetailsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

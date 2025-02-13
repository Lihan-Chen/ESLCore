using Microsoft.AspNetCore.Mvc;

namespace ESL.Mvc.Controllers
{
    public class AllEventController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

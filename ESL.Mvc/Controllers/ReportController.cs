using Microsoft.AspNetCore.Mvc;

namespace ESL.Mvc.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

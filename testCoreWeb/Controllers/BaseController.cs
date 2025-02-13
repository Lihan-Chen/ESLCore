using Microsoft.AspNetCore.Mvc;

namespace testCoreWeb.Controllers
{
    public class BaseController : Controller
    {
        int FacilNo = 0;

        int ShiftNo = 1;

        string OperatorType = "Primary";



        public IActionResult Index()
        {
            return View();
        }
    }
}

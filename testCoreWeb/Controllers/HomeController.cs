using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using testCoreWeb.Models;
using testCoreWeb.ViewModels;

namespace testCoreWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new PlantViewModel();
            model.FacilNo = 1;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(PlantViewModel model)
        {
            if (ModelState.IsValid)
            {
                var msg = model.FacilNo.ToString() + " selected";
                return RedirectToAction("Privacy", new { message = msg });
            }

            // if we got this far, something failed; redisplay form.
            return View(model);
        }

        public IActionResult IndexGroup()
        {
            var model = new PlantViewModelGroup();
            model.FacilNo = 1;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult IndexGroup(PlantViewModelGroup model)
        {
            if (ModelState.IsValid)
            {
                var msg = model.FacilNo.ToString() + " selected";
                return RedirectToAction("index", new { message = msg });
            }

            // if we got this far, something failed; redisplay form.
            return View(model);
        }

        public IActionResult OperatorType()
        {
            var model = new OperatorTypeEnumViewModel();
            model.EnumOperatorType = (OperatorTypeEnum)1;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OperatorType(OperatorTypeEnumViewModel model)
        {
            if (ModelState.IsValid)
            {
                var msg = model.EnumOperatorType.ToString() + " selected";
                return RedirectToAction("Index", new { message = msg });
            }

            // if we got this far, something failed; redisplay form.
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

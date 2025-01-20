using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace testCoreWeb.Controllers
{
    public class AllEventsController : BaseController
    {
        // GET: AllEventsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AllEventsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AllEventsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AllEventsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AllEventsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AllEventsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AllEventsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AllEventsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

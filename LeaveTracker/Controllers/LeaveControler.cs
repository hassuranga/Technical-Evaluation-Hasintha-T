using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeaveTracker.Controllers
{
    public class LeaveControler : Controller
    {
        // GET: LeaveControler
        public ActionResult Index()
        {
            return View();
        }

        // GET: LeaveControler/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LeaveControler/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LeaveControler/Create
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

        // GET: LeaveControler/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LeaveControler/Edit/5
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

        // GET: LeaveControler/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LeaveControler/Delete/5
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

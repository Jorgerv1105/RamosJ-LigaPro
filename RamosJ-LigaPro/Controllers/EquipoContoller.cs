using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RamosJ_LigaPro.Controllers
{
    public class EquipoContoller : Controller
    {
        // GET: EquipoContoller
        public ActionResult Index()
        {
            return View();
        }

        // GET: EquipoContoller/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EquipoContoller/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EquipoContoller/Create
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

        // GET: EquipoContoller/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EquipoContoller/Edit/5
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

        // GET: EquipoContoller/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EquipoContoller/Delete/5
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

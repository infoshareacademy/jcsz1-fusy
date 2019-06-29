using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WalutyBusinessLogic.Models;

namespace WalutyMVCWebApp.Controllers
{
    [Authorize]
    public class FavoritesController : Controller
    {
        private readonly UserManager<User> _userManager;

        public FavoritesController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        // GET: Favorites
        public ActionResult Index()
        {
            return View();
        }

        // GET: Favorites/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Favorites/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Favorites/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Favorites/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Favorites/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Favorites/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Favorites/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
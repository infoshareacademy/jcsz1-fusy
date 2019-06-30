using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WalutyBusinessLogic.DatabaseLoading;
using WalutyBusinessLogic.LoadingFromFile;
using WalutyBusinessLogic.Models;

namespace WalutyMVCWebApp.Controllers
{
    [Authorize]
    public class FavoritesController : Controller
    {
        // Remember to create separate controller for these methods

        private readonly UserManager<User> _userManager;
        private readonly WalutyDBContext _context;

        public FavoritesController(UserManager<User> userManager, WalutyDBContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        // GET: Favorites
        public async Task<ActionResult> Index()
        {
            var loggedInUser = await _userManager.Users.Include(u => u.UserFavoriteCurrencies).SingleAsync(u => u.UserName == User.Identity.Name);

            List<Currency> currencies = _context.UsersCurrencies.Where(u => u.User.Id == loggedInUser.Id).Select(x => x.Currency).ToList();

            return View(currencies);
        }

        public async Task<ActionResult> Add(int currencyId)
        {
            var loggedInUser = await _userManager.Users.Include(u => u.UserFavoriteCurrencies).SingleAsync(u => u.UserName == User.Identity.Name);
            var favoriteCurrency = _context.Currencies.Find(currencyId);

            _context.UsersCurrencies.Add(new UserCurrency()
            {
                Currency = favoriteCurrency,
                User = loggedInUser,
            });
            
            _context.SaveChanges();

            return RedirectToAction("Index");
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
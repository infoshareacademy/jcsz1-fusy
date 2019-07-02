using Microsoft.AspNetCore.Mvc;
using WalutyBusinessLogic.LoadingFromFile;
using WalutyBusinessLogic.Services;
using WalutyBusinessLogic.Models;

namespace WalutyMVCWebApp.Controllers
{
    public class GlobalExtremeController : Controller
    {
        private readonly ExtremesServices _extremeServices;
        public GlobalExtremeController(ILoader loader)
        {
            _extremeServices = new ExtremesServices(loader);
        }

        public IActionResult FormOfGlobalExtreme()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ShowGlobaExtreme(GlobalExtremeValueModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("FormOfGlobalExtreme", model);
            }
            return View(_extremeServices.GetGlobalExtremes());
        }
    }
}
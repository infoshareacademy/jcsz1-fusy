using Microsoft.AspNetCore.Mvc;
using WalutyBusinessLogic.LoadingFromFile;
using WalutyBusinessLogic.Services;
using WalutyBusinessLogic.Models;

namespace WalutyMVCWebApp.Controllers
{
    public class ExtremeController : Controller
    {
        private readonly ExtremesServices _extremeServices;
        public ExtremeController(ILoader loader)
        {
            _extremeServices = new ExtremesServices(loader);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ShowGlobaExtreme(ExtremeValue extremeValue)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            return View(_extremeServices.GetGlobalExtremes(extremeValue));
        }

        public IActionResult LocalExtreme()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ShowLocalExtreme(ExtremeValue extremeValue)
        {
            if (!ModelState.IsValid)
            {
                return View("LocalExtreme");
            }
            return View(_extremeServices.GetLocalExtremes(extremeValue));
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using WalutyBusinessLogic.LoadingFromFile;
using WalutyBusinessLogic.Services;

namespace WalutyMVCWebApp.Controllers
{
    public class GlobalExtremeController : Controller
    {
        private readonly ExtremesServices _extremeServices;
        public GlobalExtremeController(ILoader loader)
        {
            _extremeServices = new ExtremesServices(loader);
        }

        public IActionResult ShowGlobalExtreme()
        {
            return View(_extremeServices.GetGlobalExtremes());
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using WalutyBusinessLogic.DatabaseLoading;
using WalutyBusinessLogic.Services;

namespace WalutyMVCWebApp.Controllers
{
    public class GlobalExtremeController : Controller
    {
        private readonly ExtremesServices _extremeServices;
        public GlobalExtremeController(ICurrencyRepository repository)
        {
            _extremeServices = new ExtremesServices(repository);
        }

        public IActionResult ShowGlobalExtreme()
        {
            return View(_extremeServices.GetGlobalExtremes());
        }
    }
}
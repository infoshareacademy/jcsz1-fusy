using System;
using Microsoft.AspNetCore.Mvc;
using WalutyBusinessLogic.LoadingFromFile;
using WalutyMVCWebApp.Extremes;

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
        public IActionResult GetGlobaExtreme(string currencyCode)
        {     
            return View(_extremeServices.GetGlobalExtremes(currencyCode));
        }

        public IActionResult LocalExtreme()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ShowLocalExtreme(string nameCurrency, DateTime startDate, DateTime endDate)
        {
            return View(_extremeServices.GetLocalExtremes(nameCurrency, startDate, endDate));
        }
    }
}
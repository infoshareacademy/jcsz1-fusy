using System;
using Microsoft.AspNetCore.Mvc;
using WalutyBusinessLogic.LoadingFromFile;
using WalutyBusinessLogic.Models.Extremes;

namespace WalutyBusinessLogic.Models.Controllers
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
        public IActionResult ShowGlobaExtreme(string currencyCode)
        {
            return View(_extremeServices.GetGlobalExtremes(currencyCode));
        }

        public IActionResult LocalExtreme()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ShowLocalExtreme(string currencyCode, DateTime startDate, DateTime endDate)
        {
            return View(_extremeServices.GetLocalExtremes(currencyCode, startDate.Date, endDate.Date));
        }
    }
}
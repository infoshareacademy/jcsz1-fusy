using System;
using Microsoft.AspNetCore.Mvc;
using WalutyBusinessLogic.LoadingFromFile;
using WalutyBusinessLogic.Models.Extremes;
using WalutyBusinessLogic.Models;

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
        public IActionResult ShowGlobaExtreme(ExtremeValue extremeValue)
        {
            return View(_extremeServices.GetGlobalExtremes(extremeValue));
        }

        public IActionResult LocalExtreme()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ShowLocalExtreme(ExtremeValue extremeValue)
        {
            //if (!ModelState.IsValid)
            //{
              return View(_extremeServices.GetLocalExtremes(extremeValue));
            //}
            //return View("LocalExtreme");
        }
    }
}
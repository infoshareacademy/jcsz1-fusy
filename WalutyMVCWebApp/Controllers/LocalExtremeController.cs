using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WalutyBusinessLogic.LoadingFromFile;
using WalutyBusinessLogic.Models;
using WalutyBusinessLogic.Services;

namespace WalutyMVCWebApp.Controllers
{
    public class LocalExtremeController : Controller
    {
        private readonly ExtremesServices _extremeServices;
        private readonly DateChecker _dateChecker;
        private readonly DateRange _dateRange;
        public LocalExtremeController(ILoader loader)
        {
            _extremeServices = new ExtremesServices(loader);
            _dateChecker = new DateChecker();
            _dateRange = new DateRange(loader);
        }

        public IActionResult FormOfLocalExtreme()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ShowLocalExtreme(LocalExtremeValueModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("FormOfLocalExtreme", model);
            }
            if (!_dateChecker.CheckingIfDateExists(model.EndDate, model.NameCurrency )
                || !_dateChecker.CheckingIfDateExists(model.StartDate, model.NameCurrency))
            {
                ViewBag.DateRangeForLocalExtreme = _dateRange.GetDateRangeCurrency(model.NameCurrency);

                return View("FormOfLocalExtreme", model);
            }
            return View(_extremeServices.GetLocalExtremes(model));
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using WalutyBusinessLogic.DatabaseLoading;
using WalutyBusinessLogic.Models;
using WalutyBusinessLogic.Services;
using System.Threading.Tasks;

namespace WalutyMVCWebApp.Controllers
{
    public class LocalExtremeController : Controller
    {
        private readonly ExtremesServices _extremeServices;
        private readonly DateChecker _dateChecker;
        private readonly DateRange _dateRange;
        public LocalExtremeController(ICurrencyRepository repository)
        {
            _extremeServices = new ExtremesServices(repository);
            _dateChecker = new DateChecker(repository);
            _dateRange = new DateRange(repository);
        }

        public IActionResult FormOfLocalExtreme()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ShowLocalExtreme(LocalExtremeValueModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("FormOfLocalExtreme", model);
            }
            bool ResultCheckingIfDateExistInRange = await _dateChecker
                .CheckingIfDateExistInRange(model.StartDate, model.EndDate, model.NameCurrency);
            if (!ResultCheckingIfDateExistInRange)
            {
                ViewBag.DateRangeForLocalExtreme = _dateRange.GetDateRangeCurrency(model.NameCurrency);

                return View("FormOfLocalExtreme", model);
            }
            return View(_extremeServices.GetLocalExtremes(model));
        }
    }
}
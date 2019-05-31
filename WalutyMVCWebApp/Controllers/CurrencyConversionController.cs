using Microsoft.AspNetCore.Mvc;
using WalutyBusinessLogic.LoadingFromFile;
using WalutyBusinessLogic.Models;
using WalutyBusinessLogic.Services;

namespace WalutyMVCWebApp.Controllers
{
    public class CurrencyConversionController : Controller
    {
        private readonly CurrencyConversionService _currencyConversionService;
        private readonly DateChecker _dateChecker;
        private readonly DateRange _dateRange;
        public CurrencyConversionController(ILoader loader)
        {
            _currencyConversionService = new CurrencyConversionService(loader);
            _dateChecker = new DateChecker();
            _dateRange = new DateRange(loader);
        }

        public IActionResult CurrencyConversionOfForm()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ShowResultCurrencyConversion(CurrencyConversionModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("CurrencyConversionOfForm", model);
            }
            if (!_dateChecker.CheckingIfDateExistsForTwoCurrencies(model.Date, model.FirstCurrency, model.SecondCurrency))
            {
                ViewBag.DateRangeForConversion = _dateRange.GetDateRangeTwoCurrencies(model.FirstCurrency, model.SecondCurrency);

                return View("CurrencyConversionOfForm", model);
            }
            return View(_currencyConversionService.CalculateAmountForCurrencyConversion(model));
        }
    }
}
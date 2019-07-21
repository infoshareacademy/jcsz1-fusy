using Microsoft.AspNetCore.Mvc;
using WalutyBusinessLogic.DatabaseLoading;
using WalutyBusinessLogic.Models;
using WalutyBusinessLogic.Services;
using System.Threading.Tasks;

namespace WalutyMVCWebApp.Controllers
{
    public class CurrencyConversionController : Controller
    {
        private readonly CurrencyConversionService _currencyConversionService;
        private readonly DateChecker _dateChecker;
        private readonly DateRange _dateRange;
        private readonly CurrencyNameChecker _currencyNameChecker;
        public CurrencyConversionController(ICurrencyRepository repository)
        {
            _currencyConversionService = new CurrencyConversionService(repository);
            _dateChecker = new DateChecker(repository);
            _dateRange = new DateRange(repository);
            _currencyNameChecker = new CurrencyNameChecker();
        }

        public IActionResult FormOfCurrencyConversion()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ShowResultCurrencyConversion(CurrencyConversionModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("FormOfCurrencyConversion", model);
            }
            if (!_currencyNameChecker.CheckingIfCurrencyNamesAreDifferent(model.FirstCurrency, model.SecondCurrency))
            {
                ViewBag.ResultChekingCurrencyNameInConversion = "Currencies name must different";
                return View("FormOfCurrencyConversion", model);
            }
            bool ResultCheckingDateForTwoCurrencies = await _dateChecker
                .CheckingIfDateExistsForTwoCurrencies(model.Date, model.FirstCurrency, model.SecondCurrency);
             if (!ResultCheckingDateForTwoCurrencies)
            {
                ViewBag.DateRangeForConversion = _dateRange.GetDateRangeTwoCurrencies(model.FirstCurrency, model.SecondCurrency);

                return View("FormOfCurrencyConversion", model);
            }
            return View(_currencyConversionService.CalculateAmountForCurrencyConversion(model));
        }
    }
}
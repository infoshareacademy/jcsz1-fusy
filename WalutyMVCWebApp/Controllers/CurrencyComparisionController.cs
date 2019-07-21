using Microsoft.AspNetCore.Mvc;
using WalutyBusinessLogic.Models;
using WalutyBusinessLogic.CurrenciesComparision;
using WalutyBusinessLogic.DatabaseLoading;
using WalutyBusinessLogic.Services;
using System.Threading.Tasks;

namespace WalutyMVCWebApp.Controllers
{
    public class CurrencyComparisionController : Controller
    {
        private readonly CurrenciesComparator _currenciesComparator;
        private readonly DateChecker _dateChecker;
        private readonly DateRange _dateRange;
        private readonly CurrencyNameChecker _currencyNameChecker;

        public CurrencyComparisionController(ICurrencyRepository repository)
        {
            _currenciesComparator = new CurrenciesComparator(repository);
            _dateChecker = new DateChecker(repository);
            _dateRange = new DateRange(repository);
            _currencyNameChecker = new CurrencyNameChecker();
        }

        public IActionResult FormOfCurrencyComparator()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ShowResultCurrencyComparision(CurrenciesComparatorModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("FormOfCurrencyComparator", model);
            }
            if (!_currencyNameChecker.CheckingIfCurrencyNamesAreDifferent(model.FirstCurrencyCode, model.SecondCurrencyCode))
            {
                ViewBag.ResultChekingCurrencyNameInComparision = "Currencies name must different";
                return View("FormOfCurrencyComparator", model);
            }
            bool ResultCheckingIfDateExistsForTwoCurrencies = await _dateChecker
                .CheckingIfDateExistsForTwoCurrencies(model.Date, model.FirstCurrencyCode, model.SecondCurrencyCode);
            if (!ResultCheckingIfDateExistsForTwoCurrencies)
            {
                ViewBag.DateRangeForComparison = _dateRange.GetDateRangeTwoCurrencies(model.FirstCurrencyCode, model.SecondCurrencyCode);
                
                return View("FormOfCurrencyComparator", model);
            }
            return View(_currenciesComparator.CompareCurrencies(model));
        }
    }
}
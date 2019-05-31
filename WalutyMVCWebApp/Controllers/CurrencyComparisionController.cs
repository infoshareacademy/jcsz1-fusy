using Microsoft.AspNetCore.Mvc;
using WalutyBusinessLogic.Models;
using WalutyBusinessLogic.CurrenciesComparision;
using WalutyBusinessLogic.LoadingFromFile;
using WalutyBusinessLogic.Services;

namespace WalutyMVCWebApp.Controllers
{
    public class CurrencyComparisionController : Controller
    {
        private readonly CurrenciesComparator _currenciesComparator;
        private readonly DateChecker _dateChecker;
        private readonly DateRange _dateRange;

        public CurrencyComparisionController(ILoader loader)
        {
            _currenciesComparator = new CurrenciesComparator(loader);
            _dateChecker = new DateChecker();
            _dateRange = new DateRange(loader);
        }

        public IActionResult CurrencyComparatorOfForm()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ShowResultCurrencyComparision(CurrenciesComparatorModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("CurrencyComparatorOfForm", model);
            }
            if (!_dateChecker.CheckingIfDateExistsForTwoCurrencies(model.Date, model.FirstCurrencyCode, model.SecondCurrencyCode))
            {
                ViewBag.DateRangeForComparison = _dateRange.GetDateRangeTwoCurrencies(model.FirstCurrencyCode, model.SecondCurrencyCode);
                
                return View("CurrencyComparatorOfForm", model);
            }
            return View(_currenciesComparator.CompareCurrencies(model));
        }
    }
}
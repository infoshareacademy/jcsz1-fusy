using Microsoft.AspNetCore.Mvc;
using WalutyBusinessLogic.LoadingFromFile;
using WalutyBusinessLogic.Models;
using WalutyBusinessLogic.Services;

namespace WalutyMVCWebApp.Controllers
{
    public class CurrencyConversionController : Controller
    {
        private readonly CurrencyConversionService _currencyConversionService;
        public CurrencyConversionController(ILoader loader)
        {
            _currencyConversionService = new CurrencyConversionService(loader);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ShowResultCurrencyConversion(CurrencyConversionModel currencyConversionModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            return View(_currencyConversionService.CalculateAmountForCurrencyConversion(currencyConversionModel));
        }
    }
}
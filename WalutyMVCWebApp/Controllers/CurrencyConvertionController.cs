using Microsoft.AspNetCore.Mvc;
using WalutyBusinessLogic.LoadingFromFile;
using WalutyMVCWebApp.Services;
using System;

namespace WalutyMVCWebApp.Controllers
{
    public class CurrencyConvertionController : Controller
    {
        private readonly CurrencyConvertionService _currencyConvertionService;
        public CurrencyConvertionController(ILoader loader)
        {
            _currencyConvertionService = new CurrencyConvertionService(loader);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ShowResultCurrencyConvertion(DateTime dateCurrency, 
        string firstCurrency, string secondCurrency, float amountFirstCurrency)
        {
            return View(_currencyConvertionService.CalculateAmountForCurrencyConvertion(dateCurrency, firstCurrency, secondCurrency, amountFirstCurrency));
        }
    }
}
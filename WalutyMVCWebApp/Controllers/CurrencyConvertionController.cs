using Microsoft.AspNetCore.Mvc;
using System;
using WalutyBusinessLogic.LoadingFromFile;
using WalutyBusinessLogic.Models.Services;

namespace WalutyBusinessLogic.Models.Controllers
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
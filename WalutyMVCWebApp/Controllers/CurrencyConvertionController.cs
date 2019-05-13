using Microsoft.AspNetCore.Mvc;
using WalutyBusinessLogic.LoadingFromFile;
using WalutyBusinessLogic.Models.Services;
using System;

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
        public IActionResult ShowResultCurrencyConvertion(CurrencyConvertionModel currencyConvertionModel)
        {
            return View(_currencyConvertionService.CalculateAmountForCurrencyConvertion(currencyConvertionModel));
        }
    }
}
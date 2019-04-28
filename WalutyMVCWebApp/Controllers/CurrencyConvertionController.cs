using System;
using Microsoft.AspNetCore.Mvc;
using WalutyBusinessLogic.LoadingFromFile;
using WalutyMVCWebApp.Services;
using WalutyMVCWebApp.Models;

namespace WalutyMVCWebApp.Controllers
{
    public class CurrencyConvertionController : Controller
    {
        private readonly CurrencyConvertionServices _currencyConvertion;
        private readonly ILoader loader;

        //public CurrencyConvertionController(CurrencyConvertionServices currencyConvertionService)
        //{
        //    _currencyConvertion = currencyConvertionService;

        //}


        public IActionResult Index()
        {
            var currencyConvertionModel = new CurrencyConvertionModel();
            return View();
        }

        //[HttpPost]
        //public IActionResult ShowResultCurrencyConvertion(ILoader loader, CurrencyConvertionModel currencyConvertionModel)
        //{
        //    var g = new CurrencyConvertionServices(loader,currencyConvertionModel.FirstCurrency, currencyConvertionModel.SecondCurrency);
            
        //    return View(g.CalculateAmountForCurrencyConvertion(currencyConvertionModel.AmountFirstCurrency, currencyConvertionModel.Date));
        //}
    }
}
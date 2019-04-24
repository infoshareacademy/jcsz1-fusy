using System;
using Microsoft.AspNetCore.Mvc;
using WalutyBusinessLogic.LoadingFromFile;
using WalutyMVCWebApp.Services;
namespace WalutyMVCWebApp.Controllers
{
    public class CurrencyConvertionController : Controller
    {
        private readonly CurrencyConvertionServices _currencyConvertion;

        public CurrencyConvertionController(ILoader loader, string  firstNameCurrency, string secondNameCurrency)
        {
            _currencyConvertion = new CurrencyConvertionServices(loader, firstNameCurrency, secondNameCurrency);
        }

        public IActionResult Index(float amountFirstCurrency, int dateCurrency)
        {
            return View();//_currencyConvertion.CalculateAmountForCurrencyConvertion( amountFirstCurrency,  dateCurrency));
        }
    }
}
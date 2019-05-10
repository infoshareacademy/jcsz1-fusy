using Microsoft.AspNetCore.Mvc;
using WalutyBusinessLogic.LoadingFromFile;
using WalutyMVCWebApp.Services;
using WalutyMVCWebApp.Models;

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
        public IActionResult ShowResultCurrencyConvertion(ILoader loader, CurrencyConvertionModel currencyConvertionModel)
        {
            return View(_currencyConvertionService.CalculateAmountForCurrencyConvertion(currencyConvertionModel));
        }
    }
}
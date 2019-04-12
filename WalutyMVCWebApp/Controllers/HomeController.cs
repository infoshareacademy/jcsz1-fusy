using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WalutyBusinessLogic.LoadingFromFile;
using WalutyMVCWebApp.Models;

namespace WalutyMVCWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILoader _loader;

        public HomeController(ILoader loader)
        {
            _loader = loader;
        }
        public IActionResult Index()
        {
            var listOfAllCurrencies = _loader.AllCurrencies;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

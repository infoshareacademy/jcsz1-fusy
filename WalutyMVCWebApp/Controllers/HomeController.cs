using System;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using WalutyBusinessLogic.LoadingFromFile;
using WalutyMVCWebApp.Models;
using X.PagedList;

namespace WalutyMVCWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILoader _loader;
        private int _pageSize = 5;

        public HomeController(ILoader loader)
        {
            _loader = loader;
        }
        public IActionResult Index(int? page, string searchString)
        {
            int pageNumber = page ?? 1;
            IPagedList<CurrencyInfo> listOfResults = null;

            if (!String.IsNullOrWhiteSpace(searchString))
            {
                ViewBag.searchFilter = searchString;
            }

            if (ViewBag.searchFilter != null)
            {
                listOfResults = _loader.LoadCurrencyInformation().Where(x => x.Code.Contains(ViewBag.searchFilter)).ToPagedList(pageNumber, _pageSize);
            }
            else
            {
                listOfResults = _loader.LoadCurrencyInformation().ToPagedList(pageNumber, _pageSize);
            }
           
            ViewBag.SinglePageOfCurrencyInfo = listOfResults;

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

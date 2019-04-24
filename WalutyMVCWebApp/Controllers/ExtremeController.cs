using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WalutyMVCWebApp.Controllers
{
    public class ExtremeController : Controller
    {
        public IActionResult Index()
        {
            return View("Default action");
        }
    }
}
using System;
using WalutyMVCWebApp.Models;

namespace WalutyMVCWebApp.Services
{
    public interface IExtremeService
    {
         ExtremeValue GetGlobalExtremes(string nameCurrency);
         ExtremeValue GetLocalExtremes(string nameCurrency, DateTime startDate, DateTime endDate);
    }
}

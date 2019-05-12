using System;
using WalutyBusinessLogic.Models;

namespace WalutyBusinessLogic.Models.Services
{
    public interface IExtremeService
    {
         ExtremeValue GetGlobalExtremes(string nameCurrency);
         ExtremeValue GetLocalExtremes(string nameCurrency, DateTime startDate, DateTime endDate);
    }
}

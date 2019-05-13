using System;
using WalutyBusinessLogic.Models;

namespace WalutyBusinessLogic.Models.Services
{
    public interface IExtremeService
    {
         ExtremeValue GetGlobalExtremes(ExtremeValue extremeValue);
         ExtremeValue GetLocalExtremes(ExtremeValue extremeValue);
    }
}

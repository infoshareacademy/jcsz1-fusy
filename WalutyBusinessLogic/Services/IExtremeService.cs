using WalutyBusinessLogic.Models;

namespace WalutyBusinessLogic.Services
{
    public interface IExtremeService
    {
         ExtremeValue GetGlobalExtremes(ExtremeValue extremeValue);
         ExtremeValue GetLocalExtremes(ExtremeValue extremeValue);
    }
}

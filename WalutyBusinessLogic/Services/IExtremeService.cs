using WalutyBusinessLogic.Models;

namespace WalutyBusinessLogic.Services
{
    public interface IExtremeService
    {
         GlobalExtremeValueModel GetGlobalExtremes(GlobalExtremeValueModel extremeValue);
         LocalExtremeValueModel GetLocalExtremes(LocalExtremeValueModel extremeValue);
    }
}

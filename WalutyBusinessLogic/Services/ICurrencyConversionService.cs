using WalutyBusinessLogic.Models;
using System.Threading.Tasks;

namespace WalutyBusinessLogic.Services
{
    public interface ICurrencyConversionServices
    {
        Task<CurrencyConversionModel> CalculateAmountForCurrencyConversion(CurrencyConversionModel currencyConversionModel);
    }
}

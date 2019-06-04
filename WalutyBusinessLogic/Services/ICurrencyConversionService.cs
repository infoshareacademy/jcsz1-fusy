using WalutyBusinessLogic.Models;

namespace WalutyBusinessLogic.Services
{
    public interface ICurrencyConversionServices
    {
        CurrencyConversionModel CalculateAmountForCurrencyConversion(CurrencyConversionModel currencyConversionModel);
    }
}

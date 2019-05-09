using System.Collections.Generic;
using WalutyBusinessLogic.LoadingFromFile;

namespace WalutyBusinessLogic.DatabaseLoading
{
    public interface ICurrencyRepository
    {
        List<Currency> GetAllCurrencies();
        List<CurrencyInfo> GetAllCurrencyInfo();
        Currency GetCurrency(string currencyCode);
        
    }
}

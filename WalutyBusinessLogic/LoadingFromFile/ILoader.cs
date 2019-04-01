using System.Collections.Generic;

namespace WalutyBusinessLogic.LoadingFromFile
{
    public interface ILoader
    {
        Currency LoadCurrencyFromFile(string fileName);
        List<Currency> GetListOfAllCurrencies();
        List<string> GetAvailableTxtFileNames();
    }
}

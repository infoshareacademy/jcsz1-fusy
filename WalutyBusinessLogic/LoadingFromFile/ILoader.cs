using System;
using System.Collections.Generic;
using System.Text;

namespace WalutyBusinessLogic.LoadingFromFile
{
    interface ILoader
    {
        Currency LoadCurrencyFromFile(string fileName);
        List<Currency> GetListOfAllCurrencies();
        List<string> GetAvailableTxtFileNames();
    }
}

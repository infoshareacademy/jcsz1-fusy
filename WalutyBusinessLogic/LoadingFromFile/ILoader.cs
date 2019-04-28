using System.Collections.Generic;

namespace WalutyBusinessLogic.LoadingFromFile
{
    public interface ILoader
    {
        /// <summary>
        /// This method should not be called manually.
        /// </summary>
        //TODO: Maybe find a way to generate a warning when user tries to use this method somewhere? 
        void Init();
        List<Currency> AllCurrencies { get; set; }
        Currency LoadCurrencyFromFile(string fileName);
        List<CurrencyInfo> LoadCurrencyInformation();
        List<Currency> GetListOfAllCurrencies();
        List<string> GetAvailableTxtFileNames();
    }
}

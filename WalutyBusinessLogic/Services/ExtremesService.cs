using System.Collections.Generic;
using System.Linq;
using WalutyBusinessLogic.LoadingFromFile;
using WalutyBusinessLogic.Models;

namespace WalutyBusinessLogic.Services
{
    public class ExtremesServices : IExtremeService
    {
        private readonly ILoader _loader;

        public ExtremesServices(ILoader loader)
        {
            _loader = loader;
        }

        public ExtremeValue GetGlobalExtremes(ExtremeValue extremeValue)
        {
            List<CurrencyRecord> ListOfRecords = GetCurrencyList(extremeValue.NameCurrency);
            extremeValue.MaxValue = ListOfRecords.Max(c => c.High);
            extremeValue.MinValue = ListOfRecords.Min(c => c.Low);
            return extremeValue;
        }

        public ExtremeValue GetLocalExtremes(ExtremeValue extremeValue)
        {
            List<CurrencyRecord> ListOfRecords = GetCurrencyList(extremeValue.NameCurrency);
            extremeValue.MaxValue = ListOfRecords.Where
                (c => c.Date >= extremeValue.StartDate && c.Date <= extremeValue.EndDate)
                .Max(c => c.High);
            extremeValue.MinValue = ListOfRecords.Where
                (c => c.Date >= extremeValue.StartDate && c.Date <= extremeValue.EndDate)
                .Min(c => c.Low);
            return extremeValue;
        }

        private List<CurrencyRecord> GetCurrencyList(string codeCurrency)
        {
            codeCurrency += ".txt";
            Currency currency = _loader.LoadCurrencyFromFile(codeCurrency);
            List<CurrencyRecord> listOfRecords = currency.ListOfRecords;
            return listOfRecords;
        }
    }
}

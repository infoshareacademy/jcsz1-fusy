using System;
using System.Collections.Generic;
using System.Linq;
using WalutyBusinessLogic.LoadingFromFile;
using WalutyBusinessLogic.Models.Services;

namespace WalutyBusinessLogic.Models.Extremes
{
    public class ExtremesServices : IExtremeService
    {
        private readonly ILoader _loader;

        public ExtremesServices(ILoader loader)
        {
            _loader = loader;
        }

        public ExtremeValue GetGlobalExtremes(string nameCurrency)
        {
            ExtremeValue extremeValue = new ExtremeValue();
            extremeValue.NameCurrency = nameCurrency;
            nameCurrency += ".txt";
            Currency currency = _loader.LoadCurrencyFromFile(nameCurrency);
            List<CurrencyRecord> listOfRecords = currency.ListOfRecords;
            extremeValue.MaxValue = listOfRecords.Max(c => c.High);
            extremeValue.MinValue = listOfRecords.Min(c => c.Low);
            return extremeValue;
        }

        public ExtremeValue GetLocalExtremes(string nameCurrency, DateTime startDate, DateTime endDate)
        {
            ExtremeValue extremeValue = new ExtremeValue();
            extremeValue.NameCurrency = nameCurrency;
            nameCurrency += ".txt";
            extremeValue.StartDate = startDate;
            extremeValue.EndDate = endDate;
            Currency currency = _loader.LoadCurrencyFromFile(nameCurrency);
            List<CurrencyRecord> listOfRecords = currency.ListOfRecords;
            extremeValue.MaxValue = listOfRecords.Where(c => c.Date >= startDate && c.Date <= endDate)
                .Max(c => c.High);
            extremeValue.MinValue = listOfRecords.Where(c => c.Date >= startDate && c.Date <= endDate)
                .Min(c => c.Low);
            return extremeValue;
        }
    }
}

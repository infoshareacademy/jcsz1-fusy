﻿using System.Collections.Generic;
using System.Linq;
using WalutyBusinessLogic.LoadingFromFile;
using WalutyBusinessLogic.Models;

namespace WalutyBusinessLogic.Services
{
    public class ExtremesServices
    {
        private readonly ILoader _loader;

        public ExtremesServices(ILoader loader)
        {
            _loader = loader;
        }

        public List<string> GetGlobalExtremes()
        {
            List<string> AllGlobalExtremeValuesList = new List<string>();
            List<Currency> AllCurrenciesList = _loader.GetListOfAllCurrencies();
            foreach (var currency in AllCurrenciesList)
            {
                GlobalExtremeValueModel extremeValue = new GlobalExtremeValueModel();
                List<CurrencyRecord> ListOfRecords = GetCurrencyList(currency.Name);
                extremeValue.NameCurrency = currency.Name;
                extremeValue.MaxValue = ListOfRecords.Max(c => c.High);
                extremeValue.MinValue = ListOfRecords.Min(c => c.Low);
                string ExtremeValueResult = $"For {extremeValue.NameCurrency}: \n " +
                    $"-Max value is{extremeValue.MaxValue}, \n  -Min value is {extremeValue.MinValue}";
                AllGlobalExtremeValuesList.Add(ExtremeValueResult);
            }
            return AllGlobalExtremeValuesList;
        }

        public LocalExtremeValueModel GetLocalExtremes(LocalExtremeValueModel extremeValue)
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

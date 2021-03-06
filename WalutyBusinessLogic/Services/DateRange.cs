﻿using System;
using System.Collections.Generic;
using System.Linq;
using WalutyBusinessLogic.LoadingFromFile;

namespace WalutyBusinessLogic.Services
{
    public class DateRange
    {
        private readonly ILoader _loader;
        public DateRange(ILoader loader)
        {
            _loader = loader;
        }
        public string GetDateRangeCurrency(string currencyCode)
        {
            List<CurrencyRecord> listOfRecords = GetCurrencyList(currencyCode);
            DateTime FirstDateCurrency = listOfRecords.FirstOrDefault().Date;
            DateTime LastDateCurrency= listOfRecords.LastOrDefault().Date;
            string dateRangeResult = $"{currencyCode} exist in this app from {FirstDateCurrency.ToShortDateString()} " +
                $"to {LastDateCurrency.ToShortDateString()}. Without weekends and holidays";

            return dateRangeResult;
        }

        public string GetDateRangeTwoCurrencies(string firstCurrencyCode, string secondCurrencyCode)
        {
            List<CurrencyRecord> FirstListOfRecords = GetCurrencyList(firstCurrencyCode);
            DateTime FirstDateOfFirstCurrency = FirstListOfRecords.FirstOrDefault().Date;
            DateTime LastDateOfFirstCurrency = FirstListOfRecords.LastOrDefault().Date;
            List<CurrencyRecord> SecondListOfRecords = GetCurrencyList(secondCurrencyCode);
            DateTime FirstDateOfSecondCurrency = SecondListOfRecords.FirstOrDefault().Date;
            DateTime LastDateOfSecondCurrency = SecondListOfRecords.LastOrDefault().Date;
            DateTime FirstCommonDate = GetBiggerDate(FirstDateOfSecondCurrency, FirstDateOfFirstCurrency);
            DateTime LastCommonDate = GetLowerDate(LastDateOfFirstCurrency, LastDateOfSecondCurrency);
            string dateRangeResult = $"Date common for {firstCurrencyCode} and {secondCurrencyCode} " +
                $"exist in this app is from {FirstCommonDate.ToShortDateString()} to {LastCommonDate.ToShortDateString()}"
                + ". Without weekends and holidays";
            return dateRangeResult;
        }

        private DateTime GetBiggerDate(DateTime firstDate, DateTime secondDate)
        {
            if (firstDate > secondDate) return firstDate;
            else return secondDate;
        }

        private DateTime GetLowerDate(DateTime firstDate, DateTime secondDate)
        {
            if (firstDate > secondDate) return firstDate;
            else return secondDate;
        }

        private List<CurrencyRecord> GetCurrencyList(string currencyCode)
        {
            currencyCode += ".txt";
            Currency currency = _loader.LoadCurrencyFromFile(currencyCode);
            List<CurrencyRecord> listOfRecords = currency.ListOfRecords;
            return listOfRecords;
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalutyBusinessLogic.DatabaseLoading;
using WalutyBusinessLogic.LoadingFromFile;

namespace WalutyBusinessLogic.Services
{
    public class DateRange
    {
        private readonly ICurrencyRepository _repository;
        public DateRange(ICurrencyRepository repository)
        {
            _repository = repository;
        }
        public async Task<string> GetDateRangeCurrency(string currencyCode)
        {
            List<CurrencyRecord> listOfRecords = await GetCurrencyList(currencyCode);
            DateTime FirstDateCurrency = listOfRecords.FirstOrDefault().Date;
            DateTime LastDateCurrency= listOfRecords.LastOrDefault().Date;
            string dateRangeResult = $"{currencyCode} exist in this app from {FirstDateCurrency.ToShortDateString()} " +
                $"to {LastDateCurrency.ToShortDateString()}. Without weekends and holidays";

            return dateRangeResult;
        }

        public async Task<string> GetDateRangeTwoCurrencies(string firstCurrencyCode, string secondCurrencyCode)
        {
            List<CurrencyRecord> FirstListOfRecords = await GetCurrencyList(firstCurrencyCode);
            DateTime FirstDateOfFirstCurrency = FirstListOfRecords.FirstOrDefault().Date;
            DateTime LastDateOfFirstCurrency = FirstListOfRecords.LastOrDefault().Date;
            List<CurrencyRecord> SecondListOfRecords = await GetCurrencyList(secondCurrencyCode);
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

        private async Task<List<CurrencyRecord>> GetCurrencyList(string currencyCode)
        {
            currencyCode += ".txt";
            Currency currency = await _repository.GetCurrency(currencyCode);
            List<CurrencyRecord> listOfRecords = currency.ListOfRecords;
            return listOfRecords;
        }
    }
}

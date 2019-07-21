﻿using System;
using System.Collections.Generic;
using WalutyBusinessLogic.LoadingFromFile;
using System.Linq;

namespace WalutyBusinessLogic.Services
{
    public class DateChecker : IDateChecker
    {
        public bool CheckingIfDateExistsForTwoCurrencies(DateTime dateCurrency, string firstNameCurrency,
            string secondNameCurrency)
        {
            List<CurrencyRecord> FirstCurrencyRecordList = GetRecordDateList(firstNameCurrency);
            List<CurrencyRecord> SecondCurrencyRecordList = GetRecordDateList(secondNameCurrency);
            if ((FirstCurrencyRecordList.Any(c => c.Date == dateCurrency))
            && (SecondCurrencyRecordList.Any(c => c.Date == dateCurrency)))
            {
                return true;
            }
            else return false;
        }

        public bool CheckingIfDateExistInRange(DateTime firstDate, DateTime secondDate, string currencyName)
        {
            List<CurrencyRecord> CurrencyRecordList = GetRecordDateList(currencyName);
            if (CurrencyRecordList.Exists(c => c.Date >= firstDate) &&
                CurrencyRecordList.Exists(c => c.Date <= secondDate))
            {
                if (!CurrencyRecordList.Where(c => c.Date >= firstDate && c.Date <= secondDate).Any())
                {
                    return false;
                }
                return true;
            }
            else return false;
        }

        private List<CurrencyRecord> GetRecordDateList(string nameCurrency)
        {
            Loader loader = new Loader();
            nameCurrency += ".txt";
            Currency currency = loader.LoadCurrencyFromFile(nameCurrency);
            List<CurrencyRecord> CurrencyDateList = currency.ListOfRecords;
            return CurrencyDateList;
        }
    }
}


using System;
using System.Collections.Generic;
using System.Text;

namespace WalutyBusinessLogic.Services
{
    public class CurrencyNameChecker
    {
        public bool CheckingIfCurrenciesIsDifferent(string firstCurrencyName, string secondCurrencyName)
        {
            if (firstCurrencyName != secondCurrencyName) return true;
            else return false;
        }
    }
}

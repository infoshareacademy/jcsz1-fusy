﻿namespace WalutyBusinessLogic.Services
{
    public class CurrencyNameChecker
    {
        public bool CheckingIfCurrencyNamesAreDifferent(string firstCurrencyName, string secondCurrencyName)
        {
            if (firstCurrencyName != secondCurrencyName) return true;
            else return false;
        }
    }
}

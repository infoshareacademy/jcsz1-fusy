using System;
using WalutyBusinessLogic.Models;

namespace WalutyMVCWebApp.Services
{
    interface ICurrencyConvertionServices
    {
        CurrencyConvertionModel CalculateAmountForCurrencyConvertion(DateTime date,
            string firstCurrency, string secondCurrency, float amountFirstCurrency);
    }
}

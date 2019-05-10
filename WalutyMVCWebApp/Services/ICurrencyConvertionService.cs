using System;
using WalutyMVCWebApp.Models;

namespace WalutyMVCWebApp.Services
{
    interface ICurrencyConvertionServices
    {
        string FirstNameCurrency { get; set; }
        string SecondNameCurrency { get; set; }
        float CalculateAmountForCurrencyConvertion(CurrencyConvertionModel currencyConvertionModel);
    }
}

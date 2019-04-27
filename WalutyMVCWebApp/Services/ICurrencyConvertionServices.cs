using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalutyBusinessLogic.LoadingFromFile;

namespace WalutyMVCWebApp.Services
{
    interface ICurrencyConvertionServices
    {
        string FirstNameCurrency { get; set; }
        string SecondNameCurrency { get; set; }
        float CalculateAmountForCurrencyConvertion(float amountFirstCurrency, int date);
    }
}

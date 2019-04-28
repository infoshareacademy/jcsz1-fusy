using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalutyBusinessLogic.LoadingFromFile;

namespace WalutyMVCWebApp.Services
{
    interface IDateChecker
    {
        int? CheckeDateForCurrency(int dateCurrency, string nameCurrency);
        int? CheckDateForTwoCurrencies(int dateCurrency, string firstNameCurrency,
           string secondNameCurrency);
    }
}

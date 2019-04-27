using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalutyBusinessLogic.LoadingFromFile;

namespace WalutyMVCWebApp.Services
{
    interface IDateChecker
    {
        int SetCorrectDateForCurrency(int dateCurrency, string nameCurrency);
        int SetCorrectDateForTwoCurrencies(int dateCurrency, string firstNameCurrency, string secondNameCurrency);
    }
}

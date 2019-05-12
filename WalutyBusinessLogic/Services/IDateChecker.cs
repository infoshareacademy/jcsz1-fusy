using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalutyBusinessLogic.LoadingFromFile;

namespace WalutyBusinessLogic.Models.Services
{
    public interface IDateChecker
    {
        DateTime? CheckeDateForCurrency(DateTime dateCurrency, string nameCurrency);
        DateTime? CheckDateForTwoCurrencies(DateTime dateCurrency, string firstNameCurrency,
           string secondNameCurrency);
    }
}

using System;

namespace WalutyBusinessLogic.Services
{
    public interface IDateChecker
    {
        DateTime? CheckeDateForCurrency(DateTime dateCurrency, string nameCurrency);
        DateTime? CheckDateForTwoCurrencies(DateTime dateCurrency, string firstNameCurrency,
           string secondNameCurrency);
    }
}

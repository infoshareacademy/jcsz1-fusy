using System;

namespace WalutyBusinessLogic.Services
{
    public interface IDateChecker
    {
        bool CheckingIfDateExists(DateTime dateCurrency, string nameCurrency);
        bool CheckingIfDateExistsForTwoCurrencies(DateTime dateCurrency, string firstNameCurrency,
           string secondNameCurrency);
    }
}

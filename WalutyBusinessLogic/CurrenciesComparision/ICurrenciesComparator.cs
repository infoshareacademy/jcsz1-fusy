using System;
using WalutyBusinessLogic.Models;

namespace WalutyBusinessLogic.CurrenciesComparision
{
    public interface ICurrenciesComparator
    {
        string FileExtension { get; set; }
        CurrenciesComparatorModel CompareCurrencies(CurrenciesComparatorModel model);
    }
}

using System;
using System.Collections.Generic;
using WalutyBusinessLogic.LoadingFromFile;
using X.PagedList;

namespace WalutyBusinessLogic.DatabaseLoading
{
    public interface ICurrencyRepository
    {
        List<Currency> GetAllCurrencies();
        IPagedList<Currency> GetAllCurrencies(int pageSize, int pageNumber);
        IPagedList<Currency> GetAllCurrencies(int pageSize, int pageNumber, string filter);
        List<CurrencyInfo> GetAllCurrencyInfo();
        IPagedList<CurrencyInfo> GetAllCurrencyInfo(int pageSize, int pageNumber);
        IPagedList<CurrencyInfo> GetAllCurrencyInfo(int pageSize, int pageNumber, string filter);
        Currency GetCurrency(string currencyCode);
        List<CurrencyRecord> GetCurrencyRecordsBtwnDates(string currencyCode, DateTime begDate, DateTime endDate);
    }
}

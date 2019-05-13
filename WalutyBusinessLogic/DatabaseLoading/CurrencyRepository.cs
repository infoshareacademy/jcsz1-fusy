using System;
using System.Collections.Generic;
using System.Linq;
using WalutyBusinessLogic.DatabaseLoading;
using X.PagedList;

namespace WalutyBusinessLogic.LoadingFromFile.DatabaseLoading
{
    public class CurrencyRepository : ICurrencyRepository
    {
        private WalutyDBContext _walutyDBContext;

        public CurrencyRepository(WalutyDBContext walutyDBContext)
        {
            _walutyDBContext = walutyDBContext;
        }

        public List<Currency> GetAllCurrencies()
        {
            return _walutyDBContext.Currencies.ToList();
        }

        public IPagedList<Currency> GetAllCurrencies(int pageSize, int pageNumber)
        {
            throw new NotImplementedException();
        }

        public IPagedList<Currency> GetAllCurrencies(int pageSize, int pageNumber, string filter)
        {
            throw new NotImplementedException();
        }

        public List<CurrencyInfo> GetAllCurrencyInfo()
        {
            return _walutyDBContext.CurrencyInfos.ToList();
        }

        public IPagedList<CurrencyInfo> GetAllCurrencyInfo(int pageSize, int pageNumber)
        {
            return _walutyDBContext.CurrencyInfos.ToPagedList(pageNumber, pageSize);
        }

        public IPagedList<CurrencyInfo> GetAllCurrencyInfo(int pageSize, int pageNumber, string filter)
        {
            return _walutyDBContext.CurrencyInfos.Where(x => x.Code.Contains(filter.ToUpper())).ToPagedList(pageNumber, pageSize);
        }

        public Currency GetCurrency(string currencyCode)
        {
            return _walutyDBContext.Currencies.Single(x => x.Name.ToLower() == currencyCode.ToLower()); ;
        }

        public List<CurrencyRecord> GetCurrencyRecordsBtwnDates(string currencyCode, DateTime begDate, DateTime endDate)
        {
            return _walutyDBContext.Currencies.Single(c => c.Name.ToLower() == currencyCode.ToLower())
                    .ListOfRecords.Where(cr => cr.Date >= begDate && cr.Date <= endDate).ToList(); 
        }
    }
}

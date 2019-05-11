using System;
using System.Collections.Generic;
using System.Linq;
using WalutyBusinessLogic.DatabaseLoading;

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

        public List<CurrencyInfo> GetAllCurrencyInfo()
        {
            return _walutyDBContext.CurrencyInfos.ToList();
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

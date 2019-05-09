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
            throw new System.NotImplementedException();
        }
    }
}

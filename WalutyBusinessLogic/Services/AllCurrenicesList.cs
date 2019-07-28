using System.Collections.Generic;
using WalutyBusinessLogic.DatabaseLoading;
using WalutyBusinessLogic.LoadingFromFile;
using System.Threading.Tasks;

namespace WalutyBusinessLogic.Services
{
    public class AllCurrenicesList
    {
        private readonly ICurrencyRepository _repository;
        public AllCurrenicesList(ICurrencyRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Currency>> GetAllCurrenciesList()
        {
            List<Currency> AllCurrenciesList = await _repository.GetAllCurrencies();
            return AllCurrenciesList;
        }
    }
}

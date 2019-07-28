using System;
using System.Globalization;
using System.Linq;
using WalutyBusinessLogic.DatabaseLoading;
using WalutyBusinessLogic.LoadingFromFile;
using WalutyBusinessLogic.Models;
using System.Threading.Tasks;

namespace WalutyBusinessLogic.CurrenciesComparision
{
    public class CurrenciesComparator
    {
        private readonly ICurrencyRepository _repository;
        public string FileExtension { get; set; }

        public CurrenciesComparator(ICurrencyRepository repository)
        {
            _repository = repository;
            FileExtension = ".txt";
        }

        public async Task<CurrenciesComparatorModel> CompareCurrencies(CurrenciesComparatorModel model)
        {
            Currency firstCurrency = await _repository.GetCurrency(model.FirstCurrencyCode + FileExtension);
            Currency secondCurrency = await _repository.GetCurrency(model.SecondCurrencyCode + FileExtension);

            CurrencyRecord firstCurrencyRecord =
                firstCurrency.ListOfRecords.Single(currency => currency.Date == model.Date);
            CurrencyRecord secondCurrencyRecord =
                secondCurrency.ListOfRecords.Single(currency => currency.Date == model.Date);

            float firstCloseValue = firstCurrencyRecord.Close;
            float secondCloseValue = secondCurrencyRecord.Close;

            float comparision = firstCloseValue / secondCloseValue;

            model.ComparatorResult = $"In day {model.Date.ToShortDateString()} {firstCurrency.Name} is worth {comparision} {secondCurrency.Name}";
            return model;
        }
    }
}

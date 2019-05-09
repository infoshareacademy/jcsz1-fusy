using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

      
    }
}

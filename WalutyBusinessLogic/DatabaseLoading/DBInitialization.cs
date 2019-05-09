using System;
using System.Collections.Generic;
using System.Text;
using WalutyBusinessLogic.LoadingFromFile;
using WalutyBusinessLogic.LoadingFromFile.DatabaseLoading;

namespace WalutyBusinessLogic.DatabaseLoading
{
    public static class DBInitialization
    {
      
        public static void InitialiseDB(WalutyDBContext context, ILoader loader)
        {
            context.AddRange(loader.GetListOfAllCurrencies());
            context.AddRange(loader.LoadCurrencyInformation());
            context.SaveChanges();
        }
    }
}

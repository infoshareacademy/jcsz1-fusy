using System;
using System.Collections.Generic;
using System.Text;

namespace WalutyBusinessLogic.LoadingFromFile
{
    public class Currency
    {
        public string Name { get; set; }
        public List<CurrencyRecord> Type { get; set; }

        public Currency(string name)
        {
            Name = name;
            Type = new List<CurrencyRecord>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace WalutyBusinessLogic.LoadingFromFile
{
    public class Currency
    {
        public string Name { get; set; }
        public List<CurrencyRecord> ListOfRecords { get; set; }

        public Currency(string name)
        {
            Name = name;
            ListOfRecords = new List<CurrencyRecord>();
        }

        public Currency()
        {
            ListOfRecords = new List<CurrencyRecord>();
        }
    }
}

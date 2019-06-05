using System.Collections.Generic;

namespace WalutyBusinessLogic.LoadingFromFile
{
    public class Currency
    {
        public int Id { get; set; }
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

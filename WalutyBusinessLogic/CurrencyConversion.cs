using System;
using System.Collections.Generic;
using System.Text;

namespace WalutyBusinessLogic
{
    class CurrencyConversion
    {

        public float ValueCurrencyBeforConversion;
        public float ValueCurrencyAfterConversion;
        public float AmountCurrencyBeforConversion;
        public float AmountCurrencyAfterConversion;
        public string NameCurrencyBeforConversion;
        public string NameCurrencyAfterConversion;
        public DateTime SelectedDate;

        public void ReadCurrency()
        {
            Console.WriteLine("Enter currency, first name of currency, next amount");
            NameCurrencyBeforConversion = Convert.ToString(Console.ReadLine());
            AmountCurrencyBeforConversion = Convert.ToSingle(Console.ReadLine());

            Console.WriteLine("Enter second name of currency");
            NameCurrencyAfterConversion = Convert.ToString(Console.ReadLine());
            Console.Write("Enter date in format MM/DD/YYYY:");
            SelectedDate = Convert.ToDateTime(Console.ReadLine());

        }

        public float ConvertCurrency(float CurrencyValueFirst, float CurrencyValueSecond )
        {
            ValueCurrencyBeforConversion = CurrencyValueFirst;
            ValueCurrencyAfterConversion = CurrencyValueSecond;

            AmountCurrencyAfterConversion = ValueCurrencyBeforConversion * AmountCurrencyBeforConversion / ValueCurrencyAfterConversion;
            return AmountCurrencyAfterConversion;
        }

        public void WriteCurrency()
        {
            Console.WriteLine($"In day {SelectedDate} : {AmountCurrencyBeforConversion} {NameCurrencyBeforConversion}" +
                              $"= {AmountCurrencyAfterConversion} {NameCurrencyAfterConversion}");
            //W dniu 13.01.2019: 5 EUR = 21,49 PLN
        }
    }
}

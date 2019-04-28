using System;

namespace WalutyMVCWebApp.Models
{
    public class CurrencyConvertionModel
    {
        public int Date { get; set; }
        public string FirstCurrency { get; set; }
        public string SecondCurrency { get; set; }
        public float AmountFirstCurrency { get; set; }
    }
}

using System;
//asp validation file
namespace WalutyBusinessLogic.Models
{
    public class CurrencyConvertionModel
    {
        public DateTime Date { get; set; }
        public string FirstCurrency { get; set; }
        public string SecondCurrency { get; set; }
        public float AmountFirstCurrency { get; set; }
        public float AmountSecondCurrency { get; set; }
    }
}

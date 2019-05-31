using System;
using System.ComponentModel.DataAnnotations;

namespace WalutyBusinessLogic.Models
{
    public class CurrencyConversionModel
    {
        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Currency is required")]
        [StringLength(3, ErrorMessage = "Currency name must have 3 letter. Example: USD")]
        public string FirstCurrency { get; set; }
        [Required(ErrorMessage = "Currency is required")]
        [StringLength(3, ErrorMessage = "Currency name must have 3 letter. Example: USD")]
        public string SecondCurrency { get; set; }

        [Required(ErrorMessage = "Amount currency is required")]
        [Range (1,10000000)]
        public float AmountFirstCurrency { get; set; }
        public float AmountSecondCurrency { get; set; }
    }
}

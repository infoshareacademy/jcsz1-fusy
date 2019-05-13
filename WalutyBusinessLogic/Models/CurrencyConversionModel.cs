using System;
using System.ComponentModel.DataAnnotations;

namespace WalutyBusinessLogic.Models
{
    public class CurrencyConversionModel
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        [StringLength(3, ErrorMessage = "Currency name must have 3 letter. Example: USD")]
        public string FirstCurrency { get; set; }
        [Required]
        [StringLength(3, ErrorMessage = "Currency name must have 3 letter. Example: USD")]
        public string SecondCurrency { get; set; }
        [Required]
        public float AmountFirstCurrency { get; set; }
        public float AmountSecondCurrency { get; set; }
    }
}

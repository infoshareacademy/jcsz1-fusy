using System;
using System.ComponentModel.DataAnnotations;

namespace WalutyBusinessLogic.Models
{
    public class CurrenciesComparatorModel
    {
        [Required]
        [StringLength(3, ErrorMessage = "Currency name must have 3 letter. Example: USD")]
        public string FirstCurrencyCode { get; set; }
        [Required]
        [StringLength(3, ErrorMessage = "Currency name must have 3 letter. Example: USD")]
        public string SecondCurrencyCode { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string ComparatorResult { get; set; }
    }
}

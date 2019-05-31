using System;
using System.ComponentModel.DataAnnotations;

namespace WalutyBusinessLogic.Models
{
    public class CurrenciesComparatorModel
    {
        [Required(ErrorMessage ="Currency is required")]
        [StringLength(3, ErrorMessage = "Currency name must have 3 letter. Example: USD")]
        public string FirstCurrencyCode { get; set; }

        [Required(ErrorMessage = "Currency is required")]
        [StringLength(3, ErrorMessage = "Currency name must have 3 letter. Example: USD")]
        public string SecondCurrencyCode { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime Date { get; set; }

        public string ComparatorResult { get; set; }
    }
}

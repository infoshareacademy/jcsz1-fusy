using System;
using System.ComponentModel.DataAnnotations;

namespace WalutyBusinessLogic.Models
{
    public class LocalExtremeValueModel
    {
        public float MaxValue { get; set; }
        public float MinValue { get; set; }

        [Required(ErrorMessage = "Currency is required")]
        [StringLength (3, ErrorMessage = "Name currency must 3 letters. Example: EUR")]
        public string NameCurrency { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public DateTime StartDate {get; set;}

        [Required(ErrorMessage = "Date is required")]
        public DateTime EndDate { get; set; }
    }
}

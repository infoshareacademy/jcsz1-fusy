using System;
using System.ComponentModel.DataAnnotations;

namespace WalutyBusinessLogic.Models
{
    public class ExtremeValue
    {
        public float MaxValue { get; set; }
        public float MinValue { get; set; }
        [Required]
        [StringLength (3, ErrorMessage = "Name currency must 3 letters. Example: EUR")]
        public string NameCurrency { get; set; }
        [Required]
        public DateTime StartDate {get; set;}
        [Required]
        public DateTime EndDate { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace WalutyBusinessLogic.Models
{
    public class ExtremeValue
    {
        public float MaxValue { get; set; }
        public float MinValue { get; set; }
        [Required]
        public string NameCurrency { get; set; }
        public DateTime StartDate {get; set;}
        public DateTime EndDate { get; set; }
    }
}

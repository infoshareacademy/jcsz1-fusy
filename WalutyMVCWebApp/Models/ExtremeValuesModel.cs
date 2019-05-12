using System;

namespace WalutyMVCWebApp.Models
{
    public class ExtremeValue
    {
        public float MaxValue { get; set; }
        public float MinValue { get; set; }
        public string NameCurrency { get; set; }
        public DateTime StartDate {get; set;}
        public DateTime EndDate { get; set; }
    }
}

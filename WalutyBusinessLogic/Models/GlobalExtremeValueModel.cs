using System.ComponentModel.DataAnnotations;

namespace WalutyBusinessLogic.Models
{
    public class GlobalExtremeValueModel
    {
        public float MaxValue { get; set; }
        public float MinValue { get; set; }

        [Required(ErrorMessage = "Currency is required")]
        [StringLength(3, ErrorMessage = "Name currency must 3 letters. Example: EUR")]
        public string NameCurrency { get; set; }
    }
}

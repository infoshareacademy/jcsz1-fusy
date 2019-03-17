using System;
using System.Collections.Generic;
using System.Text;

namespace WalutyBusinessLogic.Extremes
{
    public class ExtremeValue
    {
        public float MaxValue { get; set; }
        public float MinValue { get; set; }

        public override string ToString()
        {
            return $"Max {MaxValue} ; Min {MinValue}";
        }
    }
}

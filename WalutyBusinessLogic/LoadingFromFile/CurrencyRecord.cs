using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace WalutyBusinessLogic.LoadingFromFile
{
    class CurrencyRecord
    {
        public int Date { get; set; }
        public float Open { get; set; }
        public float High { get; set; }
        public float Low { get; set; }
        public float Close { get; set; }
        public float Volume { get; set; }
    }
}

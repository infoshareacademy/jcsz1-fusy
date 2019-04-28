using System;
using System.Collections.Generic;
using System.Text;

namespace WalutyBusinessLogic.LoadingFromFile
{
    public class CurrencyInfo
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public CurrencyInfo(string name, string code)
        {
            Name = name;
            Code = code;
        }
    }
}

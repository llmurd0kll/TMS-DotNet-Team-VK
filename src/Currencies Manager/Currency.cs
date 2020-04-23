using System;
using System.Collections.Generic;
using System.Text;

namespace Currencies_Manager
{
    public class Currency
    {
        public string Abbreviation { get; set; }
        public double Value { get; set; }
        public int Scale { get; set; }

        public override string ToString()
        {
            return $"{Abbreviation}: {Value}";
        }
    }
}

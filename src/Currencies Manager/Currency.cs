using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Text;

namespace Currencies_Manager
{
   public class Currency
    {
        public string Abbreviation { get; set; }
        public decimal Value { get; set; }
        public int Scale { get; set; }
        public Currency()
        {

        }
        public Currency(Rate rate)
        {
            Abbreviation = rate.Cur_Abbreviation;
            Value = rate.Cur_OfficialRate.GetValueOrDefault();
            Scale = rate.Cur_Scale;
        }

        public override string ToString()
        {
            return $"{Abbreviation}: {Value}";
        }

    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Text;

namespace Currencies_Manager
{
    /// <summary>
    /// Класс валют
    /// </summary>
    public class Currency
    {
        public string Abbreviation { get; set; }
        public decimal Value { get; set; }
        public int Scale { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        public Currency()
        {

        }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="rate">параметр конкретной валюты</param>
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

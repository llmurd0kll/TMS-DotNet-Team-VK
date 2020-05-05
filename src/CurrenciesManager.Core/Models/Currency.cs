using System;

namespace CurrenciesManager.Core.Models
{
    /// <summary>
    /// Класс валюты.
    /// </summary>
    public class Currency
    {
        // TODO: XML comments

        /// <summary>
        /// 
        /// </summary>
        public string Abbreviation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Scale { get; set; }

        /// <summary>
        /// Пустой конструктор.
        /// </summary>
        public Currency()
        {

        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        /// <param name="rate">Параметр валюты.</param>
        public Currency(Rate rate)
        {
            rate = rate ?? throw new ArgumentNullException(nameof(rate));

            Abbreviation = rate.Cur_Abbreviation;
            Value = rate.Cur_OfficialRate.GetValueOrDefault();
            Scale = rate.Cur_Scale;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Abbreviation}: {Value}: {Scale}";
        }
    }
}

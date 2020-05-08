using System;

namespace CurrenciesManager.Core.Models
{
    /// <summary>
    /// Класс валюты.
    /// </summary>
    public class Currency
    {
        /// <summary>
        /// Аббревиатура.
        /// </summary>
        public string Abbreviation { get; set; }

        /// <summary>
        /// Курс запрошенной валюты
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        /// Кол-во едениц
        /// </summary>
        public int Scale { get; set; }

        /// <summary>
        /// Название валюты
        /// </summary>
        public string Name { get; set; }

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
            Name = rate.Cur_Name;
        }

        /// <summary>
        /// Вывод информации на консоль
        /// </summary>
        /// <returns>Информация о запрошенной валюте</returns>
        public override string ToString()
        {
            return $"{Abbreviation}: {Value}: {Scale}";
        }
    }
}

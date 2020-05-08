using System;

namespace CurrenciesManager.Core.Models
{
    /// <summary>
    /// Класс стоймости валюты.
    /// </summary>
    public class Rate
    {
        /// <summary>
        /// ID валюты
        /// </summary>
        public int Cur_ID { get; set; }

        /// <summary>
        /// Дата актуальности информации
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Аббревиатура валюты
        /// </summary>
        public string Cur_Abbreviation { get; set; }

        /// <summary>
        /// Кол-во валюты
        /// </summary>
        public int Cur_Scale { get; set; }

        /// <summary>
        /// Название валюты
        /// </summary>
        public string Cur_Name { get; set; }

        /// <summary>
        /// Офицальный курс валюты
        /// </summary>
        public decimal? Cur_OfficialRate { get; set; }
    }
}

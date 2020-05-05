using System;

namespace CurrenciesManager.Core.Models
{
    /// <summary>
    /// Класс стоймости валюты.
    /// </summary>
    public class Rate
    {
        // TODO: XML comments

        /// <summary>
        /// 
        /// </summary>
        public int Cur_ID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Cur_Abbreviation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Cur_Scale { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Cur_Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? Cur_OfficialRate { get; set; }
    }
}

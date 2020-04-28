using System;

namespace Currencies_Manager
{
    /// <summary>
    /// Список сво-в для управления валютами
    /// </summary>
    public class Rate
    {

        public int Cur_ID { get; set; }
        public DateTime Date { get; set; }
        public string Cur_Abbreviation { get; set; }
        public int Cur_Scale { get; set; }
        public string Cur_Name { get; set; }
        public decimal? Cur_OfficialRate { get; set; }
    }
}


 
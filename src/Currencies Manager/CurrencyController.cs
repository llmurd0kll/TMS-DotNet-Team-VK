using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Linq;

namespace Currencies_Manager
{
    class CurrencyController : ICurrencyController
    {
        /// <summary>
        /// Получение кол-ва валют
        /// </summary>
        /// <returns>Кол-во валют</returns>
        public List<Currency> GetCurrencies()
        {
            var task = GetCurrenciesAsync();
            task.Wait();
            var list = task.Result;
            return list;
        }
        /// <summary>
        /// Получение json валюты
        /// </summary>
        /// <returns>список валют</returns>
        
          
        private static async Task<List<Currency>> GetCurrenciesAsync()
        {
                using var client = new HttpClient();
                client.BaseAddress = new Uri("https://www.nbrb.by");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var url = "api/exrates/rates?periodicity=0";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                List<Rate> rates = JsonConvert.DeserializeObject<List<Rate>>(json);
                List<Currency> currencies = rates.Select(rate => new Currency(rate)).ToList();
                return currencies;
        }
    }
}



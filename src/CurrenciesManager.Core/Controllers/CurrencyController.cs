using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Linq;
using CurrenciesManager.Core.Interfaces;
using CurrenciesManager.Core.Models;

namespace CurrenciesManager.Core.Controllers
{
    // TODO: XML comments

    /// <summary>
    /// 
    /// </summary>
    public class CurrencyController : ICurrencyController
    {

        /// <inheritdoc/>
        public async Task<IEnumerable<Currency>> GetCurrenciesAsync()
        {
            using var client = new HttpClient
            {
                BaseAddress = new Uri("https://www.nbrb.by") // TODO: Constants
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); // TODO: Constants
            var url = "api/exrates/rates?periodicity=0";// TODO: Constants 

            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            List<Rate> rates = JsonConvert.DeserializeObject<List<Rate>>(json);
            return rates.Select(rate => new Currency(rate));
        }
    }
}

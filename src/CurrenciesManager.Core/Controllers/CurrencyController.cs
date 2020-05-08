using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using System.Linq;
using CurrenciesManager.Core.Interfaces;
using CurrenciesManager.Core.Models;
using CurrenciesManager.Core.Constants;

namespace CurrenciesManager.Core.Controllers
{
    /// <summary>
    /// Получение информации с сайта.
    /// </summary>
    public class CurrencyController : ICurrencyController
    {
        public async Task<IEnumerable<Currency>> GetCurrenciesAsync()
        {
            using var client = new HttpClient
            {
                BaseAddress = new Uri(AppConstants.NBRB_URL)
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(AppConstants.JSON));
            var url = AppConstants.URL_RATES;
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            List<Rate> rates = JsonConvert.DeserializeObject<List<Rate>>(json);
            return rates.Select(rate => new Currency(rate));
        }
    }
}

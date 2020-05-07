using CurrenciesManager.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrenciesManager.Core.Interfaces
{
    /// <summary>
    /// Интерфейс для валют.
    /// </summary>
    interface ICurrencyController
    {
        /// <summary>
        /// Получить список валют.
        /// </summary>
        /// <returns>Список валют.</returns>
        Task<IEnumerable<Currency>> GetCurrenciesAsync();
    }
}

using CurrenciesManager.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CurrenciesManager.Core.Interfaces
{
    // TODO: XML comments

    /// <summary>
    /// 
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

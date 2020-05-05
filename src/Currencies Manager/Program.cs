using CurrenciesManager.Core.Managers;
using System;

namespace Currencies_Manager
{
    class Program
    {
        static void Main()
        {
            var currencyManager = new CurrencyManager();
            try
            {
                currencyManager.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

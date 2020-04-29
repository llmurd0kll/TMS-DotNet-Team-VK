using System;

namespace Currencies_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                CurrencyManager.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Currencies_Manager
{
    public class CurrencyManager
    {
        public static void Start()
        {
            Console.WriteLine("Введите ");
            var userInput=Console.ReadLine();
            FileManager.SaveValue(userInput);
        }
    }
}

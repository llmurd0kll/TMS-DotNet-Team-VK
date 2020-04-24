using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Currencies_Manager
{
    public class CurrencyManager
    {
        /// <summary>
        /// Запуск программы
        /// </summary>
        public static void Start()
        {
            do
            {
                try
                {
                    Console.Clear();
                    Console.WriteLine("Добро пожаловать");
                    Console.WriteLine("Введите желаемую валюту");
                    var userInput = Console.ReadLine();
                    FileManager.SaveValue(userInput);
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}

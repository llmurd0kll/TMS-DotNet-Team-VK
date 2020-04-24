using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Currencies_Manager
{
    public class FileManager
    {
        static ICurrencyController currencyController = new CurrencyController();
        /// <summary>
        /// Сохранение валюты в файл
        /// </summary>
        /// <param name="userInput">Ответ пользователя</param>
        public static async void SaveValue(string userInput)
        {
            string path = @"D:\NewFolder\file.txt";
            var value = SelectValue(userInput);
            if (value == null)
            {
                Console.WriteLine("Неправильный ввод валюты");
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
                {
                    await sw.WriteLineAsync(value.ToString());
                }
                Console.WriteLine(value);
            }
        }
        /// <summary>
        /// Выбор валюты
        /// </summary>
        /// <param name="userInput">ответ пользователя</param>
        /// <returns>выбраная валюта</returns>
        private static Currency SelectValue(string userInput)
        {
                var list = currencyController.GetCurrencies();
                var selectCurrency = list.FirstOrDefault(abb => abb.Abbreviation.Equals(userInput, StringComparison.InvariantCultureIgnoreCase));
                return selectCurrency;
        }
    }
}

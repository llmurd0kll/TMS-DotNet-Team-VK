using CurrenciesManager.Core.Models;
using System;
using System.IO;
using System.Text;

namespace CurrenciesManager.Core.Managers
{
    // TODO: XML comments

    /// <summary>
    /// 
    /// </summary>
    public class FileManager
    {
        /// <summary>
        /// Сохранить валюту в файл.
        /// </summary>
        /// <param name="currency">???</param>
        public async void SaveValue(Currency currency)
        {
            // TODO: throw new..

            string path = @"D:\NewFolder\file.txt"; // TODO: To Constants

            // TODO: try..catch

            // TODO ???
            if (currency == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неправильный ввод валюты"); // TODO: To Constants
                Console.ForegroundColor = ConsoleColor.White;
            }



            else
            {
                using (StreamWriter sw = new StreamWriter(path, true, Encoding.Default))
                {
                    await sw.WriteLineAsync(currency.ToString());
                }
                Console.WriteLine(currency);
            }
        }
    }
}

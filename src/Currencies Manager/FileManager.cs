using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Currencies_Manager
{
    public class FileManager
    {

        /// <summary>
        /// Метод SaveValue сохраняет запрошенную пользователем валюту в файл
        /// </summary>
        /// <param name="value"></param>
        public static async void SaveValue(Currency value)
        {
            string path = @"D:\NewFolder\file.txt";
            if (value == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неправильный ввод валюты");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(path, true, Encoding.Default))
                {
                    await sw.WriteLineAsync(value.ToString());
                }
                Console.WriteLine(value);
            }
        }
    }
}

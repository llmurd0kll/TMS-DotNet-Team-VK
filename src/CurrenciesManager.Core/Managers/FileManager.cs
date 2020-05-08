using CurrenciesManager.Core.Constants;
using CurrenciesManager.Core.Models;
using System;
using System.IO;
using System.Text;

namespace CurrenciesManager.Core.Managers
{
    /// <summary>
    /// Класс работы с файлом.
    /// </summary>
    public class FileManager
    {
        /// <summary>
        /// Сохранить валюту в файл.
        /// </summary>
        /// <param name="currency">Запрошеная валюта</param>
        public async void SaveValue(Currency currency)
        {
            currency = currency ?? throw new ArgumentNullException(nameof(currency));
            string path = AppConstants.PATH;
            try
            {
                if (currency == null)
                {
                    ConsoleManager.ExceptionInput("Неправильный ввод валюты");
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
            catch (Exception ex)
            {
                ConsoleManager.ExceptionInput($"Произошла ошибка, вот сообщение об ошибке: {ex}");
            }
        }
    }
}

using System.IO;
using System.Linq;

namespace Currencies_Manager
{
    public class FileManager:IFileManager
    {
        static ICurrencyController currencyController = new CurrencyController();

        public static async void SaveValue(string userInput)
        {
            string path = @"D:\NewFolder\file.txt";
            using (StreamWriter sw = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                 await sw.WriteLineAsync((SelectValue(userInput)).ToString());
            }
        }

        private static Currency SelectValue(string userInput)
        {
            var list = currencyController.GetCurrencies();
            var selectCurrency = list.First(abb => abb.Abbreviation == userInput);
            return selectCurrency;
        }

    }
}

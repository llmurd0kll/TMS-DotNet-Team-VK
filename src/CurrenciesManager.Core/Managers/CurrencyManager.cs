using CurrenciesManager.Core.Controllers;
using CurrenciesManager.Core.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CurrenciesManager.Core.Managers
{
    // TODO: XML comments

    /// <summary>
    /// 
    /// </summary>
    public class CurrencyManager
    {
        /// <summary>
        /// Запуск программы.
        /// </summary>
        public void Start()
        {
            try
            {
                Console.Clear();

                // TODO: Constants
                Console.WriteLine("Добро пожаловать в Currency Manager");
                Selection();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Выбрать доступную команду.
        /// </summary>
        public void Selection()
        {
            try
            {
                string userInput = string.Empty;
                do
                {
                    Console.WriteLine("Пожалуйста, выбирите ваше дальнейшее действие:\n1)Просмотр курса валюты\n2)Просмотр списка доступных валют\n3)Для выхода "); // TODO: Constants
                    userInput = Console.ReadLine();
                    switch (userInput)
                    {
                        case "1":
                            {
                                ViewRates();
                                Console.ReadKey();

                            }
                            break;

                        case "2":
                            {
                                ViewListAsync();
                                Console.ReadKey();
                            }
                            break;
                    }
                } while (userInput != "3");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// Показать запрошенную пользователем валюту и сохранить её в файл.
        /// </summary>
        public async void ViewRates()
        {
            Console.WriteLine("Введите желаемую валюту"); // TODO: Constants
            var userInput = Console.ReadLine();
            if (userInput.Length == 3)
            {
                Console.WriteLine("Желаете ли сохранить данную информацию в файл?"); // TODO: Constants
                var userAnsw = Console.ReadLine();

                if (userAnsw.Equals("Да", StringComparison.OrdinalIgnoreCase))
                {
                    // TODO: try..catch
                    var currentCurrency = await SelectValueAsync(userInput);
                    var fileManager = new FileManager();
                    fileManager.SaveValue(currentCurrency);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Сохранение выполнено успешно" + " Для продолжения нажмите любую клавишу");// TODO: Constants
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (userAnsw.Equals("Нет", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(SelectValueAsync(userInput));
                }
                else
                {
                    ConsoleManager.ExceptionInput("Неправильный формат ввода, попробуйте еще раз");
                }
            }
            else
            {
                // TODO: refactor
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Некоректный ввод");
                Console.ForegroundColor = ConsoleColor.White;
            }

        }

        /// <summary>
        /// Просмотреть список всех существующих валют.
        /// </summary>
        public async void ViewListAsync()
        {
            var currencyController = new CurrencyController(); // TODO: Constants

            Console.WriteLine("Список доступных валют:");
            var currencies = await currencyController.GetCurrenciesAsync();

            foreach (var currency in currencies)
            {
                Console.Write($"{currency.Abbreviation}; ");
            }

            Console.WriteLine("Для продолжения нажмите любую клавишу");// TODO: Constants
        }

        /// <summary>
        /// Выбрать валюту из списка, запрошенной пользователем.
        /// </summary>
        /// <param name="userInput">Пользовательский ввод.</param>
        /// <returns>Выбранная валюта.</returns>
        public async Task<Currency> SelectValueAsync(string userInput)
        {
            // TODO: throw new..

            var currencyController = new CurrencyController();
            var currencies = await currencyController.GetCurrenciesAsync();
            return currencies.FirstOrDefault(abb => abb.Abbreviation.Equals(userInput, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}


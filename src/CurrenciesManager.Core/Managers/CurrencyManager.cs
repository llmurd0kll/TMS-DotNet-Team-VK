﻿using CurrenciesManager.Core.Constants;
using CurrenciesManager.Core.Controllers;
using CurrenciesManager.Core.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CurrenciesManager.Core.Managers
{
    /// <summary>
    /// Управление консолью.
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
                Console.WriteLine(AppConstants.GREETING);
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
                    Console.WriteLine(AppConstants.SELECT);
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
                ConsoleManager.ExceptionInput($"Произошла ошибка, вот сообщение ошибки: {ex}");
            }
        }

        /// <summary>
        /// Показать запрошенную пользователем валюту и сохранить её в файл.
        /// </summary>
        public async void ViewRates()
        {
            Console.WriteLine(AppConstants.CARRENCY_INPUT);
            var userInput = Console.ReadLine();
            try
            {
                if (userInput.Length == 3)
                {
                    Console.WriteLine(AppConstants.SAVE);
                    var userAnsw = Console.ReadLine();
                    if (userAnsw.Equals("Да", StringComparison.OrdinalIgnoreCase))
                    {
                        var currentCurrency = await SelectValueAsync(userInput);
                        var fileManager = new FileManager();
                        fileManager.SaveValue(currentCurrency);
                        ConsoleManager.SuccessfulInput("Сохранение выполнено успешно" + " Для продолжения нажмите любую клавишу");
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
                    ConsoleManager.ExceptionInput("Некоректный ввод названия валюты");
                }
            }
            catch (Exception ex)
            {
                ConsoleManager.ExceptionInput($"Произошла ошибка, вот сообщение ошибки {ex}");
            }
        }

        /// <summary>
        /// Просмотреть список всех существующих валют.
        /// </summary>
        public async void ViewListAsync()
        {
            var currencyController = new CurrencyController();
            Console.WriteLine(AppConstants.LIST_OF_CURRENCIES);
            var currencies = await currencyController.GetCurrenciesAsync();
            foreach (var currency in currencies)
            {
                Console.WriteLine($"{currency.Abbreviation} : {currency.Scale,6} : {currency.Value,6} : {currency.Name}");
            }
            Console.WriteLine(AppConstants.ANY_KEY_TO_CONT);
        }

        /// <summary>
        /// Выбрать валюту из списка, запрошенной пользователем.
        /// </summary>
        /// <param name="userInput">Пользовательский ввод.</param>
        /// <returns>Выбранная валюта.</returns>
        public async Task<Currency> SelectValueAsync(string userInput)
        {
            userInput = userInput ?? throw new ArgumentNullException(nameof(userInput));
            var currencyController = new CurrencyController();
            var currencies = await currencyController.GetCurrenciesAsync();
            return currencies.FirstOrDefault(abb => abb.Abbreviation.Equals(userInput, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Currencies_Manager
{
    public class CurrencyManager
    {
        /// <summary>
        /// Запуск программы
        /// </summary>
        public static void Start()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Добро пожаловать в Currency Manager");
                Selection();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Выбор доступных команд в консоли
        /// </summary>
        public static void Selection()
        {
            string userInput1 = string.Empty;
            try
            {
                do
                {
                    Console.WriteLine("Пожалуйста, выбирите ваше дальнейшее действие:\n1)Просмотр курса валюты\n2)Просмотр списка доступных валют\n3)Для прсомотра возможных команд\n4)Для выхода ");
                    userInput1 = Console.ReadLine();
                    switch (userInput1)
                    {
                        case "1":
                            {
                                ViewRates();
                                Console.ReadKey();
                                break;
                            }
                        case "2":
                            {
                                ViewList();
                                Console.ReadKey();
                                break;
                            }
                        case "3":
                            {
                                Console.WriteLine("В дальнейшем вы можете использовать следующие команды для удобного взаимодействия: ");
                                Console.ReadKey();
                                break;
                            }
                    }
                    Console.Clear();
                } while (userInput1 != "4");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// Метод ViewRates включает в себя просмотр курса запрошенной 
        /// пользователем валюты и сохранение данной валюты в файл
        /// </summary>
        public static void ViewRates()
        {
            Console.WriteLine("Введите желаемую валюту");
            var userInput = Console.ReadLine();
            Console.WriteLine("Желаете ли сохранить данную информацию в файл?");
            var userAnsw = Console.ReadLine();
            if (userAnsw.Equals("Да", StringComparison.OrdinalIgnoreCase))
            {
                var currentCurrency = SelectValue(userInput);
                FileManager.SaveValue(currentCurrency);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Сохранение выполнено успешно" + " Для продолжения нажмите любую клавишу");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else if (userAnsw.Equals("Нет", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine(SelectValue(userInput));
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Неправильный формат ввода, попробуйте еще раз");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// Метод ViewList осуществляет просмотр списка всей существующей валюты
        /// </summary>
        public static void ViewList()
        {
            Thread.Sleep(2000);
            Console.WriteLine("Список доступных валют:");
            var currency = new CurrencyController();
            List<string> listofcur = new List<string>();
            foreach (var allcur in currency.GetCurrencies())
            {
                var alcur = allcur.Abbreviation;
                listofcur.Add(alcur);
            }
            for (int i = 0; i < listofcur.Count; i++)
            {
                Console.Write(listofcur[i] + "; ");
            }
            Console.WriteLine("Для продолжения нажмите любую клавишу");
        }

        /// <summary>
        /// Метод SelectValue реализовывает выбор валюты из списка,
        /// запрошенной пользователем
        /// </summary>
        /// <param name= принимает в себя ввод пользователя"userInput"></param>
        /// <returns></returns>
        public static Currency SelectValue(string userInput)
        {
            CurrencyController currencyController = new CurrencyController();
            var list = currencyController.GetCurrencies();
            var selectCurrency = list.FirstOrDefault(abb => abb.Abbreviation.Equals(userInput, StringComparison.InvariantCultureIgnoreCase));
            return selectCurrency;
        }
    }
}


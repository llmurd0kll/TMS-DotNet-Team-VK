using System;
using System.Collections.Generic;
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
            //do
            //{
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
            //}// while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
        /// <summary>
        /// Выбор доступных команд в консоли
        /// </summary>
        public static void Selection()
        {


            try
            {
                Console.WriteLine("Пожалуйста, выбирите ваше дальнейшее действие:\n1)Просмотр курса валюты\n2)Просмотр списка доступных валют\n3)Для прсомотра возможных команд\n4)Для выхода ");
                var userInput1 = Console.ReadLine();
                switch (userInput1)
                {
                    case "1":
                        Console.WriteLine("Введите желаемую валюту");
                        var userInput = Console.ReadLine();
                        Console.WriteLine("Желаете ли сохранить данную информацию в файл?");
                        var userAnsw = Console.ReadLine();
                        if (userAnsw == "Да" && userAnsw.Equals(userAnsw, StringComparison.OrdinalIgnoreCase))
                        {
                            FileManager.SaveValue(userInput);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Сохранение выполнено успешно");
                            Console.ForegroundColor = ConsoleColor.White;
                            Selection();
                        }
                        else if (userAnsw == "Нет" && userAnsw.Equals(userAnsw, StringComparison.OrdinalIgnoreCase))
                        {
                            Console.WriteLine(FileManager.SelectValue(userInput));
                            Selection();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Неправильный формат ввода, попробуйте еще раз");
                            Console.ForegroundColor = ConsoleColor.White;
                            Selection();
                        }
                        break;
                    case "2":
                        Thread.Sleep(2000);
                        Console.WriteLine("Список доступных валют:");  //TODO: добавить вывод списка валют сюда
                        var currency = new CurrencyController();
                        var curlist = new Currency();
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
                        Console.WriteLine("");
                        Selection();
                        break;
                    case "3":
                        Console.WriteLine("В дальнейшем вы можете использовать следующие команды для удобного взаимодействия: "); //TODO: добавить команды для консоли
                        Selection();
                        break;
                    case "4":
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
      
    }

}


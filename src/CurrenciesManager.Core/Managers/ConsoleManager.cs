using System;

namespace CurrenciesManager.Core.Managers
{
    /// <summary>
    /// Класс управления консолью.
    /// </summary>
    public static class ConsoleManager
    {
        /// <summary>
        /// Цветовая обработка ошибки.
        /// </summary>
        /// <param name="text">Текст ошибки</param>
        public static void ExceptionInput(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// Цветовая обработка успешного действия.
        /// </summary>
        /// <param name="text">Текст действия</param>
        public static void SuccessfulInput(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

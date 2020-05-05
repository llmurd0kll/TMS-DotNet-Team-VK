using System;

namespace CurrenciesManager.Core.Managers
{
    /// <summary>
    /// 
    /// </summary>
    public static class ConsoleManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        public static void ExceptionInput(string text)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

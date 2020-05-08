using System;
using System.Collections.Generic;
using System.Text;

namespace CurrenciesManager.Core.Constants
{
    /// <summary>
    /// Класс констант.
    /// </summary>
    public class AppConstants
    {
        public const string NBRB_URL = @"https://www.nbrb.by";
        public const string URL_RATES = @"api/exrates/rates?periodicity=0";
        public const string JSON = @"application/json";
        public const string GREETING = "Добро пожаловать в Currency Manager";
        public const string SAVE = "Желаете ли сохранить данную информацию в файл?";
        public const string SELECT = "Пожалуйста, выбирите ваше дальнейшее действие:\n1)Просмотр курса валюты\n2)Просмотр списка доступных валют\n3)Для выхода ";
        public const string CARRENCY_INPUT = "Введите желаемую валюту";
        public const string ANY_KEY_TO_CONT = "Для продолжения нажмите любую клавишу";
        public const string LIST_OF_CURRENCIES = "Список доступных валют:";
        public const string PATH = @"D:\NewFolder\file.txt";
    }
}
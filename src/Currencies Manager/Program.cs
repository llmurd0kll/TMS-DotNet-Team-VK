using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Linq;

namespace Currencies_Manager
{
    class Program
    {
        static void Main(string[] args)
        {
            CurrencyManager.Start();
        }
    }
}

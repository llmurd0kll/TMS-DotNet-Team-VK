using System;
using System.Collections.Generic;
using System.Text;

namespace Currencies_Manager
{
    interface ICurrencyController
    {
        List<Currency> GetCurrencies();
    }
}

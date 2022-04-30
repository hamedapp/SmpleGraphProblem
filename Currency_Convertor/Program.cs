using System;
using System.Collections.Generic;

namespace Currency_Convertor
{
    class Program
    {
        static void Main(string[] args)
        {
            var currenctConverItems = new List<ValueTuple<string, string, double>>
            {
                new ValueTuple<string, string, double>("USD", "CAD", 1.34),
                new ValueTuple<string, string, double>("CAD", "GBP", 0.58),
                new ValueTuple<string, string, double>("USD", "EUR", 0.86),
            };
            CurrencyConverter convertor = CurrencyConverter.Instance;
            convertor.UpdateConfiguration(currenctConverItems);
            var updatetConverItems = new List<ValueTuple<string, string, double>>
            {
                new ValueTuple<string, string, double>("USD", "CAD", 1.35),
                new ValueTuple<string, string, double>("EUR", "IRR", 3.86),
            };
            convertor.UpdateConfiguration(updatetConverItems);

            convertor.Convert("USD", "IRR", 1000);
            convertor.ClearConfiguration();

            Console.WriteLine("");
        }
    }
}

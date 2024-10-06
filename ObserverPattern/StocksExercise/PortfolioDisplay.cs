using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksExercise
{
    internal class PortfolioDisplay
    {
        public void display(List<(Stock, float, float)> stocks)
        {
            Console.WriteLine("***");
            foreach(var stock in stocks)
            {
                Console.WriteLine(stock.Item1.getName() + " amount: " + stock.Item2 + " value: " + stock.Item3);
            }
            Console.WriteLine("###");
        }
    }
}

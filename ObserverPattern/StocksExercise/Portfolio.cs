using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StocksExercise
{
  
    internal class Portfolio : IObserver
    {
        private float totalValue;
        private PortfolioDisplay display;
        private List<(Stock, float, float)> myStocks; // stock amount total value
        
        public Portfolio()
        {
            myStocks = new List<(Stock, float, float)>();
            display = new PortfolioDisplay();
        }
        public void Update()
        {
            for (int i = 0; i < myStocks.Count; i ++)
            {
                float stockValue = myStocks[i].Item1.getValue();
                myStocks[i] = (myStocks[i].Item1, myStocks[i].Item2, stockValue * myStocks[i].Item2) ;
                //Console.WriteLine(myStocks[i].Item3);
            }
            calculateTotalValue();
            display.display(myStocks);
        }

        private void calculateTotalValue()
        {
            totalValue = 0;
            foreach (var item in myStocks)
            {
                totalValue += item.Item3 * item.Item2;
            }
        }

        public void addStock(Stock stock, float amount)
        {
            myStocks.Add((stock, amount, -1.0f));
            //Update();
        }
    }
}

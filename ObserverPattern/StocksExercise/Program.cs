
namespace StocksExercise
{
    class MainClass
    {
        public static void Main()
        {
            Stock google = new Stock("Google", 10.0f);
            Stock microsoft = new Stock("Microsoft", 15.0f);
            Stock apple = new Stock("Apple", 1.5f);
            Stock intel = new Stock("Intel", 0.0001f);

            Portfolio[] portfolios = new Portfolio[3];

            portfolios[0] = new Portfolio();
            portfolios[1] = new Portfolio();
            portfolios[2] = new Portfolio();

            google.Attach(portfolios[0]);
            google.Attach(portfolios[1]);

            microsoft.Attach(portfolios[0]);
            microsoft.Attach(portfolios[2]);

            apple.Attach(portfolios[1]);
            apple.Attach(portfolios[2]);

            intel.Attach(portfolios[0]);
            intel.Attach(portfolios[1]);
            intel.Attach(portfolios[2]);

            portfolios[0].addStock(google, 1.2f);
            portfolios[0].addStock(microsoft, 3.5f);
            portfolios[0].addStock(intel, 0.7f);
            
            portfolios[1].addStock(google, 3.7f);
            portfolios[1].addStock(apple, 1.4f);
            portfolios[1].addStock(intel, 0.9f);
            
            portfolios[2].addStock(microsoft, 0.3f);
            portfolios[2].addStock(apple, 5.7f);
            portfolios[2].addStock(intel, 3.7f);


            intel.setValue(0.5f);

            Console.WriteLine("\n\n CHANGED \n");
            intel.setValue(3.0f);
        }
    
    }
}

using SuperSimpleStockMarket.Controller;
using SuperSimpleStockMarket.Controller.Interface;
using SuperSimpleStockMarket.Models;
using System;
using System.Collections.Generic;

namespace SuperSimpleStockMarket
{
    class Program
    {
        static void Main(string[] args)
        {

            PerformStockMarketOperation performStockMarketOperation = new PerformStockMarketOperation();
            performStockMarketOperation.StockMarketOperation();
        }
        
    }
    //methods for performing stock operations
    class PerformStockMarketOperation
    {
         IStockController _stockController;
        ICalculationController _calculationController;
        ITradeController tradeController;
        Stock stock;
        List<Stock> stocks;
        public void StockMarketOperation()
        {
            try
            {
                tradeController = new TradeController();

                _stockController = new StockController(tradeController);
                _calculationController = new CalculationController();

                stocks = new List<Stock>();
                string choice = string.Empty;
                //do while loop for add stock
                do
                {

                    stock = _stockController.AddStock();
                    if (stock != null)
                    {
                        // Calculate Dividend Yield 
                        stock.Divident_yeild=_calculationController.CalculateDividendYield(stock);

                        //Calculate P/E Ratio 𝑃𝑟𝑖𝑐𝑒
                        stock.PEratio= _calculationController.CalculatePERatioPrice(stock.Price, stock.LastDividend);

                        //Calculate Volume Weighted Stock Price                  
                        stock.VolumeWeightedStockPrice=_calculationController.VolumeWeightedStockPrice(stock.TradeList);
                        stocks.Add(stock);

                        // display stock and trades
                        _stockController.DisplayStock( stock);

                    }
                    else
                        Console.WriteLine("Please enter valid value");

                    Console.WriteLine("Do you want to Add Stock:type(y/n)");
                    choice = Console.ReadLine();


                } while (choice == "y");
                //display stocks and trades
                _stockController.DisplayStocks(stocks);
                //Calculate All share index
               _calculationController.CalculateAllShareIndex(stocks);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Message:" + ex.Message);
                
            }



        }
    }

}

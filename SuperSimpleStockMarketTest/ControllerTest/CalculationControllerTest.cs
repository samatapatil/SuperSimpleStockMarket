using SuperSimpleStockMarket.Controller;
using SuperSimpleStockMarket.Controller.Interface;
using SuperSimpleStockMarket.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSimpleStockMarketTest.ControllerTest
{
   public class CalculationControllerTest
    {
         List<Trade> tradesstock1, tradesstock2,tradesstock3, tradesstock4,tradesstock5;
        List<Stock> stocks;
        ICalculationController _calculationController;
        IStockController _stockController;
        ITradeController _tradeController;

        public CalculationControllerTest()
        {
            _calculationController = new CalculationController();
            _tradeController = new TradeController();
            _stockController = new StockController(_tradeController);
        }

        public void PerformStockCalculationTest()
        {
            try
            {
                //Stock1 adding 
                tradesstock1 = new List<Trade>();
                stocks = new List<Stock>();
                Trade trade1 = new Trade(DateTime.Now, 5, "sell", 50);
                tradesstock1.Add(trade1);
                Trade trade2 = new Trade(DateTime.Now, 5, "sell", 50);
                tradesstock1.Add(trade2);
                Trade trade3 = new Trade(DateTime.Now, 5, "sell", 50);
                tradesstock1.Add(trade3);
                Stock stock1 = new Stock("TEA", "Common", 0, 0, 100, tradesstock1, 500);
                stocks.Add(stock1);
                //Test Calculate Dividend Yield 
                stock1.Divident_yeild = _calculationController.CalculateDividendYield(stock1);

                //Test Calculate P/E Ratio 𝑃𝑟𝑖𝑐𝑒
                stock1.PEratio = _calculationController.CalculatePERatioPrice(stock1.Price, stock1.LastDividend);

                //Test Calculate Volume Weighted Stock Price                  
                stock1.VolumeWeightedStockPrice = _calculationController.VolumeWeightedStockPrice(stock1.TradeList);
                //test display stock and trades
                _stockController.DisplayStock(stock1);


                //Stock2 adding 
                tradesstock2 = new List<Trade>();
                Trade trade4 = new Trade(DateTime.Now, 5, "sell", 50);
                tradesstock2.Add(trade4);
                Trade trade5 = new Trade(DateTime.Now, 5, "sell", 50);
                tradesstock2.Add(trade5);
                Stock stock2 = new Stock("POP", "Common", 8, 0, 100, tradesstock2, 600);
                stocks.Add(stock2);
                //Test Calculate Dividend Yield 
                stock2.Divident_yeild = _calculationController.CalculateDividendYield(stock2);

                //Test Calculate P/E Ratio 𝑃𝑟𝑖𝑐𝑒
                stock2.PEratio = _calculationController.CalculatePERatioPrice(stock2.Price, stock2.LastDividend);

                //Test Calculate Volume Weighted Stock Price                  
                stock2.VolumeWeightedStockPrice = _calculationController.VolumeWeightedStockPrice(stock2.TradeList);
                //test display stock and trades
                _stockController.DisplayStock(stock2);



                //Stock3 adding 
                tradesstock3 = new List<Trade>();
                Trade trade6 = new Trade(DateTime.Now, 5, "sell", 50);
                tradesstock3.Add(trade6);
                Trade trade7 = new Trade(DateTime.Now, 5, "sell", 50);
                tradesstock3.Add(trade7);
                Stock stock3 = new Stock("ALE", "Common", 23, 0, 60, tradesstock3, 1200);
                stocks.Add(stock3);
                //Test Calculate Dividend Yield 
                stock3.Divident_yeild = _calculationController.CalculateDividendYield(stock3);

                //Test Calculate P/E Ratio 𝑃𝑟𝑖𝑐𝑒
                stock3.PEratio = _calculationController.CalculatePERatioPrice(stock3.Price, stock3.LastDividend);

                //Test Calculate Volume Weighted Stock Price                  
                stock3.VolumeWeightedStockPrice = _calculationController.VolumeWeightedStockPrice(stock3.TradeList);
                //test display stock and trades
                _stockController.DisplayStock(stock3);




                //Stock4 adding 
                tradesstock4 = new List<Trade>();
                Trade trade8 = new Trade(DateTime.Now, 5, "sell", 50);
                tradesstock4.Add(trade8);
                Trade trade9 = new Trade(DateTime.Now, 5, "sell", 50);
                tradesstock4.Add(trade9);
                Stock stock4 = new Stock("GIN", "Preferred", 8, 2, 100, tradesstock4, 10);
                stocks.Add(stock4);
                // Test Calculate Dividend Yield 
                stock4.Divident_yeild = _calculationController.CalculateDividendYield(stock4);

                //Test Calculate P/E Ratio 𝑃𝑟𝑖𝑐𝑒
                stock4.PEratio = _calculationController.CalculatePERatioPrice(stock4.Price, stock4.LastDividend);

                //Test Calculate Volume Weighted Stock Price                  
                stock4.VolumeWeightedStockPrice = _calculationController.VolumeWeightedStockPrice(stock4.TradeList);
                //test display stock and trades
                _stockController.DisplayStock(stock4);


                //Stock5 adding 
                tradesstock5 = new List<Trade>();
                Trade trade10 = new Trade(DateTime.Now, 5, "sell", 50);
                tradesstock5.Add(trade10);
                Trade trade11 = new Trade(DateTime.Now, 5, "sell", 50);
                tradesstock5.Add(trade11);
                Trade trade12 = new Trade(DateTime.Now, 5, "sell", 50);
                tradesstock5.Add(trade12);
                Stock stock5 = new Stock("JOE", "Common", 13, 0, 250, tradesstock5, 80);
                stocks.Add(stock5);
                //  Test Calculate Dividend Yield method
                stock5.Divident_yeild = _calculationController.CalculateDividendYield(stock5);

                // Test Calculate P/E Ratio 𝑃𝑟𝑖𝑐𝑒
                stock5.PEratio = _calculationController.CalculatePERatioPrice(stock5.Price, stock5.LastDividend);

                //Test Calculate Volume Weighted Stock Price                  
                stock5.VolumeWeightedStockPrice = _calculationController.VolumeWeightedStockPrice(stock5.TradeList);

                //test display stock and trades
                _stockController.DisplayStock(stock5);

                //test display stocks and trades
                _stockController.DisplayStocks(stocks);
                //test Calculate All share index
                _calculationController.CalculateAllShareIndex(stocks);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Exception Message:" + ex.Message);
            }

        }


    }
}

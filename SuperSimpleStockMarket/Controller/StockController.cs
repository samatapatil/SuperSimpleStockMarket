using SuperSimpleStockMarket.Controller.Interface;
using SuperSimpleStockMarket.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSimpleStockMarket.Controller
{
    public class StockController : IStockController
    {
        ITradeController _tradeController;
        //constructor
        public StockController(ITradeController tradeController)
        {
            _tradeController = tradeController;
        }
        //method for Add stock
        public Stock AddStock()
        {//validatio
            double fix_div = double.NaN, price_value=0.0, par_value = double.NaN, last_div = 0.0;
            string stockSymbol, type;
            List<Trade> tds;
            try
            {
                
                    Console.WriteLine("\n*********************Add Stock************************");
                    //input values and nullcheck
                    Console.WriteLine("Enter Stock Symbol");
                     stockSymbol = Console.ReadLine();
                    Console.WriteLine("Enter type (Common or Preferred)");
                     type = Console.ReadLine();
                    if (type != null && (type != Constants.Constants.STOCK_TYPE_COMMON && type != Constants.Constants.STOCK_TYPE_Preferred))
                    {
                        Console.WriteLine("Please enter type Common or Preferred");
                    return null;
                     }

                    Console.WriteLine("Enter Last  Dividend");
                    string ld = Console.ReadLine();
                    if (ld != null)
                        last_div = Double.Parse(ld);

                    if (type == Constants.Constants.STOCK_TYPE_Preferred)
                    {
                        Console.WriteLine("Enter Fixed  Dividend");
                        string fd = Console.ReadLine();
                        if (fd != null)
                            fix_div = Double.Parse(fd);
                       
                    }
                    Console.WriteLine("Enter par");
                    string par = Console.ReadLine();
                    if (par != null)
                        par_value = Double.Parse(par);

                    Console.WriteLine("Enter price");
                    string price = Console.ReadLine();
                    if (price != null)
                         price_value = Double.Parse(price);
                     tds = new List<Trade>();
                    Trade trade;
                    string choice = string.Empty;
                    //add trades
                    do
                    {

                        trade = _tradeController.AddTrade();
                        if (trade != null)
                        {
                            tds.Add(trade);
                        }
                        else
                            Console.WriteLine("Please enter valid value");

                        Console.WriteLine("Do you want to Add trade:type(y/n)");
                        choice = Console.ReadLine();

                    } while (choice == "y");
                    
               
                Stock stock = new Stock(stockSymbol, type, last_div, fix_div, par_value, tds, price_value);
                return stock;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception message :" + ex.Message);
                return null;
            }
            
        }
        //method for display stock
        public void DisplayStock(Stock stock)
        {
            try
            {
                //checking stock is not null
                if (stock != null)
                {
                   
                        Console.WriteLine("\n######################################## Display Stock ###########################");

                        Console.WriteLine("\nStock Symbol:" + stock.Symbol + "\n Stock type:" + stock.Type + "\n LastDividend: " + stock.LastDividend + "\n FixedDividend: " + stock.FixedDividend +
                            " \nParValue :" + stock.ParValue + "\n ----******Trades***********-------- :" + _tradeController.DisplayTrades(stock.TradeList) + "\nPrice: " + stock.Price );
                      
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Message:" + ex.Message);
            }
        }

        //method for display stocks
        public void DisplayStocks(IList<Stock> stocks)
        {
            try
            {
                //checking stocks are not null
                if (stocks != null)
                {
                    int i = 1;

                    foreach (var stock in stocks)
                    {
                        Console.WriteLine("\n########################### Stock" + i + " #################################");

                        Console.WriteLine("\nStock Symbol:" + stock.Symbol + "\n Stock type:" + stock.Type + "\n LastDividend: " + stock.LastDividend + "\n FixedDividend: " + stock.FixedDividend +
                            " \nParValue :" + stock.ParValue + "\n ----******Trades***********-------- :" + _tradeController.DisplayTrades(stock.TradeList) + "\nPrice: " + stock.Price + "\n Divident_yeild :" + stock.Divident_yeild +
                            "\n P/E ratio : " + stock.PEratio + "\n Volume Weighted Stock Price: " + stock.VolumeWeightedStockPrice);
                        i++;

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Message:" + ex.Message);
            }
        }
    }
}

using SuperSimpleStockMarket.Controller.Interface;
using SuperSimpleStockMarket.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSimpleStockMarket.Controller
{
    public class CalculationController : ICalculationController
    {
       //method for calculating divident yield
        public double CalculateDividendYield(Stock stock)
        {
            Console.WriteLine("\n*************Dividend Yield ******************");
            try
            {
                double dividend_Yield=0.0;
                //checking stock is not null
                if (stock != null)
                {
                    if (stock.Type == Constants.Constants.STOCK_TYPE_COMMON)
                    {
                        //Common Dividend Yield 
                        Console.WriteLine("\n-----------Common Dividend Yield--------------");
                        dividend_Yield = stock.LastDividend / stock.Price;
                        Console.WriteLine("Common Dividend Yield:" + dividend_Yield + ".");
                    }
                    else if (stock.Type == Constants.Constants.STOCK_TYPE_Preferred)
                    {
                        // Preferred Dividend Yield 
                        Console.WriteLine("\n---------- Preferred Dividend Yield ---------------");
                        dividend_Yield = (stock.FixedDividend * stock.ParValue) / stock.Price;
                        Console.WriteLine("Preferred Dividend Yield:" + dividend_Yield + ".");
                    }
                    else
                    {
                        Console.WriteLine("stock type is not valid");
                    }
                }
                return dividend_Yield;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Message:" + ex.Message);
                return double.NaN;
            }
        }

        //method for calculating divident yield
        public double CalculatePERatioPrice(Double price, double dividend)
        {
            Console.WriteLine("\n*************PE Ratio Price*********************");
            try
            {
                
                double pE_Ratio_Price=double.NaN;
                //calculatin p/e ratio
                if (dividend != 0.0)
                   pE_Ratio_Price = price / dividend;
                else
                    Console.WriteLine("Can not divide by 0 while calculating p/e ratio");

                Console.WriteLine("P/E Ratio Price:" + pE_Ratio_Price + ".");
                
                return pE_Ratio_Price;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Message:" + ex.Message);
                return double.NaN;
            }
        }
        //method for calculating Volume Weighted Stock Price
        public double VolumeWeightedStockPrice(IList<Trade> trades)
        {
            Console.WriteLine("\n*********Volume Weighted Stock Price*************");
            try
            {
                double numerator_value = 0.0, denominator_value = 0.0,volumeWeightedStockPrice=0.0;
                if (trades != null)
                {
                    //Loop through each trades

                    foreach (var v in trades)
                    {
                        //checking trade time either it is in last 15 min or not
                        var ts = new TimeSpan(DateTime.Now.Ticks - v.Timestamp.Ticks);
                        if (ts.Minutes < 15)
                        {
                            numerator_value += v.Tradedprice * v.Quantityofshares;
                            denominator_value += v.Quantityofshares;
                        }
                    }
                    //calculating volume Weighted Stock Price
                    if (denominator_value!=0.0)
                    volumeWeightedStockPrice = numerator_value / denominator_value;
                    Console.WriteLine("Volume Weighted Stock Price:" + volumeWeightedStockPrice + ".");
                }
                return volumeWeightedStockPrice;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Message:" + ex.Message);
                return double.NaN;
            }
        }
        public double CalculateAllShareIndex(IList<Stock> stockList)
        
        {
            Console.WriteLine("\n************************************All Share Index******************************************");
            try
            {
                Double allShareIndex = 0.0;
                List<Double> priceList = new List<double>();
                if (stockList != null)
                {
                    //Loop through each stock
                    foreach (var stock in stockList)
                    {
                        priceList.Add(stock.Price);

                    }

                    //Check if there is any price
                    if (priceList.Count > 0)
                    {
                        double allTradeProd = 1.0;
                        double power = 1 / (double)priceList.Count;

                        //Loop through the priceList 
                        for (int i = 0; i < priceList.Count; i++)
                        {

                            allTradeProd = allTradeProd * priceList[i];
                        }
                        //calculating all Share Index
                        allShareIndex = Math.Pow(allTradeProd, power);

                        Console.WriteLine("All Share Index : " + allShareIndex);
                    }
                }
                return allShareIndex;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Message:" + ex.Message);
                return double.NaN;
            }
        }
    }
}

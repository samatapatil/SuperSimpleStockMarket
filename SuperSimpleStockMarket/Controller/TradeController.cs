using SuperSimpleStockMarket.Controller.Interface;
using SuperSimpleStockMarket.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperSimpleStockMarket.Controller
{

    public class TradeController : ITradeController
    {
        //method for Add stock
        public Trade AddTrade()
        {
            Int64 quantity_of_shares = 0;
            Double traded_price = 0.0;
            try
            {
                //need to add validation
                Console.WriteLine("\n*********************Add Trade for stock************************");

                //input values and nullcheck
                DateTime timestamp = DateTime.Now;
                Console.WriteLine("Enter Quantity of share");

                string quantityofshares = Console.ReadLine();
                if(quantityofshares!=null)
                    quantity_of_shares = Int64.Parse(quantityofshares);
                
                Console.WriteLine("Enter Indicator(buy/sell)");
                string indicator = Console.ReadLine();
                if (indicator != null && (indicator != Constants.Constants.INDICATOR_BUY && indicator != Constants.Constants.INDICATOR_SELL))
                    return null;
                
                Console.WriteLine("Enter tradedprice");
                string tradedprice = Console.ReadLine();
                if(tradedprice!=null)
                    traded_price = Double.Parse(tradedprice);
                
                Trade trade = new Trade(timestamp, quantity_of_shares, indicator, traded_price);
                return trade;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Message:" + ex.Message);
                return null;
            }

        }
        
        //method for display trades
        public string DisplayTrades(IList<Trade> trades)
        {
            try
            {
                string trad = string.Empty;

                //checking trades are not null
                if (trades != null)
                {
                    int i = 1;
                    if (trades != null)
                        foreach (var trade in trades)
                        {
                            string s = "\n--Trade" + i + "--" + "\nTimestamp:" + trade.Timestamp + "\n Indicator:" + trade.Indicator + "\n Quantityofshares: "
                                 + trade.Quantityofshares + "\n Tradedprice: " + trade.Tradedprice;
                            trad = trad + s;
                            i++;
                        }
                }
                return trad;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Message:" + ex.Message);
                return string.Empty;
            }
        }
    }
}
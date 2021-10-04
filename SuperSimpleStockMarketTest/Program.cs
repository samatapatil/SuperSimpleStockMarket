using SuperSimpleStockMarketTest.ControllerTest;
using System;

namespace SuperSimpleStockMarketTest
{
    class Program
    {
        static void Main(string[] args)
        {
            TestSuperSimpleStockMarket testSuperSimpleStockMarket = new TestSuperSimpleStockMarket();
            testSuperSimpleStockMarket.TestSuperSimpleStockMarketCalculation();
        }
    }
    public class TestSuperSimpleStockMarket
    {
        CalculationControllerTest controllerTest = new CalculationControllerTest();

        public void TestSuperSimpleStockMarketCalculation()
        {
            controllerTest.PerformStockCalculationTest();
        }
    }
}

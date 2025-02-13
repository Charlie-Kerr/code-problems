using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeProblems
{
    public class BestTimeBuySellStocksTWO : ICodeProblem
    {
        public Type Type => Type.MEDIUM;
        public List<string> Tags => new List<string> { "Array", "Dynamic Programming", "Greedy" };
        public string? Link => "https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/description/";
        public string? Description => "You are given an integer array prices where prices[i] is the price of a given stock on the ith day." +
            "\nOn each day, you may decide to buy and/or sell the stock. " +
            "You can only hold at most one share of the stock at any time. " +
            "However, you can buy it then immediately sell it on the same day." +
            "\nFind and return the maximum profit you can achieve.";
        public DateOnly Date => new DateOnly(2025, 01, 30);
        public class Solution()
        {
            public static int MaxProfit(int[] prices)
            {
                int profit = 0;

                for (int i = 1; i < prices.Length; i++)
                {
                    if (prices[i] > prices[i - 1])
                        profit += prices[i] - prices[i - 1];
                }

                return profit;
            }
        }
        [TestClass]
        public class Tests() 
        {
            [TestMethod]
            public void case1()
            {
                int[] prices = { 7, 1, 5, 3, 6, 4};
                int expected = 7;
                int actual = Solution.MaxProfit(prices);
                Assert.AreEqual(expected, actual);
            }
            [TestMethod]
            public void case2() 
            {
                int[] prices = { 1, 2, 3, 4, 5 };
                int expected = 4;
                int actual = Solution.MaxProfit(prices);
                Assert.AreEqual(expected, actual);
            }
            [TestMethod]
            public void case3() 
            {
                int[] prices = { 7, 6, 4, 3, 1 };
                int expected = 0;
                int actual = Solution.MaxProfit(prices);
                Assert.AreEqual(expected, actual);
            }
        }
    }
}

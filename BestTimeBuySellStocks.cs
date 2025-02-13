using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeProblems
{
    public class BestTimeBuySellStocks : ICodeProblem
    {
        public Type Type => Type.EASY;
        public List<string> Tags => new List<string> { "Array", "Dynamic Programming" };
        public string? Link => "https://leetcode.com/problems/best-time-to-buy-and-sell-stock/description/";
        public string? Description => "You are given an array prices where prices[i] is the price of a given stock on the ith day." +
            "\nYou want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock." +
            "\nReturn the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.";
        public DateOnly Date => new DateOnly(2025, 01, 30);
        public class Solution()
        {
            public static int MaxProfit(int[] prices)
            {
                int profit = 0;
                int buyPrice = prices[0];
                for (int i = 0; i < prices.Length; i++)
                {
                    if (buyPrice > prices[i])
                    {
                        buyPrice = prices[i];
                    }

                    profit = Math.Max(profit, prices[i] - buyPrice);
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
                int[] prices = { 7, 1, 5, 3, 6, 4 };
                int expected = 5;
                int actual = Solution.MaxProfit(prices);
                Assert.AreEqual(expected, actual);
            }
            [TestMethod]
            public void case2()
            {
                int[] prices = { 7, 6, 4, 3, 1 };
                int expected = 0;
                int actual = Solution.MaxProfit(prices);
                Assert.AreEqual(expected, actual);
            }
        }
    }
}

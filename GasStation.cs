using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeProblems
{
    public class GasStation : ICodeProblem
    {
        public Type Type => Type.MEDIUM;
        public List<string> Tags => new List<string> { "Array", "Greedy" };
        public string? Link => "https://leetcode.com/problems/gas-station/description/";
        public string? Description => "There are n gas stations along a circular route, where the amount of gas at the ith station is gas[i]." +
            "\nYou have a car with an unlimited gas tank and it costs cost[i] of gas to travel from the ith station to its next (i + 1)th station. " +
            "You begin the journey with an empty tank at one of the gas stations." +
            "\nGiven two integer arrays gas and cost, return the starting gas station's index if you can travel around the circuit once in the clockwise direction, otherwise return -1. " +
            "If there exists a solution, it is guaranteed to be unique.";
        public DateOnly Date => new DateOnly(2025, 01, 31);
        public class Solution()
        {
            public static int CanCompleteCircuit(int[] gas, int[] cost)
            {
                int gasTank;
                int n = gas.Length;
                int nextStation = 0;
                int count;
                if (gas.Sum() < cost.Sum()) return -1;
                for (int i = 0; i < n; i++)
                {
                    gasTank = 0;
                    count = 0;
                    if (gas[i] >= cost[i])
                    {
                        gasTank = gas[i];//fill up
                        nextStation = i;
                        while (count < n)
                        {
                            gasTank = gasTank - cost[nextStation];//travel
                            if (gasTank < 0) break;
                            nextStation++;
                            if (nextStation >= n)
                            {
                                nextStation = 0;
                            }
                            gasTank = gasTank + gas[nextStation];//fill
                            count++;
                        }
                        if (count == n) return i;
                    }
                }

                return -1;
            }
        }
        [TestClass]
        public class Tests() 
        {
            [TestMethod]
            public void case1()
            {
                int[] gas = { 1, 2, 3, 4, 5 };
                int[] cost = { 3, 4, 5, 1, 2 };
                int actual = Solution.CanCompleteCircuit(gas, cost);
                int expected = 3;
                Assert.AreEqual(actual, expected);
            }
            [TestMethod]
            public void case2()
            {
                int[] gas = {2,3,4};
                int[] cost = {3,4,3};
                int actual = Solution.CanCompleteCircuit(gas, cost);
                int expected = -1;
                Assert.AreEqual(actual,expected);
            }
        }
    }
}

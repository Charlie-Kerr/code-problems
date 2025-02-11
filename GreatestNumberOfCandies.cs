using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeProblems
{
    //Copy this class and replace TEMPLATE_CLASS with the name of the problem
    public class GreatestNumberOfCandies : ICodeProblem
    {
        public Type Type => Type.EASY;
        public List<string> Tags => new List<string> { "Array" };
        public string? Link => "https://leetcode.com/problems/kids-with-the-greatest-number-of-candies/";
        public string? Description => "There are n kids with candies. " +
            "You are given an integer array candies, where each candies[i] represents the number of candies the ith kid has, and an integer extraCandies, denoting the number of extra candies that you have." +
            "\nReturn a boolean array result of length n, where result[i] is true if, after giving the ith kid all the extraCandies, they will have the greatest number of candies among all the kids, or false otherwise." +
            "\nNote that multiple kids can have the greatest number of candies.";
        public DateOnly Date => new DateOnly(2024, 11, 18);
        public class Solution()
        {
            public static IList<bool> KidsWithCandies(int[] candies, int extraCandies)
            {
                int current = 0;
                List<bool> result = new List<bool>();
                int candiesMax = 0;
                for (int i = 0; i < candies.Length; i++)
                {
                    candiesMax = Math.Max(candiesMax, candies[i]);
                }
                for (int i = 0; i < candies.Length; i++)
                {
                    current = candies[i] + extraCandies;
                    if (current >= candiesMax)
                    {
                        result.Add(true);
                    }
                    else
                    {
                        result.Add(false);
                    }
                }
                return result;
            }
        }
        [TestClass]
        public class Tests() 
        {
            [TestMethod]
            public void case1()
            {
                int[] candies = new int[] { 2, 3, 5, 1, 3 };
                int extraCandies = 3;
                IList<bool> expected = [ true,true,true,false,true ];
                IList<bool> actual = GreatestNumberOfCandies.Solution.KidsWithCandies(candies, extraCandies);
                Assert.IsTrue(expected.SequenceEqual(actual));
            }
            [TestMethod]
            public void case2()
            {
                int[] candies = new int[] { 4, 2, 1, 1, 2 };
                int extraCandies = 1;
                IList<bool> expected = [true, false, false, false, false];
                IList<bool> actual = GreatestNumberOfCandies.Solution.KidsWithCandies(candies, extraCandies);
                Assert.IsTrue(expected.SequenceEqual(actual));
            }
            [TestMethod]
            public void case3()
            {
                int[] candies = new int[] { 12, 1, 12 };
                int extraCandies = 10;
                IList<bool> expected = [true, false, true];
                IList<bool> actual = GreatestNumberOfCandies.Solution.KidsWithCandies(candies, extraCandies);
                Assert.IsTrue(expected.SequenceEqual(actual));
            }
        }
    }
}

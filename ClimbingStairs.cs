using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeProblems
{
    public class ClimbingStairs : ICodeProblem
    {
        public Type Type => Type.EASY;
        public List<string> Tags => new List<string> { "Math","Dynamic Programming","Memoization" };
        public string? Link => "https://leetcode.com/problems/climbing-stairs/description/";
        public string? Description => "You are climbing a staircase. It takes n steps to reach the top." +
            "\nEach time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?";
        public DateOnly Date => new DateOnly(2025, 03, 03);
        public class Solution()
        {
            public static int ClimbStairs(int n)
            {
                //n = n-1 + n-2
                int count1 = 1;
                int count2 = 2;
                int temp = 0;
                if (n == 1)
                {
                    return count1;
                }
                if (n == 2)
                {
                    return count2;
                }
                for (int i = 3; i <= n; i++)
                {
                    temp = count2;
                    count2 = count2 + count1;
                    count1 = temp;
                }
                return count2;
            }
        }
        [TestClass]
        public class Tests() 
        {
            [TestMethod]
            public void case1()
            {
                Assert.AreEqual(2, Solution.ClimbStairs(2));
            }
            [TestMethod]
            public void case2() 
            { 
                Assert.AreEqual(3, Solution.ClimbStairs(3));
            }
            [TestMethod]
            public void case3() 
            { 
                Assert.AreEqual(5, Solution.ClimbStairs(4));
            }
            [TestMethod]
            public void case4()
            {
                Assert.AreEqual(8, Solution.ClimbStairs(5));
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeProblems
{
    public class JumpGameTWO : ICodeProblem
    {
        public Type Type => Type.MEDIUM;
        public List<string> Tags => new List<string> { "Array", "Dynamic Programming", "Greedy" };
        public string? Link => "https://leetcode.com/problems/jump-game-ii/description/";
        public string? Description => "You are given a 0-indexed array of integers nums of length n." +
            " You are initially positioned at nums[0]." +
            "\nEach element nums[i] represents the maximum length of a forward jump from index i." +
            " In other words, if you are at nums[i], you can jump to any nums[i + j] where:" +
            "\n0 <= j <= nums[i] and\ni + j < n" +
            "\nReturn the minimum number of jumps to reach nums[n - 1]. " +
            "The test cases are generated such that you can reach nums[n - 1].";
        public DateOnly Date => new DateOnly(2025, 01, 30);
        public class Solution()
        {
            public static int Jump(int[] nums)
            {
                int jumps = 0, farthest = 0, end = 0;

                for (int i = 0; i < nums.Length - 1; i++)
                {
                    farthest = Math.Max(farthest, i + nums[i]);
                    if (i == end)
                    {
                        jumps++;
                        end = farthest;
                        if (farthest >= nums.Length) break;
                    }
                }

                return jumps;
            }
        }
        [TestClass]
        public class Tests() 
        {
            [TestMethod]
            public void case1()
            {
                int[] nums = [2, 3, 1, 1, 4];
                int expected = 2;
                int output = Solution.Jump(nums);
                Assert.AreEqual(expected, output);
            }
            [TestMethod]
            public void case2()
            {
                int[] nums = [2, 3, 0, 1, 4];
                int expected = 2;
                int output = Solution.Jump(nums);
                Assert.AreEqual(expected, output);
            }
        }
    }
}

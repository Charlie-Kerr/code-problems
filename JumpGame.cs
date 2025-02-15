using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeProblems
{
    public class JumpGame : ICodeProblem
    {
        public Type Type => Type.MEDIUM;
        public List<string> Tags => new List<string> { "Array","Dynamic Programming", "Greedy" };
        public string? Link => "https://leetcode.com/problems/jump-game/?envType=study-plan-v2&envId=top-interview-150";
        public string? Description => "You are given an integer array nums." +
            "You are initially positioned at the array's first index, and each element in the array represents your maximum jump length at that position." +
            "\nReturn true if you can reach the last index, or false otherwise.";
        public DateOnly Date => new DateOnly(2025, 01, 30);
        public class Solution()
        {
            public static bool CanJump(int[] nums)
            {
                int target = nums.Length - 1;
                for (int i = nums.Length - 2; i >= 0; i--)
                {
                    if (nums[i] >= target - i)
                    {
                        target = i;
                    }
                }

                return target == 0;
            }
        }
        [TestClass]
        public class Tests() 
        {
            [TestMethod]
            public void case1()
            {
                int[] nums = [2, 3, 1, 1, 4];
                Assert.IsTrue(Solution.CanJump(nums));
            }
            [TestMethod]
            public void case2()
            {
                int[] nums = [3, 2, 1, 0, 4];
                Assert.IsFalse(Solution.CanJump(nums));
            }
        }
    }
}

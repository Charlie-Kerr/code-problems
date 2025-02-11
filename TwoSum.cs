using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CodeProblems
{
    public class TwoSum : ICodeProblem
    {
        public Type Type => Type.EASY;
        public List<string> Tags => new List<string> { "Array", "Hash Table" };
        public string? Link => "https://neetcode.io/problems/two-integer-sum";
        public string? Description => "Given an array of integers nums and an integer target, return the indices i and j such that nums[i] + nums[j] == target and i != j." +
            "\nYou may assume that every input has exactly one pair of indices i and j that satisfy the condition." +
            "\nReturn the answer with the smaller index first.";
        public DateOnly Date => new DateOnly(2025, 02, 08);
        public class Solution()
        {
            public static int[] TwoSum(int[] nums, int target)
            {
                //dict where target-i is key, int i is value
                //when we find a value at nums[i] that is already in the dict, return the value at that key and i
                Dictionary<int, int> dict = new Dictionary<int, int>();
                for (int i = 0; i < nums.Length; i++)
                {
                    if (dict.ContainsKey(nums[i]))
                    {
                        return new int[] { dict[nums[i]], i };
                    }
                    dict.Add(target - nums[i], i);
                }
                return new int[] { 0 }; //in the problem statement, it is guaranteed that there is exactly one solution
            }
        }

        [TestClass]
        public class Tests() 
        {
            [TestMethod]
            public void case1()
            {
                int[] nums = new int[] { 3 , 4 , 5, 6 };
                int target = 7;
                int[] expected = new int[] { 0, 1 };
                int[] actual = TwoSum.Solution.TwoSum(nums, target);
                Assert.IsTrue(expected.SequenceEqual(actual));
                Console.WriteLine(toString(nums, target, expected, actual));
            }
            [TestMethod]
            public void case2() 
            {
                int[] nums = new int[] { 4, 5, 6 };
                int target = 10;
                int[] expected = new int[] { 0, 2 };
                int[] actual = TwoSum.Solution.TwoSum(nums, target);
                Assert.IsTrue(expected.SequenceEqual(actual));
                Console.WriteLine(toString(nums, target, expected, actual)); //surely there has to be a better way to do this
            }

            public string toString(int[] nums, int target, int[] expected, int[] actual)
            {
                StringBuilder result = new StringBuilder();
                result.Append($"nums = [{printArray(nums)}]\n");
                result.Append($"target = [{target.ToString()}]\n");
                result.Append($"expected = [{printArray(expected)}]\n");
                result.Append($"actual = [{printArray(actual)}]");
                return result.ToString();
            }

            public string printArray(int[] array) 
            {
                StringBuilder result = new StringBuilder();
                foreach (int i in array)
                {
                    result.Append($"{i.ToString()}, ");
                }
                return result.ToString();
            }
        }
    }
}

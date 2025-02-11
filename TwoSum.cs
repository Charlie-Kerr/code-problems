using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeProblems
{
    public class TwoSum : ICodeProblem
    {
        public Type Type => Type.EASY;
        public List<string> tags => new List<string> { "test" };
        public string? Link => "https://neetcode.io/problems/two-integer-sum";
        public DateOnly Date => new DateOnly(2021, 10, 10);
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
            public void test()
            {
                Assert.IsTrue(new int[] { 0, 1 }.SequenceEqual(TwoSum.Solution.TwoSum(new int[] { 3 , 4 , 5 , 6 }, 7)));
                Assert.IsTrue(new int[] { 0, 2 }.SequenceEqual(TwoSum.Solution.TwoSum(new int[] { 4, 5, 6 }, 10)));
            }
        }
    }
}

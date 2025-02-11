using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeProblems
{
    public class LongestSubstring : ICodeProblem
    {
        public Type Type => Type.MEDIUM;
        public List<string> Tags => new List<string> { "Hash Table", "String", "Sliding Window" };
        public string? Link => "https://leetcode.com/problems/longest-substring-without-repeating-characters/";
        public string? Description => "Given a string s, find the length of the longest substring without repeating characters.";
        public DateOnly Date => new DateOnly(2024, 10, 04);
        public class Solution()
        {
            public int LengthOfLongestSubstring(string s)
            {
                int longestLength = 0;
                int count = 0;
                char[] substring = s.ToCharArray();
                List<char> longestSub = new List<char>();
                for (int i = 0; i < s.Length; i++)
                {
                    count = 0;
                    for (int j = i; j < s.Length; j++)
                    {
                        if (longestSub.Contains(substring[j]))
                        {
                            longestSub.Clear();
                            break;
                        }
                        else
                        {
                            longestSub.Add(substring[j]);
                            count++;
                            if (longestLength <= count) longestLength = count;
                        }
                    }
                }
                return longestLength;
            }
        }
        [TestClass]
        public class Tests() 
        {
            [TestMethod]
            public void test()
            {
                
            }
        }
    }
}

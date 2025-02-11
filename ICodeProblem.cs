using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeProblems
{
    public enum Type { EASY, MEDIUM, HARD }
    public class JSONReader
    {
        public static List<string> Read(string path)
        {
            return new List<string>(); //add JSON reader here
        }
    }
    internal interface ICodeProblem
    {
        //any class implementing ICodeProblem will need to be public NOT internal in order for Tests to run
        public Type Type { get; }
        public List<string> Tags { get; }
        public string? Link { get; }
        public string? Description { get; }
        public DateOnly Date { get; }
        class Solution { }
        [TestClass]
        class Tests { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeProblems
{
    //Copy this class and rename TEMPLATE_CLASS with the name of the problem
    //Use Shift + Enter: do not rename template class once copied!!
    public class TEMPLATE_CLASS : ICodeProblem
    {
        public Type Type => Type.EASY; //REPLACE TYPE
        public List<string> Tags => new List<string> { " " }; //ADD TAGS
        public string? Link => " "; //ADD LINK
        public string? Description => " "; //ADD DESCRIPTION
        public DateOnly Date => new DateOnly(2000, 01, 01); //REPLACE DATE
        public class Solution()
        {
            public static void TEMPLATE_METHOD() //REPLACE NAME
            {
                //ADD SOLUTION
            }
        }
        [TestClass]
        public class Tests() 
        {
            [TestMethod]
            public void test()
            {
                //ADD TEST
            }
        }
    }
}

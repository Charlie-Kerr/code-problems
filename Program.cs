using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeProblems
{
    internal class Program
    {
        const string path = "C:\\Users\\charl\\source\\repos\\CodeProblems";
        static void Main(string[] args)
        {
            List<ICodeProblem> problems = getProblems();
            string input = "";
            bool flag = false;
            Console.WriteLine("Welcome to my Leetcode/Neetcode/Hackerank repository project." +
                "\nYou can see all of the problems I have solved in C# and the test cases that were used to challenge each solution." +
                "\nYou can run and produce the test output of any of the problems by typing the number associated with a problem below." +
                "\nYou can quit the application using q.\n");
            while (input != "q") 
            {
                flag = false;
                for (int i = 0; i < problems.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {problems[i].GetType().Name}");
                }
                Console.WriteLine("\nSelect a problem:");
                while (!flag) 
                {
                    input = Console.ReadLine().ToString();
                    flag = checkInput(input, problems.Count);
                }
                if(input == "q") break;
                RunTests(problems[int.Parse(input) - 1]);
                Console.WriteLine("\nPress any key to continue or q to quit");
                input = Console.ReadLine();
            }
        }

        static bool checkInput(string input, int MAXINT) 
        {
            int value;
            if (input == "q") return true;
            try
            {
                value = int.Parse(input);
                if (value >= 1 && value <= MAXINT) return true;
                return false;
            }
            catch (Exception e) 
            {
                Console.WriteLine("Input was not in the right format please try again.");
                return false;
            }
        }

        static List<ICodeProblem> getProblems()
        {
            // Find all classes that implement ICodeProblem
            var problemTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => typeof(ICodeProblem).IsAssignableFrom(t) && !t.IsInterface && !t.IsAbstract && t.Name != "TEMPLATE_CLASS")
                .ToList();

            List<ICodeProblem> problems = new List<ICodeProblem>();
            foreach (System.Type type in problemTypes)
            {
                ICodeProblem? instance = Activator.CreateInstance(type) as ICodeProblem;
                if (instance != null)
                {
                    problems.Add(instance);
                }
                else
                {
                    Console.WriteLine($"Failed to create an instance of {type.FullName}");
                }
            }

            return problems;
        }

        static void RunTests(ICodeProblem problem)
        {
            // Get the nested Tests class
            var testClassType = problem.GetType().GetNestedType("Tests");

            if (testClassType == null)
            {
                Console.WriteLine($"No Tests class found for {problem}");
                return;
            }

            // Create an instance of the test class
            var testClassInstance = Activator.CreateInstance(testClassType);

            // Run each test method
            foreach (var method in typeof(TwoSum.Tests).GetMethods())
            {
                if (method.GetCustomAttributes(typeof(TestMethodAttribute), false).Length > 0)
                {
                    try
                    {
                        method.Invoke(testClassInstance, null);
                        Console.WriteLine($"{problem}.{method.Name} passed.");
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"{method.Name} failed: {e.Message}");
                    }
                }
            }
        }
    }
}

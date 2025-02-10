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
        //System.Type testClassType
        static void Main(string[] args)
        {
            List<ICodeProblem> problems = getProblems();
            //Console.WriteLine(problems[0].GetType().Name);
            Console.WriteLine(problems[0]);
            RunTests(problems[0]);
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

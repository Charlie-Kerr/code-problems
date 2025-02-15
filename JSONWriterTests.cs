using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeProblems
{
    [TestClass]
    public class JSONWriterTests
    {
        [TestMethod]
        public void testAssociateTagsToProblems()
        {
            try
            {
                string path = "tags.JSON";
                List<string> tags = JSONReader.readTags(path);
                List<ICodeProblem> problems = Program.getProblems();
                Dictionary<string, List<ICodeProblem>> tagDictionary = JSONWriter.associateTagsToProblems(tags, problems);
                foreach(string key in tagDictionary.Keys)
                {
                    if (tagDictionary[key].Count > 0)
                    {
                        Console.WriteLine($"Tag: {key}");
                        foreach (ICodeProblem problem in tagDictionary[key])
                        {
                            Console.WriteLine($"Problem: {problem.GetType().Name}");
                        }
                    }
                }
                Assert.IsTrue(tagDictionary.Count > 0, "The tag dictionary should not be empty.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Assert.Fail();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace CodeProblems
{
    [TestClass]
    public class JSONReaderTests
    {
        [TestMethod]
        public void readTagsTest()
        {
            string path = "tags.JSON";
            try
            {
                List<string> tags = JSONReader.readTags(path);
                Console.WriteLine($"Tags Count: {tags.Count}");
                foreach (string tag in tags)
                {
                    Console.WriteLine(tag);
                }
                Assert.IsTrue(tags.Count > 0, "The tags list should not be empty.");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Assert.Fail();
            }
        }
    }
}

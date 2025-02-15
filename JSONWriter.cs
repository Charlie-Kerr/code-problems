using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeProblems
{
    internal class JSONWriter
    {
        //code goes here :)
        public static Dictionary<string, List<ICodeProblem>> associateTagsToProblems(List<string> tags, List<ICodeProblem> problems) 
        {
            Dictionary<string, List<ICodeProblem>> tagDictionary = new Dictionary<string, List<ICodeProblem>>();
            foreach (string tag in tags)
            {
                tagDictionary.Add(tag, new List<ICodeProblem>());
            }
            foreach (ICodeProblem problem in problems)
            {
                foreach (string tag in problem.Tags)
                {
                    tagDictionary[tag].Add(problem);
                }
            }
            return tagDictionary;
        }
    }
}

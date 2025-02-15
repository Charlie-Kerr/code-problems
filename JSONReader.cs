using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace CodeProblems
{
    public class JSONReader
    {
        public static T readFile<T>(string path)
        {
            string text = File.ReadAllText(path);
            return JsonSerializer.Deserialize<T>(text);
        }
        public static List<string> readTags(string path)
        {
            List<string> tags = readFile<List<string>>(path);
            return tags;
        }


        //So we want to read in the list of tags from our JSON file and output a JSON File dictionary? detailing if each tag has a problem assigned to it
        //check that the dictionary contains all the problems found,if not add them to the dictionary JSON file
        //else read in dictionary from JSON and use to search for problems by tag
        //have different class for reader and for writer, different class for searching? or method perhaps a JSONSearcher class
        //new class or method to verify a problem when it has been added? so that tags are valid

    }
}

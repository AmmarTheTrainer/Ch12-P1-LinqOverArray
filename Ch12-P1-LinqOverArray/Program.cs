using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch12_P1_LinqOverArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***** Fun with LINQ to Objects *****\n");

            QueryOverStrings();

            Console.ReadLine();
        }

        private static void QueryOverStrings()
        {
            // Assume we have an array of strings.
            string[] currentVideoGames = {"Dota", "NeedFor Speed2SE", "Fallout 3", "Daxter", "System Shock 2"};

            // Build a query expression to find the items in the array
            // that have an embedded space.
            IEnumerable<string> subset = from g in currentVideoGames
                                         where g.Contains(" ")
                                         orderby g
                                         select g;

            foreach (string s in subset)
            {
                Console.WriteLine(s);
            }
        }
    }
}

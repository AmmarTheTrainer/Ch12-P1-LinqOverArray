using System;
using System.Collections;
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

            //QueryOverStrings();
            //QueryOverStringsWithExtensionMethods();
            //QueryOverStringsLongHand();
            //QueryOverInts();

            DefferedExecution();

            Console.ReadLine();
        }

        private static void DefferedExecution()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };
            
            // Get numbers less than ten.
            var subset = from i in numbers where i < 10 select i;
            
            // LINQ statement evaluated here!
            foreach (var i in subset)
                Console.WriteLine("{0} < 10", i);

            Console.WriteLine();
            
            // Change some data in the array.
            numbers[0] = 4;
            
            // Evaluated again!
            foreach (var j in subset)
                Console.WriteLine("{0} < 10", j);

            Console.WriteLine();

            ReflectOverQueryResults(subset);
        }

        static void QueryOverInts()
        {
            int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };
            // Use implicit typing here...
            var subset = from i in numbers where i < 10 select i;
            // ...and here.
            foreach (var i in subset)
                Console.WriteLine("Item: {0} ", i);
            ReflectOverQueryResults(subset);

            //int[] numbers = { 10, 20, 30, 40, 1, 2, 3, 8 };
            //// Print only items less than 10.
            //IEnumerable<int> subset = from i in numbers where i < 10 select i;
            //foreach (int i in subset)
            //    Console.WriteLine("Item: {0}", i);
            //ReflectOverQueryResults(subset);
        }

        static void ReflectOverQueryResults(object resultSet, string queryType = "Query Expressions")
        {
            Console.WriteLine();
            Console.WriteLine($"***** Info about your query using {queryType} *****");
            Console.WriteLine("resultSet is of type: {0}", resultSet.GetType().Name);
            Console.WriteLine("resultSet location: {0}", resultSet.GetType().Assembly.GetName().Name);
            Console.WriteLine();
        }

        private static void QueryOverStringsLongHand()
        {
            // Assume we have an array of strings.
            string[] currentVideoGames = {"Morrowind", "Uncharted 2", "Fallout 3", "Daxter", "System Shock 2"};
            string[] gamesWithSpaces = new string[5];
            for (int i = 0; i < currentVideoGames.Length; i++)
            {
                if (currentVideoGames[i].Contains(" "))
                    gamesWithSpaces[i] = currentVideoGames[i];
            }
            // Now sort them.
            Array.Sort(gamesWithSpaces);
            // Print out the results.
            foreach (string s in gamesWithSpaces)
            {
                if (s != null)
                    Console.WriteLine("Item: {0}", s);
            }
            Console.WriteLine();
        }

        private static void QueryOverStringsWithExtensionMethods()
        {
            string[] currentVideoGames = { "Dota", "NeedFor Speed2SE", "Fallout 3", "Daxter", "System Shock 2" };

            //currentVideoGames.

            IEnumerable<string> subset = currentVideoGames.Where(g => g.Contains(" ")).OrderBy(g => g).Select(g => g);

            ReflectOverQueryResults(subset);

            // Print out the results.
            foreach (string s in subset)
                Console.WriteLine("Item: {0}", s);

            //IEnumerable<string> subset = currentVideoGames.Where(g => g.Contains(" ")).OrderBy(g => g.Length).Select(g => g);
            //IEnumerable<int> subset = currentVideoGames.Where(g => g.Contains(" ")).OrderBy(g => g).Select(g => g.Length).OrderBy(g => g);

            //// Print out the results.
            //foreach (int s in subset)
            //  Console.WriteLine("Item: {0}", s);
        }

        private static void QueryOverStrings()
        {
            //IEnumerable<string> TypeName = new List<string>();
            ////IEnumerable<string> TypeName2 = new ArrayList();
            ////IEnumerable typeName3 = new ArrayList(); // This is correct

            // Assume we have an array of strings.
            string[] currentVideoGames = {"Dota", "NeedFor Speed2SE", "Fallout 3", "Daxter", "System Shock 2"};

            // Build a query expression to find the items in the array
            // that have an embedded space.
            IEnumerable<string> subset = from g in currentVideoGames
                                         where g.Contains(" ")
                                         orderby g
                                         select g;

            ReflectOverQueryResults(subset);

            // above query syntax is called "LINQ query expression"
            foreach (string s in subset)
            {
                Console.WriteLine(s);
            }
        }
    }
}

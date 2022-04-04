using System;
using System.Collections.Generic;

namespace IntroSyntax
{
    class Program
    {
        static void Main(string[] args)
        {
            // dataType varName = initialValue 
            int x = 5;

            // MultiplesOf3Or5(1, 10);
            // bool[] alternatingBools = AlternatingBooleans();
            PrintDictionary();
        }

        // Create a new loop that prints all values from 1-100 that are divisible by 3 or 5, but not both
        static void MultiplesOf3Or5(int start = 1, int end = 100)
        {
            for (int i = start; i <= end; i++)
            {
                bool divisibleBy3 = i % 3 == 0;
                bool divisibleBy5 = i % 5 == 0;
                bool divisibleBy5ByBoth = divisibleBy3 && divisibleBy5;

                if (divisibleBy5ByBoth == false && (divisibleBy3 || divisibleBy5))
                {
                    Console.WriteLine(i);
                }
            }
        }

        // Create an array of length 10 that alternates between true and false values, starting with true
        static bool[] AlternatingBooleans()
        {
            bool[] booleans = new bool[10];

            for (int i = 0; i < 10; i++)
            {
                bool isEven = i % 2 == 0;
                booleans[i] = isEven;
            }

            return booleans;
        }

        // Loop through the dictionary and print out each user's name and their associated ice cream flavor
        static void PrintDictionary()
        {
            Dictionary<string, string> favoriteIceCreamFlavors = new Dictionary<string, string>()
            {
                { "Kyle", "Mint" },
                { "Alwaleed", "Vanilla" }
            }
            ;

            favoriteIceCreamFlavors.Add("Neil", "Low Sugar Dark Chocolate");

            foreach (KeyValuePair<string, string> entry in favoriteIceCreamFlavors)
            {
                Console.WriteLine($"{entry.Key}'s favorite ice cream is: {entry.Value}");
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();

            SortedDictionary<char, int> symbolCount = new SortedDictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char curChar = input[i];

                if (!symbolCount.ContainsKey(curChar))
                {
                    symbolCount[curChar] = 0;
                }

                symbolCount[curChar]++;
            }

            foreach (var @char in symbolCount)
            {
                Console.WriteLine($"{@char.Key}: {@char.Value} time/s");
            }

            
        }

    }
}

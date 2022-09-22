using System;
using System.Collections.Generic;

namespace _06._Record_Unique_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int numEntries = int.Parse(Console.ReadLine());
            
            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < numEntries; i++)
            {
                string name = Console.ReadLine();

                names.Add(name);
            }

            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}

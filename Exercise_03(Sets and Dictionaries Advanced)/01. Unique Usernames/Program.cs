using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Unique_Usernames
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfEntries = int.Parse(Console.ReadLine());
            
            HashSet<string> names = new HashSet<string>();

            for (int i = 0; i < numberOfEntries; i++)
            {
                string name = Console.ReadLine();

                names.Add(name);
            }

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
        }
    }
}

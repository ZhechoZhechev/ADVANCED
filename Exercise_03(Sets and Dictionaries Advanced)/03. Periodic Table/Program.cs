using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main()
        {
            int numOfEntries = int.Parse(Console.ReadLine());

            HashSet<string> uniqueElements = new HashSet<string>();

            for (int i = 0; i < numOfEntries; i++)
            {
                string[] elements = Console.ReadLine().Split();

                for (int k = 0; k < elements.Length; k++)
                {
                    uniqueElements.Add(elements[k]);
                }
            }

            Console.WriteLine(string.Join(" ", uniqueElements.OrderBy(x => x)));

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main()
        {
            HashSet<int> setOne = new HashSet<int>();
            HashSet<int> setTwo = new HashSet<int>();

            int[] setsCount = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();

            for (int i = 0; i < setsCount[0]; i++)
            {
                setOne.Add(int.Parse(Console.ReadLine()));
            }
            
            for (int i = 0; i < setsCount[1]; i++)
            {
                setTwo.Add(int.Parse(Console.ReadLine()));
            }

            setOne.IntersectWith(setTwo);

            Console.WriteLine(string.Join(" ",setOne));
        }
    }
}

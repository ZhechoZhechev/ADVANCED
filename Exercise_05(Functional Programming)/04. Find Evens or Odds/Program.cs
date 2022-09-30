using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main()
        {
            string[] info = Console.ReadLine().Split();
            int start = int.Parse(info[0]);
            int end = int.Parse(info[1]);

            string condition = Console.ReadLine();

            Predicate<int> isOdd = x => x % 2 != 0;
            Predicate<int> even = x => x % 2 == 0;

            List<int> nums = new List<int>();
            
            for (int i = start; i <= end; i++)
            {
                nums.Add(i);
            }
            if (condition == "odd")
            {
                Console.WriteLine(string.Join(" ", nums.Where(x =>isOdd(x))));
            }
            else
            {
                Console.WriteLine(string.Join(" ", nums.Where(x => even(x))));
            }
        }
    }
}

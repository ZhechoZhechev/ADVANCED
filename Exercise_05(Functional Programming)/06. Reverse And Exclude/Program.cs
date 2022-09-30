using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main()
        {
            List<int> nums = Console.ReadLine().Split()
                .Select(int.Parse)
                .ToList();

            int divider = int.Parse(Console.ReadLine());

            Func<List<int>, int, List<int>> operation = (a, b) => a.Where(x => x % b != 0).Reverse().ToList();
            //{
            //    List<int> reversed = new List<int>();
            //    for (int i = a.Count -1; i >= 0; i--)
            //    {
            //        reversed.Add(a[i]);
            //    }
            //    reversed = reversed.Where(x => x % b != 0).ToList();
            //    return reversed;
            //};

            Console.WriteLine(string.Join(" ", operation(nums, divider)));
           
        }

    }
}

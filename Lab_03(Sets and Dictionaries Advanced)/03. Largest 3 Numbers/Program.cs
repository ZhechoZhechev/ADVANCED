using System;
using System.Linq;

namespace _03._Largest_3_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).OrderByDescending(x => x).ToArray();
            nums = nums.Take(3).ToArray();

            Console.WriteLine($"{string.Join(" ", nums)}");
        }
    }
}

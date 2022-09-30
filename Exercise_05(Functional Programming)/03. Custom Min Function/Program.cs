using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main()
        {
            int[] nums = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Func<int[], int> minNum = x =>
            {
                int smallest = int.MaxValue;

                foreach (var num in x)
                {
                    if (num < smallest)
                    {
                        smallest = num;
                    }
                }
                return smallest;
            };

            Console.WriteLine(minNum(nums));
        }
    }
}

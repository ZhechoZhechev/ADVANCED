using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main()
        {
            double[] numbers = Console.ReadLine().Split()
                .Select(double.Parse).ToArray();

            Dictionary<double, int> numsCount = new Dictionary<double, int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (!numsCount.ContainsKey(numbers[i]))
                {
                    numsCount.Add(numbers[i], 0);

                }
                numsCount[numbers[i]]++;
            }

            foreach (var item in numsCount)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }

        }
    }
}

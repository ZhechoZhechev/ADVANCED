using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._List_Of_Predicates
{
    class Program
    {
        static void Main()
        {
            int endRange = int.Parse(Console.ReadLine());

            HashSet<int> dividers = Console.ReadLine()
                .Split().Select(int.Parse).ToHashSet();

            int[] numbers = Enumerable.Range(1, endRange).ToArray();

            List<Predicate<int>> conditions = new List<Predicate<int>>();

            foreach (var num in dividers)
            {
                Predicate<int> cond = x => x % num == 0;
                conditions.Add(cond);
            }

            foreach (var num in numbers)
            {
                bool isDivisible = true;

                foreach (var cond in conditions)
                {
                    if (!cond(num))
                    {
                        isDivisible = false;
                        break;
                    }

                }
                if (isDivisible)
                {
                    Console.Write($"{num} ");
                }
            }

        }

    }
}

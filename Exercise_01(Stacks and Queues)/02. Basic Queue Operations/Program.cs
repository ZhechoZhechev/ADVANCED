using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;

namespace _02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] manipulator = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> ints = new Queue<int>();

            for (int i = 0; i < manipulator[0]; i++)
            {
                ints.Enqueue(input[i]);
            }

            for (int i = 0; i < manipulator[1]; i++)
            {
                ints.Dequeue();
            }

            if (ints.Contains(manipulator[2]))
            {
                Console.WriteLine("true");
            }
            else if (ints.Count > 0)
            {
                Console.WriteLine($"{ints.Min()}");
            }
            else
            {
                Console.WriteLine("0");
            }

        }
    }
}
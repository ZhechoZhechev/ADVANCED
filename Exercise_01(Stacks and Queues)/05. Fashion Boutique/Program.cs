using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new Stack<int>();

            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            foreach (var clothe in input)
            {
                clothes.Push(clothe);
            }

            int capacity = int.Parse(Console.ReadLine());

            int racks = 1;

            int tempCapasiti = capacity;

            while (clothes.Count > 0)
            {
                if (tempCapasiti - clothes.Peek() >= 0)
                {
                    tempCapasiti -= clothes.Pop();
                }
                else
                {
                    racks++;
                    tempCapasiti = capacity;
                }
            }

            Console.WriteLine(racks);
        }
    }
}
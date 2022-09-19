using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantityFood = int.Parse(Console.ReadLine());

            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> customers = new Queue<int>();
            foreach (var item in input)
            {
                customers.Enqueue(item);
            }

            Console.WriteLine(customers.Max());

            while (quantityFood >= 0 && customers.Count > 0)
            {
                if (quantityFood - customers.Peek() >= 0)
                {
                    quantityFood -= customers.Dequeue();
                }
                else
                {
                    break;
                }
            }

            if (customers.Count > 0)
            {
                Console.WriteLine($"Orders left: {string.Join(' ', customers)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }


        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    class Program
    {
        static void Main()
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queuedNums = new Queue<int>(numbers);

            Queue<int> evenNums = new Queue<int>();

            foreach (int num in queuedNums)
            {
                if (num % 2 == 0)
                {
                    evenNums.Enqueue(num);
                }
            }
            Console.WriteLine(string.Join(", ", evenNums));
        }
    }
}

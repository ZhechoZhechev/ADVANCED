using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Scheduling
{
    class Program
    {
        static void Main()
        {
            int[] tasks = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] threards = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int number = int.Parse(Console.ReadLine());

            Queue<int> thread = new Queue<int>(threards);
            Stack<int> task = new Stack<int>(tasks);

            while (task.Peek() != number)
            {
                if (thread.Peek() >= task.Peek())
                {
                    thread.Dequeue();
                    task.Pop();
                }
                else
                {
                    thread.Dequeue();
                }
            }
            Console.WriteLine($"Thread with value {thread.Peek()} killed task {number}");
            Console.WriteLine($"{string.Join(" ", thread)}");
        }
    }
}

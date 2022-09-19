using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var integers = Console.ReadLine().Split().Select(int.Parse).ToList();

            Stack<int> stack = new Stack<int>(integers);

            string input = string.Empty;

            while ((input = Console.ReadLine().ToLower()) != "end")
            {
                var commands = input.ToLower().Split();
                var action = commands[0];

                switch (action)
                {
                    case "add":
                        int numOne = int.Parse(commands[1]);
                        int numTwo = int.Parse(commands[2]);
                        stack.Push(numOne);
                        stack.Push(numTwo);
                        break;
                    case "remove":
                        int numsToRemove = int.Parse(commands[1]);
                        if (stack.Count >= numsToRemove)
                        {
                            for (int i = 1; i <= numsToRemove; i++)
                            {
                                stack.Pop();
                            }
                        }
                        break;
                }
            }
            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}

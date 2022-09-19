using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _01._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] manipulator = Console.ReadLine()
                .Split()
                .Select(int.Parse).ToArray();

            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < manipulator[0]; i++)
            {

                stack.Push(input[i]);
            }
            for (int i = 0; i < manipulator[1]; i++)
            {
                stack.Pop();
            }
            if (stack.Contains(manipulator[2]))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (stack.Count == 0)
                {
                    Console.WriteLine("0");
                }
                else
                {
                    int minSteck = MinSteck(stack);

                    Console.WriteLine(minSteck);
                }
            }


        }

        static int MinSteck(Stack<int> stack)
        {
            int input = int.MaxValue;
            foreach (var item in stack)
            {
                if (item < input)
                {
                    input = item;
                }
            }
            return input;
        }
    }
}
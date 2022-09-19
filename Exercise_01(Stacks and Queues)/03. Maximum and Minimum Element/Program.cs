using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            int numb = int.Parse(Console.ReadLine());
            for (int i = 0; i < numb; i++)
            {
                string[] manipulator = Console.ReadLine().Split();
                switch (manipulator[0])
                {
                    case "1":
                        stack.Push(int.Parse(manipulator[1]));
                        break;
                    case "2":
                        if (stack.Count > 0)
                            stack.Pop();
                        break;
                    case "3":
                        if (stack.Count > 0)
                            Console.WriteLine(stack.Max());
                        break;
                    case "4":
                        if (stack.Count > 0)
                            Console.WriteLine(stack.Min());
                        break;

                }

            }

            Console.WriteLine(string.Join(", ", stack).ToArray());

        }
    }
}
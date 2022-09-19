using System;
using System.Collections.Generic;

namespace _08._Balanced_Parenthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] input = Console.ReadLine().ToCharArray();

            Stack<char> stack = new Stack<char>();
            bool flag = true;

            for (int i = 0; i < input.Length; i++)
            {

                //{, }, (, ), [, ].
                if (input[i] == '{' || input[i] == '(' || input[i] == '[')
                {
                    stack.Push(input[i]);
                }
                else if (input[i] == '}' || input[i] == ')' || input[i] == ']')
                {
                    if (stack.Count == 0)
                    {
                        flag = false;
                        break;
                    }
                    if (input[i] == '}' && stack.Peek() == '{')
                    {
                        stack.Pop();
                    }
                    else if (input[i] == ')' && stack.Peek() == '(')
                    {
                        stack.Pop();
                    }
                    else if (input[i] == ']' && stack.Peek() == '[')
                    {
                        stack.Pop();
                    }

                }
            }

            if (stack.Count == 0 && flag)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
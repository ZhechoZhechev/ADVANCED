using System;
using System.Collections.Generic;

namespace _4._Matching_Brackets
{
    class Program
    {
        static void Main()
        {
            string sequence = Console.ReadLine();

            Stack<int> indexes = new Stack<int>();

            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] == '(')
                {
                    indexes.Push(i);
                }
                if (sequence[i] == ')')
                {
                    int startindex = indexes.Pop();

                    Console.WriteLine(sequence.Substring(startindex, i - startindex +1));
                }
            }
        }
    }
}

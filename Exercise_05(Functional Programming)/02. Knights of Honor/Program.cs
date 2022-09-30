using System;
using System.Linq;

namespace _02._Knights_of_Honor
{
    class Program
    {

        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => string.Format("Sir" + " " + x)).ToArray();

            Action<string[]> print = x => Console.WriteLine(string.Join(Environment.NewLine, x));

            print(words);
        }

    }
}

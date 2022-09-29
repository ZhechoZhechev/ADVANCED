using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Predicate<string> isCapital = x => char.IsUpper(x[0]);

            string[] inputIsCapital = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(x => isCapital(x)).ToArray();
            
            Console.WriteLine(string.Join(Environment.NewLine, inputIsCapital));
        }
    }
}

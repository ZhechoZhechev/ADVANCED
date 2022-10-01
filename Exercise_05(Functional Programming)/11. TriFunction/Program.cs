using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._TriFunction
{
    class Program
    {
        static void Main()
        {
            int treshold = int.Parse(Console.ReadLine());
            
            List<string> people = Console.ReadLine()
                .Split().ToList();

            Func<string, int, bool> isEqualOrMore = (x, y) => x.Sum(ch => ch) >= y;

            Action<List<string>, int, Func<string, int, bool>> letsPrintIt = (list, treshold, func) => Console.WriteLine(list.FirstOrDefault(x => func(x, treshold)));

            letsPrintIt(people, treshold, isEqualOrMore);
        }
    }
}

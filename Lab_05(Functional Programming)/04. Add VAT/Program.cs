using System;
using System.Linq;

namespace _04._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            const double VAT = 1.20;
            
            Func<string, string> addingVAT = x => (double.Parse(x) * VAT).ToString("F2");

            string[] pricesWithVAT = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(addingVAT).ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, pricesWithVAT));
        }
    }
}

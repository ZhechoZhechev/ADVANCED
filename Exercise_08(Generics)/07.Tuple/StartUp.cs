using System;

namespace _07.Tuple
{
   public class StartUp
    {
        static void Main()
        {
            Tuple<string, string> personAddress = new Tuple<string, string>();
            Tuple<string, int> personBeers = new Tuple<string, int>();
            Tuple<int, double> numbers = new Tuple<int, double>();

            string[] persAddInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] persBeersInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] numbersInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            personAddress.ItemOne = $"{persAddInfo[0]} {persAddInfo[1]}";
            personAddress.ItemTwo = persAddInfo[2];

            personBeers.ItemOne = persBeersInfo[0];
            personBeers.ItemTwo = int.Parse(persBeersInfo[1]);

            numbers.ItemOne = int.Parse(numbersInfo[0]);
            numbers.ItemTwo = double.Parse(numbersInfo[1]);

            Console.WriteLine(personAddress);
            Console.WriteLine(personBeers);
            Console.WriteLine(numbers);
        }
    }
}

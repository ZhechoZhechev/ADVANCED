using System;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main()
        {
            int wordLenght = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string[], Predicate<string>> printName = (names, condition) =>
            {
                foreach (var name in names)
                {
                    if (condition(name))
                    {
                        Console.WriteLine(name);
                    }
                }
            };

            printName(names, n => n.Length <= wordLenght);
        }
    }
}
 
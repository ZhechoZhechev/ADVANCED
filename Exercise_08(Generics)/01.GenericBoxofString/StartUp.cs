using System;

namespace _01.GenericBoxofString
{
    public class StartUp
    {
        static void Main()
        {
            Box<string> strings = new Box<string>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string item = Console.ReadLine();

                strings.Storage.Add(item);
            }

            Console.WriteLine(strings);
        }
    }
}

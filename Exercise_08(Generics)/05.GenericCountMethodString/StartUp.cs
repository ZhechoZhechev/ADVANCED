using System;

namespace _05.GenericCountMethodString
{
    public class StartUp
    {
        static void Main()
        {
            Box<string> items = new Box<string>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string item = Console.ReadLine();

                items.Storage.Add(item);
            }

            string itemToCompare = Console.ReadLine();

            Console.WriteLine(items.Count(itemToCompare));
        }
    }
}

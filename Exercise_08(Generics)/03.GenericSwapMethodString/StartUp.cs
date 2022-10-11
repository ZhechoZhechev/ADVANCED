using System;

namespace _03.GenericSwapMethodString
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

            string[] indexes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            items.Swap(int.Parse(indexes[0]), int.Parse(indexes[1]));

            Console.WriteLine(items);
        }
        
    }
}

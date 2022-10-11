using System;

namespace _04.GenericSwapMethodInteger
{
    class StartUp
    {
        static void Main()
        {
            Box<int> items = new Box<int>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int item = int.Parse(Console.ReadLine());

                items.Storage.Add(item);
            }

            string[] indexes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            items.Swap(int.Parse(indexes[0]), int.Parse(indexes[1]));

            Console.WriteLine(items);
        }
    }
}

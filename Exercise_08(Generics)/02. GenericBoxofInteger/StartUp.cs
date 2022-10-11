using System;

namespace _BoxofInteger
{
    public class StartUp
    {
        static void Main()
        {

            Box<int> integers = new Box<int>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int item = int.Parse(Console.ReadLine());

                integers.Storage.Add(item);
            }

            Console.WriteLine(integers);
        }
    }
}

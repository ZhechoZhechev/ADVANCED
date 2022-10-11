using System;

namespace _06.GenericCountMethodDouble
{
    public class StartUp
    {
        static void Main()
        {
            Box<double> items = new Box<double>();

            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                double item = double.Parse(Console.ReadLine());

                items.Storage.Add(item);
            }

            double itemToCompare = double.Parse(Console.ReadLine());

            Console.WriteLine(items.Count(itemToCompare));
        }
    }
}

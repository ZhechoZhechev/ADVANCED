using System;

namespace OurCustomList
{
     public class StartUp
    {
        static void Main()
        {
            CustomList list = new CustomList();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            list.RemoveAt(1);
            list.InsertAt(1, 323);

            list.Swap(0, 1);

            Console.WriteLine(list.Contains(322));
            list.ForEach(x => Console.Write($"{x} "));
        }
    }
}

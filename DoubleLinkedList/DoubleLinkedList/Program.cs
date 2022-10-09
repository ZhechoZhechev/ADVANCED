using System;

namespace DoubleLinkedList
{
    class Program
    {
        static void Main()
        {
            LinkedList linkedList = new LinkedList();

            linkedList.AddLast(1);
            linkedList.AddLast(2);
            linkedList.AddLast(3);
            linkedList.AddLast(4);

            linkedList.RemoveFirst();
            linkedList.RemoveLast();

            linkedList.ForEach(n => Console.WriteLine(n));

            //var array =  linkedList.ToArray();
        }
    }
}

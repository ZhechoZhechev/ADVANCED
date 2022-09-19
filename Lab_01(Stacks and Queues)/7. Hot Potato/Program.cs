using System;
using System.Collections.Generic;

namespace _7._Hot_Potato
{
    class Program
    {
        static void Main()
        {
            var ChildrenNames = Console.ReadLine().Split();
            int tossCount = int.Parse(Console.ReadLine());

            Queue<string> namesInQueue = new Queue<string>(ChildrenNames);

            int tossCounter = 1;

            while (namesInQueue.Count > 1)
            {
                string curKind = namesInQueue.Dequeue();
                
                if (tossCounter == tossCount)
                {
                    Console.WriteLine($"Removed {curKind}");
                    tossCounter = 1;
                    continue;
                }

                tossCounter++;
                namesInQueue.Enqueue(curKind);
            }

            Console.WriteLine($"Last is {namesInQueue.Dequeue()}");
        }
    }
}

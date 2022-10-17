using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._The_Fight_for_Gondor
{
    class Program
    {
        static void Main()
        {
            int numOfWaves = int.Parse(Console.ReadLine());

            int[] platesValues = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            Queue<int> plates = new Queue<int>(platesValues);

            for (int i = 1; i <= numOfWaves; i++)
            {
                int[] orcsValues = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
                Stack<int> orcs = new Stack<int>(orcsValues);
                if (i != 0 && i % 3 == 0)
                {
                    int newPlate = int.Parse(Console.ReadLine());
                    plates.Enqueue(newPlate);
                }

                while (plates.Any() && orcs.Any())
                {
                    int curPLate = plates.Peek();
                    int curOrc = orcs.Peek();
                    
                    if (curOrc == curPLate)
                    {
                        plates.Dequeue();
                        orcs.Pop();
                        if (plates.Count == 0)
                        {
                            Console.WriteLine($"The orcs successfully destroyed the Gondor's defense.");
                            Console.Write($"Orcs left: {String.Join(", ", orcs)}");
                            return;
                        }
                    }
                    else if (curOrc > curPLate)
                    {
                        curOrc -= curPLate;
                        orcs.Pop();
                        plates.Dequeue();
                        orcs.Push(curOrc);
                        if (plates.Count == 0)
                        {
                            Console.WriteLine($"The orcs successfully destroyed the Gondor's defense.");
                            Console.Write($"Orcs left: {String.Join(", ", orcs)}");
                            return;
                        }
                    }
                    else
                    {
                        curPLate -= curOrc;
                        orcs.Pop();
                        plates.Dequeue();
                        plates.Enqueue(curPLate);
                        for (int k = 0; k < plates.Count - 1 ; k++)
                        {
                            int curPlate = plates.Dequeue();
                            plates.Enqueue(curPlate);
                        }
                        if (plates.Count == 0)
                        {
                            Console.WriteLine($"The orcs successfully destroyed the Gondor's defense.");
                            Console.Write($"Orcs left: {String.Join(", ", orcs)}");
                            return;
                        }
                    }
                }
            }
            if (plates.Count != 0)
            {
                Console.WriteLine($"The people successfully repulsed the orc's attack.");
                Console.Write($"Plates left: {String.Join(", ", plates)}");
            }
        }
    }
}

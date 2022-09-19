using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Queue<int[]> information = new Queue<int[]>();
            for (int i = 0; i < n; i++)
            {
                int[] info = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                information.Enqueue(info);
            }
            int coner = 0;

            while (true)
            {
                int capacityTank = 0;
                bool flag = true;
                foreach (var item in information)
                {
                    capacityTank += item[0];
                    if (capacityTank - item[1] >= 0)
                    {
                        capacityTank -= item[1];
                    }
                    else
                    {
                        flag = false;
                        break;
                    }

                }
                if (flag)
                {
                    Console.WriteLine(coner);
                    break;
                }
                else
                {
                    int[] temp = information.Dequeue();
                    information.Enqueue(temp);
                    coner++;
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int priceBuiiet = int.Parse(Console.ReadLine());

            int sizeGunBarrel = int.Parse(Console.ReadLine());

            Stack<int> bulets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            Queue<int> locks = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            int intelligence = int.Parse(Console.ReadLine());

            while (bulets.Count > 0 && locks.Count > 0)
            {

                int counterSots = -1;
                for (int i = 0; i < sizeGunBarrel; i++)
                {
                    if (bulets.Peek() <= locks.Peek())
                    {
                        bulets.Pop();
                        locks.Dequeue();
                        intelligence -= priceBuiiet;

                        Console.WriteLine("Bang!");
                    }
                    else if (bulets.Peek() > locks.Peek())
                    {
                        bulets.Pop();
                        intelligence -= priceBuiiet;
                        Console.WriteLine("Ping!");
                    }
                    counterSots = i;
                    if (bulets.Count == 0 || locks.Count == 0)
                    {
                        break;
                    }
                }

                if (bulets.Count > 0 && counterSots == sizeGunBarrel - 1)
                {
                    Console.WriteLine("Reloading!");
                }
            }
            if (locks.Count == 0)
            {
                Console.WriteLine($"{bulets.Count} bullets left. Earned ${intelligence}");
            }
            else
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }

        }
    }
}
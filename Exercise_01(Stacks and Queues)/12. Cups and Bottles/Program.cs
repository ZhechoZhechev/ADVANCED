using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> cupsCcapacity = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            Stack<int> botllesCamacity = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            int wastedLitter = 0;
            while (cupsCcapacity.Count > 0 && botllesCamacity.Count > 0)
            {
                int botlle = botllesCamacity.Pop();
                int cup = cupsCcapacity.Peek();
                if (cup <= botlle)
                {
                    wastedLitter += botlle - cup;
                    cupsCcapacity.Dequeue();
                }
                else
                {
                    cup -= botlle;
                    while (cup > 0)
                    {
                        botlle = botllesCamacity.Pop();
                        if (cup <= botlle)
                        {

                            wastedLitter += botlle - cup;

                            cupsCcapacity.Dequeue();

                            break;

                        }
                        else
                        {
                            cup -= botlle;
                        }
                    }
                }
            }

            //o	"Bottles: {remainingBottles}" or "Cups: {remainingCups}"
            //"Wasted litters of water: {wastedLittersOfWater}".

            if (botllesCamacity.Count == 0)
            {
                Console.WriteLine($"Cups: {string.Join(' ', cupsCcapacity)}");
                Console.WriteLine($"Wasted litters of water: {wastedLitter}");
            }
            else
            {
                Console.WriteLine($"Bottles: {string.Join(' ', botllesCamacity)}");
                Console.WriteLine($"Wasted litters of water: {wastedLitter}");
            }
        }
    }
}
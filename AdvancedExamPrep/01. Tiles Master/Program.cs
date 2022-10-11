using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Tiles_Master
{
    class Program
    {
        static void Main()
        {
            int[] whiteTilesAreas = Console.ReadLine()
                .Split()
                .Select(int.Parse).ToArray();
            int[] greyTilesAreas = Console.ReadLine()
                .Split()
                .Select(int.Parse).ToArray();

            Stack<int> whiteTiles = new Stack<int>(whiteTilesAreas);
            Queue<int> greyTiles = new Queue<int>(greyTilesAreas);

            Dictionary<string, int> locatonAreaNeeded = new Dictionary<string, int>()

            {
                { "Sink", 40 },
                {"Oven", 50 },
                {"Countertop", 60 },
                {"Wall", 70 }
            };
            Dictionary<string, int> areaTilesCount = new Dictionary<string, int>();

            while (true)
            {
                if (!whiteTiles.Any() || !greyTiles.Any())
                {
                    break;
                }

                int curWiteTile = whiteTiles.Peek();
                int curGreyTiel = greyTiles.Peek();
                bool fitsTheTable = false;

                if (curWiteTile == curGreyTiel)
                {
                    int curGeryWhiteTile = curWiteTile + curGreyTiel;
                    if (locatonAreaNeeded.ContainsValue(curGeryWhiteTile))
                    {
                        string curArea = locatonAreaNeeded.FirstOrDefault(x => x.Value == curGeryWhiteTile).Key;
                        if (!areaTilesCount.ContainsKey(curArea))
                        {
                            areaTilesCount[curArea] = 0;
                        }
                        areaTilesCount[curArea]++;
                        fitsTheTable = true;
                    }
                    if (!fitsTheTable)
                    {
                        if (!areaTilesCount.ContainsKey("Floor"))
                        {
                            areaTilesCount["Floor"] = 0;
                        }
                        areaTilesCount["Floor"]++;
                    }
                    if (whiteTiles.Any())
                    {
                        whiteTiles.Pop();
                    }
                    if (greyTiles.Any())
                    {
                        greyTiles.Dequeue();
                    }

                }
                else
                {
                    int curWhiteToReinsert = whiteTiles.Pop() / 2;
                    whiteTiles.Push(curWhiteToReinsert);

                    int curGreyToReinsert = greyTiles.Dequeue();
                    greyTiles.Enqueue(curGreyToReinsert);
                }

            }
            PrintWiteGeyTiles(whiteTiles, greyTiles);

            var areaTilesCountSorted = areaTilesCount.OrderByDescending(x => x.Value).ThenBy(y => y.Key);

            foreach (var area in areaTilesCountSorted)
            {
                Console.WriteLine($"{area.Key}: {area.Value}");
            }

            static void PrintWiteGeyTiles(Stack<int> stack, Queue<int> queue)
            {
                if (stack.Count == 0)
                {
                    Console.WriteLine("White tiles left: none");
                }
                else
                {
                    Console.WriteLine($"White tiles left: {string.Join(", ", stack)}");
                }

                if (queue.Count == 0)
                {
                    Console.WriteLine("Grey tiles left: none");
                }
                else
                {
                    Console.WriteLine($"Grey tiles left: {string.Join(", ", queue)}");
                }

            }
        }

    }
}

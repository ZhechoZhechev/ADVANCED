using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Bakery_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] waterInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse).ToArray();
            Queue<double> water = new Queue<double>(waterInput);

            double[] flourInput = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse).ToArray();
            Stack<double> flour = new Stack<double>(flourInput);

            Dictionary<string, double> waterNeeded = new Dictionary<string, double>()

            {
                {"Croissant", 50 },
                {"Muffin", 40 },
                {"Baguette", 30 },
                {"Bagel", 20 }
            };

            Dictionary<string, int> productPerCount = new Dictionary<string, int>();

            while (flour.Any() && water.Any())
            {
                double curWater = water.Peek();
                double curFlour = flour.Peek();
                double total = curWater + curFlour;
                double waterPercentage = (curWater * 100) / total;
                if (waterNeeded.ContainsValue(waterPercentage))
                {
                    string curProduct = waterNeeded.FirstOrDefault(x => x.Value == waterPercentage).Key;
                    AddToDictionary(water, flour, productPerCount, curProduct);
                }
                else
                {
                    string curProduct = "Croissant";
                    if (curWater > curFlour)
                    {
                        AddToDictionary(water, flour, productPerCount, curProduct);
                    }
                    else
                    {
                        double excessiveFlour = curFlour - curWater;
                        AddToDictionary(water, flour, productPerCount, curProduct);
                        flour.Push(excessiveFlour);
                    }
                    //if (!productPerCount.ContainsKey("Croissant"))
                    //{
                    //    productPerCount["Croissant"] = 0;
                    //}
                    //var currentFlowerr = flour.Pop();
                    //var currentWater = water.Dequeue();
                    //var flourReduced = currentFlowerr - currentWater;
                    //productPerCount["Croissant"]++;
                    //flour.Push(flourReduced);
                }
            }
            Print(water, flour, productPerCount);
        }

        private static void Print(Queue<double> water, Stack<double> flour, Dictionary<string, int> productPerCount)
        {
            var productsOrdered = productPerCount.OrderByDescending(x => x.Value).ThenBy(x => x.Key);
            foreach (var prod in productsOrdered)
            {
                Console.WriteLine($"{prod.Key}: {prod.Value}");
            }
            var flourLeft = flour.Count == 0 ? "None" : string.Join(", ", flour);
            var waterLeft = water.Count == 0 ? "None" : string.Join(", ", water);

            Console.WriteLine($"Water left: {waterLeft}");
            Console.WriteLine($"Flour left: {flourLeft}");
        }

        private static void AddToDictionary(Queue<double> water, Stack<double> flour, Dictionary<string, int> productPerCount, string curProduct)
        {
            if (!productPerCount.ContainsKey(curProduct))
            {
                productPerCount[curProduct] = 0;
            }
            productPerCount[curProduct] += 1;
            water.Dequeue();
            flour.Pop();
        }
    }
}

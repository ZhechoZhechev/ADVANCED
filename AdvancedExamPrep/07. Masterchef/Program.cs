using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Masterchef
{
    class Program
    {
        static void Main()
        {
            int[] ingredientsValues = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            Queue<int> ingredients = new Queue<int>(ingredientsValues);

            int[] freshnessValues = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            Stack<int> freshness = new Stack<int>(freshnessValues);

            Dictionary<string, int> freshnessNeeded = new Dictionary<string, int>()
            {
                {"Dipping sauce", 150 },
                {"Green salad", 250 },
                {"Chocolate cake", 300 },
                {"Lobster", 400 }
            };

            Dictionary<string, int> productPerFreshness = new Dictionary<string, int>()
            {
                {"Dipping sauce", 0 },
                {"Green salad", 0 },
                {"Chocolate cake", 0 },
                {"Lobster", 0 }
            };

            while (ingredients.Any() && freshness.Any()) 
            {
                int curIndregent = ingredients.Peek();
                int curFreshness = freshness.Peek();
                int totaFreshness = curIndregent * curFreshness;

                if (freshnessNeeded.ContainsValue(totaFreshness))
                {
                    var curKey = freshnessNeeded.FirstOrDefault(x => x.Value == totaFreshness).Key;
                    //if (!productPerFreshness.ContainsKey(curKey))
                    //{
                    //    productPerFreshness[curKey] = 0;
                    //}
                    productPerFreshness[curKey]++;
                    ingredients.Dequeue();
                    freshness.Pop();
                }
                else if (curIndregent == 0)
                {
                    ingredients.Dequeue();
                    continue;
                }
                else
                {
                    freshness.Pop();
                    ingredients.Dequeue();
                    ingredients.Enqueue(curIndregent + 5);
                }
            }

            if (productPerFreshness.Any(x => x.Value == 0)) Console.WriteLine("You were voted off. Better luck next year.");
            else Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            if (ingredients.Count > 0) Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            
            var dishesOrderd = productPerFreshness.Where(x => x.Value > 0).OrderBy(x => x.Key);
            foreach (var dish in dishesOrderd)
            {
                Console.WriteLine($" # {dish.Key} --> {dish.Value}");
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _13._Bombs
{
    class Program
    {
        static void Main()
        {
            int[] effects = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] casings = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Queue<int> bombEffect = new Queue<int>(effects);
            Stack<int> casing = new Stack<int>(casings);

            Dictionary<string, int> bombPerMaterials = new Dictionary<string, int>()
            {
                { "Datura Bombs", 40 },
                { "Cherry Bombs", 60 },
                { "Smoke Decoy Bombs", 120 },
            };
            Dictionary<string, int> bombPerCount = new Dictionary<string, int>()
            {
                { "Datura Bombs", 0 },
                { "Cherry Bombs", 0 },
                { "Smoke Decoy Bombs", 0 },
            };
            while (bombEffect.Any() && casing.Any())
            {
                if (bombPerCount.All(x => x.Value >= 3))
                {
                    break;
                }
                int curBombEf = bombEffect.Peek();
                int curCasing = casing.Peek();
                int matSum = curBombEf + curCasing;
                if (bombPerMaterials.ContainsValue(matSum))
                {
                    var bombToAdd = bombPerMaterials.First(x => x.Value == matSum).Key;
                    bombPerCount[bombToAdd]++;
                    bombEffect.Dequeue();
                    casing.Pop();
                }
                else
                {
                    casing.Pop();
                    casing.Push(curCasing - 5);
                }
            }
            string result;
            result = bombPerCount.All(x => x.Value >= 3) ? "Bene! You have successfully filled the bomb pouch!" :
                 "You don't have enough materials to fill the bomb pouch.";
            Console.WriteLine(result);
            result = bombEffect.Count != 0 ? $"Bomb Effects: {string.Join(", ", bombEffect)}" :
                "Bomb Effects: empty";
            Console.WriteLine(result);
            result = casing.Count != 0 ? $"Bomb Casings: {string.Join(", ", casing)}" :
                "Bomb Casings: empty";
            Console.WriteLine(result);

            var bombsOrdered = bombPerCount.OrderBy(x => x.Key);
            foreach (var item in bombsOrdered)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _19._Barista_Contest
{
    class Program
    {
        static void Main()
        {
            int[] coffeeQ = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] milkQ = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Queue<int> coffee = new Queue<int>(coffeeQ);
            Stack<int> milk = new Stack<int>(milkQ);

            Dictionary<string, int> drinksPerQ = new Dictionary<string, int>()
            {
                { "Cortado", 50 },
                { "Espresso", 75 },
                { "Capuccino", 100 },
                { "Americano", 150 },
                { "Latte", 200 },
            };
            Dictionary<string, int> drinksPerCount = new Dictionary<string, int>();

            while (coffee.Any()&& milk.Any())
            {
                int curCoffee = coffee.Peek();
                int curMilk = milk.Peek();
                int mixture = curCoffee + curMilk;
                if (drinksPerQ.ContainsValue(mixture))
                {
                    var coffeeName = drinksPerQ.FirstOrDefault(x => x.Value == mixture).Key;
                    if (!drinksPerCount.ContainsKey(coffeeName))
                    {
                        drinksPerCount[coffeeName] = 0;
                    }
                    drinksPerCount[coffeeName]++;
                    coffee.Dequeue();
                    milk.Pop();
                }
                else
                {
                    coffee.Dequeue();
                    milk.Pop();
                    milk.Push(curMilk - 5);
                }
            }

            string result = string.Empty;
            result = coffee.Count == 0 && milk.Count == 0 ? "Nina is going to win! She used all the coffee and milk!" :
                "Nina needs to exercise more! She didn't use all the coffee and milk!";
            Console.WriteLine(result);
            result = coffee.Count == 0 ? "Coffee left: none" : $"Coffee left: {string.Join(", ", coffee)}";
            Console.WriteLine(result);
            result = milk.Count == 0 ? "Milk left: none" : $"Milk left: {string.Join(", ", milk)}";
            Console.WriteLine(result);
            foreach (var item in drinksPerCount.OrderBy(x => x.Value).ThenByDescending(y => y.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}

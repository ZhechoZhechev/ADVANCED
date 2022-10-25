namespace SumOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] coins = Console.ReadLine()
                .Split(", ")
                .Select(x => int.Parse(x))
                .OrderByDescending(x => x)
                .ToArray();
            int targetSum = int.Parse(Console.ReadLine());
            Dictionary<int, int> result = ChooseCoins(coins, targetSum);

            if (result.Select(x => x.Key * x.Value).Sum() != targetSum)
            {
                Console.WriteLine("Error");
                return;
            }

            Console.WriteLine($"Number of coins to take: {result.Values.Sum()}");
            foreach (var coinQuantity in result)
            {
                Console.WriteLine($"{coinQuantity.Value} coin(s) with value {coinQuantity.Key}");
            }
        }

        public static Dictionary<int, int> ChooseCoins(IList<int> coins, int targetSum)
        {
            var result = new Dictionary<int, int>();
            foreach (int coinValue in coins)
            {
                while (coinValue <= targetSum)
                {
                    if (!result.ContainsKey(coinValue))
                        result.Add(coinValue, 0);
                    result[coinValue]++;
                    targetSum -= coinValue;
                }
            }
            return result;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace _15._LootBox
{
    class Program
    {
        static void Main()
        {
            int[] firstBoxNums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] secondBoxNums = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Queue<int> firstBox = new Queue<int>(firstBoxNums);
            Stack<int> secondBox = new Stack<int>(secondBoxNums);

            int myLoot = 0;

            while (firstBox.Any() && secondBox.Any())
            {
                int curFirstBox = firstBox.Peek();
                int curSecondBox = secondBox.Peek();
                if ((curFirstBox +curSecondBox) %2 == 0)
                {
                    myLoot += curFirstBox + curSecondBox;
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    firstBox.Enqueue(secondBox.Pop());
                }
            }
            string result = string.Empty;
            result = (firstBox.Count == 0) ? "First lootbox is empty" : "Second lootbox is empty";
            Console.WriteLine(result);
            result = (myLoot > 100) ? $"Your loot was epic! Value: {myLoot}" : $"Your loot was poor... Value: {myLoot}";
            Console.WriteLine(result);
        }
    }
}

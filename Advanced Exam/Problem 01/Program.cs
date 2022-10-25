using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem_01
{
    class Program
    {
        static void Main()
        {
            int[] milligramsSeq= Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int[] drinksSeq = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Stack<int> milligrams = new Stack<int>(milligramsSeq);
            Queue<int> drinks = new Queue<int>(drinksSeq);

            const int STAMAT_MAX = 300;
            int stamtTotalCaffeine = 0;

            while (milligrams.Any() && drinks.Any())
            {
                int curMills = milligrams.Peek();
                int curDrink = drinks.Peek();
                int curTotal = curMills * curDrink;

                if (curTotal <= (STAMAT_MAX - stamtTotalCaffeine))
                {
                    milligrams.Pop();
                    drinks.Dequeue();
                    stamtTotalCaffeine += curTotal;
                }
                else
                {
                    milligrams.Pop();
                    drinks.Enqueue(drinks.Dequeue());
                    if (stamtTotalCaffeine - 30 >= 0)
                    {
                        stamtTotalCaffeine -= 30;
                    }
                }
            }
            if (drinks.Any())
            {
                Console.WriteLine($"Drinks left: {string.Join(", ", drinks)}");
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }
            Console.WriteLine($"Stamat is going to sleep with {stamtTotalCaffeine} mg caffeine.");
        }
    }
}

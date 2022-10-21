using System;
using System.Collections.Generic;
using System.Linq;

namespace _22._Meal_Plan
{
    class Program
    {
        static void Main()
        {
            string[] mealsQueue = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int[] daysValues = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            
            Queue<string> meals = new Queue<string>(mealsQueue);
            Stack<int> days = new Stack<int>(daysValues);

            Dictionary<string, int> mealsPerCalsVaue = new Dictionary<string, int>()
            {
                { "salad", 350 },
                { "soup", 490 },
                { "pasta", 680 },
                { "steak", 790 }
            };

            while (meals.Any() && days.Any())
            {
                string curMeal = meals.Peek();
                int curMealCals = mealsPerCalsVaue.FirstOrDefault(x => x.Key == curMeal).Value;
                int curDay = days.Peek();
                if (curDay > curMealCals)
                {
                    meals.Dequeue();
                    days.Pop();
                    days.Push(curDay - curMealCals);
                }
                else if (curDay <= curMealCals)
                {
                    days.Pop();
                    meals.Dequeue();
                    int calsForNextDay = curMealCals - curDay;
                    if (days.Any())
                    {
                        int nextDay = days.Pop();
                        days.Push(nextDay - calsForNextDay);
                    }
                    
                }
            }
            if (meals.Any())
            {
                Console.WriteLine($"John ate enough, he had {mealsQueue.Count() - meals.Count} meals.");
                Console.WriteLine($"Meals left: {string.Join(", ", meals)}.");
            }
            else
            {
                Console.WriteLine($"John had {mealsQueue.Count()} meals.");
                Console.WriteLine($"For the next few days, he can eat {string.Join(", ", days)} calories.");
            }
        }
    }
}

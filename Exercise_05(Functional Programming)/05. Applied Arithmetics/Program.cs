using System;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main()
        {
            int[] nums = Console.ReadLine().Split()
                .Select(int.Parse).ToArray();

            Func<int, int> add = x => x + 1;
            Func<int, int> multiply = x => x * 2;
            Func<int, int> subtract = x => x - 1;
            Action<int[]> print = x => Console.WriteLine(string.Join(" ", x));

            string input = string.Empty;
            while ((input = Console.ReadLine()) != "end")
            {
                switch (input)
                {
                    case "add":
                        nums = nums.Select(x => add(x)).ToArray();
                        break;
                    case "multiply":
                        nums = nums.Select(x => multiply(x)).ToArray();
                        break;
                    case "subtract":
                        nums = nums.Select(x => subtract(x)).ToArray();
                        break;
                    case "print":
                        print(nums);
                        break;
                }
            }
        }
    }
}

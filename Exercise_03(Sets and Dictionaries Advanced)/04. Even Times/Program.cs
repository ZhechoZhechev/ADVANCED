using System;
using System.Collections.Generic;

namespace _04._Even_Times
{
    class Program
    {
        static void Main()
        {
            int numsCount = int.Parse(Console.ReadLine());

            Dictionary<int, int> integersByCount = new Dictionary<int, int>();

            for (int i = 0; i < numsCount; i++)
            {
                int curNum = int.Parse(Console.ReadLine());

                if (!integersByCount.ContainsKey(curNum))
                {
                    integersByCount[curNum] = 0;
                }
                integersByCount[curNum]++;
            }

            foreach (var num in integersByCount)
            {
                if (num.Value %2 == 0)
                {
                    Console.WriteLine(num.Key);
                }
            }
        }
    }
}

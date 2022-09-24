using System;
using System.Collections.Generic;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main()
        {
            int numOfEntries = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < numOfEntries; i++)
            {
                string[] info = Console.ReadLine().Split(" -> ");
                string colour = info[0];
                string[] clothes = info[1].Split(",");

                if (!wardrobe.ContainsKey(colour))
                {
                    wardrobe[colour] = new Dictionary<string, int>();
                }

                for (int k = 0; k < clothes.Length; k++)
                {
                    if (!wardrobe[colour].ContainsKey(clothes[k]))
                    {
                        wardrobe[colour][clothes[k]] = 0;
                    }

                    wardrobe[colour][clothes[k]]++;
                }
            }

            string[] clothesWeSearch = Console.ReadLine().Split();
            string colourToLook = clothesWeSearch[0];
            string clothToLook = clothesWeSearch[1];

            foreach (var colour in wardrobe)
            {
                Console.WriteLine($"{colour.Key} clothes:");
                
                foreach (var cloth in colour.Value)
                {
                    
                    if (colour.Key == colourToLook && cloth.Key == clothToLook)
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    }
                    
                    else Console.WriteLine($"* {cloth.Key} - {cloth.Value}");

                }
                
            }
        }
    }
}

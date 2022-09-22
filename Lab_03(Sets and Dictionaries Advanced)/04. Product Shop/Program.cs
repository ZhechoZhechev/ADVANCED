using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> shopsAndProducts = new Dictionary<string, Dictionary<string, double>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] info = input.Split(", ");
                string shopName = info[0];
                string productName = info[1];
                double price = double.Parse(info[2]);

                if (!shopsAndProducts.ContainsKey(shopName))
                {
                    shopsAndProducts[shopName] = new Dictionary<string, double>();
                }
                shopsAndProducts[shopName][productName] = price; 
            }
            foreach (var shop in shopsAndProducts.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var info in shop.Value)
                {
                    Console.WriteLine($"Product: {info.Key}, Price: {info.Value}");
                }
            }
        }
    }
}

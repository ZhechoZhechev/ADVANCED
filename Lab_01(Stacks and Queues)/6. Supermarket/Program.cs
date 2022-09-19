using System;
using System.Collections.Generic;

namespace _6._Supermarket
{
    class Program
    {
        static void Main()
        {
            Queue<string> customerNames = new Queue<string>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                if (input != "Paid")
                {
                    customerNames.Enqueue(input);
                }
                else
                {
                    while (customerNames.Count > 0)
                    {
                        string name = customerNames.Dequeue();
                        Console.WriteLine(name);
                    }
                }
            }
            Console.WriteLine($"{customerNames.Count} people remaining.");
        }
    }
}

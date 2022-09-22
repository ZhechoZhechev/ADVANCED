using System;
using System.Collections.Generic;

namespace _07._Parking_Lot
{
    class Program
    {
        static void Main()
        {
            HashSet<string> parkinglot = new HashSet<string>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] info = input.Split(",", StringSplitOptions.RemoveEmptyEntries);
                string action = info[0];
                string licensePlate = info[1];
                
                if (action == "IN")
                {
                    parkinglot.Add(licensePlate);
                }
                else
                {
                    parkinglot.Remove(licensePlate);
                }
            }

            if (parkinglot.Count > 0)
            {
                foreach (var license in parkinglot)
                {
                    Console.WriteLine(license);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}

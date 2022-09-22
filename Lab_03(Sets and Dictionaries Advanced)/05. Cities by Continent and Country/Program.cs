using System;
using System.Collections.Generic;

namespace _05._Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {

            int entriesNum = int.Parse(Console.ReadLine());
            
            Dictionary<string, Dictionary<string, List<string>>> contCountCity = new Dictionary<string, Dictionary<string, List<string>>>();

            for (int i = 0; i < entriesNum; i++)
            {
                string[] info = Console.ReadLine().Split();
                string continet = info[0];
                string country = info[1];
                string city = info[2];

                if (!contCountCity.ContainsKey(continet))
                {
                    contCountCity[continet] = new Dictionary<string, List<string>>();
                }
                if (!contCountCity[continet].ContainsKey(country))
                {
                    contCountCity[continet].Add(country, new List<string>());
                }
                contCountCity[continet][country].Add(city);
            }

            foreach (var continet in contCountCity)
            {
                Console.WriteLine($"{continet.Key}:");
                foreach (var country in continet.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {string.Join(", ", country.Value)}");
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main()
        {
            List<string> people = Console.ReadLine()
                .Split().ToList();

            Dictionary<string, Predicate<string>> filtersToUse = new Dictionary<string, Predicate<string>>();

            while (true)
            {
                string[] commands = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];

                if (command == "Print")
                {
                    break;
                }

                string filterType = commands[1];
                string parameter = commands[2];

                if (command == "Add filter")
                {
                    filtersToUse.Add(filterType + parameter, GetPredicate(filterType, parameter));
                }
                else
                {
                    if (filtersToUse.ContainsKey(filterType + parameter))
                    {
                        filtersToUse.Remove(filterType + parameter);
                    }
                }
            }
            foreach (var filter in filtersToUse)
            {
                people.RemoveAll(filter.Value);
            }

            Console.WriteLine(string.Join(" ", people));
        }
        static Predicate<string> GetPredicate(string filterType, string parameter)
        {
            if (filterType == "Ends with")
            {
                return x => x.EndsWith(parameter);
            }
            else if (filterType == "Contains")
            {
                return x => x.Contains(parameter);
            }
            else if (filterType == "Starts with")
            {
                return x => x.StartsWith(parameter);
            }
            else
            {
                return x => x.Length == int.Parse(parameter);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._Predicate_Party_
{
    class Program
    {
        static void Main()
        {
            List<string> people = Console.ReadLine()
                .Split().ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Party!")
            {
                var info = input.Split();
                string action = info[0];
                string condition = info[1];
                string value = info[2];

                if (action == "Remove")
                {
                    people.RemoveAll(GetPredicate(condition, value));
                }
                else
                {
                    var doubleFunc = HowToDouble(GetPredicate(condition, value));
                    List<string> newList = doubleFunc(people);
                    people = newList;

                }

            }
            if (people.Any())
            {
                Console.WriteLine($"{string.Join(", ", people)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }

        }

        static Predicate<string> GetPredicate(string condition, string value)
        {
            if (condition == "StartsWith")
            {
                return x => x.StartsWith(value);
            }
            else if (condition == "EndsWith")
            {
                return x => x.EndsWith(value);
            }
            else
            {
                return x => x.Length == int.Parse(value);
            }
        }
        static Func<List<string>, List<string>> HowToDouble(Predicate<string> checker)
        {
            return x =>
            {
                List<string> doubled = new List<string>();
                foreach (string item in x)
                {
                    doubled.Add(item);
                    if (checker(item))
                    {
                        doubled.Add(item);
                    }
                }
                return doubled;
            };



        }
    }
}

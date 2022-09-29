using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Filter_By_Age
{
    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int entriesCount = int.Parse(Console.ReadLine());

            List<Person> people = new List<Person>();

            Func<Person, string, int, bool> ageFilter = (a, b, c) =>
            {
                if (b == "younger")
                {
                    return a.Age < c;
                }
                else
                {
                    return a.Age >= c;
                }
            };
            Func<Person, string[], string> formater = (p, f) =>
            {
                string fString = string.Empty;
                if (f.Length == 2)
                {
                    if (f[0] == "name") 
                    {
                        fString = "{0} - {1}";
                    }
                    else
                    {
                        fString = "{1} - {0}";
                    }
                }
                else
                {
                    if (f[0] == "name")
                    {
                        fString = "{0}";
                    }
                    else
                    {
                        fString = "{1}";
                    }
                }
                return string.Format(fString, p.Name, p.Age);
            };




            for (int i = 0; i < entriesCount; i++)
            {
                string[] info = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];
                int age = int.Parse(info[1]);

                people.Add(new Person(name, age));

            }
            string condition = Console.ReadLine();
            int ageTreshold = int.Parse(Console.ReadLine());
            string[] printFormat = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            //var selection = people.Where(x => ageFilter(x, condition, ageTreshold));
            Console.WriteLine(string.Join(Environment.NewLine, people.Where(x => ageFilter(x, condition, ageTreshold))
                .Select(x => formater(x, printFormat))));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int membersCount = int.Parse(Console.ReadLine());

            List<Person> overThirty = new List<Person>();

            for (int i = 0; i < membersCount; i++)
            {
                string[] info = Console.ReadLine().Split();
                string name = info[0];
                int age = int.Parse(info[1]);
                Person famMember = new Person();
                famMember.Name = name;
                famMember.Age = age;
                if (famMember.Age > 30)
                {
                    overThirty.Add(famMember);
                }
            }

            foreach (var family in overThirty.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{family.Name} - {family.Age}");
            }

            
        }
    }
}
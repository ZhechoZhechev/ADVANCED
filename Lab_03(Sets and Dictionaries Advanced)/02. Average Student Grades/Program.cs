using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Average_Student_Grades
{
    class Program
    {
        static void Main()
        {
            int studentsCount = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> StudentsGrades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < studentsCount; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                decimal grade = decimal.Parse(input[1]);
                if (!StudentsGrades.ContainsKey(name))
                {
                    StudentsGrades[name] = new List<decimal>();
                }
                StudentsGrades[name].Add(grade);
            }


            foreach (var kvp in StudentsGrades)
            {
                Console.WriteLine($"{kvp.Key} -> {string.Join(' ', kvp.Value.Select(x => $"{x:f2}"))} " +
                    $"(avg: {kvp.Value.Average():f2})");
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._SoftUni_Exam_Results
{
    class Program
    {
        static void Main()
        {
            SortedDictionary<string, int> studentPoints = new SortedDictionary<string, int>();
            SortedDictionary<string, int> languagesSubmissions = new SortedDictionary<string, int>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "exam finished")
                {
                    break;
                }

                string[] info = input.Split('-', StringSplitOptions.RemoveEmptyEntries);
                string name = info[0];
                if (info[1] == "banned")
                {
                    studentPoints.Remove(name);
                    continue;
                }
                int points = int.Parse(info[2]);
                if (!studentPoints.ContainsKey(name))
                {
                    studentPoints[name] = points;
                }
                else
                {
                    if (studentPoints[name] < points)
                    {
                        studentPoints[name] = points;
                    }
                }
                string language = info[1];
                if (!languagesSubmissions.ContainsKey(language))
                {
                    languagesSubmissions[language] = 0;
                }
                languagesSubmissions[language]++;
            }
            
            var studentsOrdered = studentPoints.OrderByDescending(c => c.Value);
            var languagesOrderd = languagesSubmissions.OrderByDescending(c => c.Value);

            Console.WriteLine("Results:");
            foreach (var student in studentsOrdered)
            {
                Console.WriteLine($"{student.Key} | {student.Value}");
            }

            Console.WriteLine("Submissions:");
            foreach (var language in languagesOrderd)
            {
                Console.WriteLine($"{language.Key} - {language.Value}");
            }
        }
    }
}

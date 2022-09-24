using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestsPasses = new Dictionary<string, string>();

            SortedDictionary<string, Dictionary<string, int>> contestants = new SortedDictionary<string, Dictionary<string, int>>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of contests")
                {
                    break;
                }
                string[] info = input.Split(":");

                contestsPasses[info[0]] = info[1];

            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "end of submissions")
                {
                    break;
                }
                string[] info = input.Split("=>");
                string contest = info[0];
                string password = info[1];
                string username = info[2];
                int points = int.Parse(info[3]);

                if (contestsPasses.ContainsKey(contest) && contestsPasses.ContainsValue(password))
                {
                    FillingContestants(contestants, contest, username, points);
                }
            }
            string bestCandidate = contestants.OrderByDescending(x => x.Value.Values.Sum()).First().Key;
            int totalPoints = contestants[bestCandidate].Values.Sum();

            Console.WriteLine($"Best candidate is {bestCandidate} with total {totalPoints} points.");
            Console.WriteLine("Ranking:");

            foreach (var user in contestants)
            {
                var usersbyDescending = user.Value.OrderByDescending(c => c.Value);

                Console.WriteLine(user.Key);

                foreach (var contest in usersbyDescending)
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }

        private static void FillingContestants(SortedDictionary<string, Dictionary<string, int>> contestants, string contest, string username, int points)
        {
            if (!contestants.ContainsKey(username))
            {
                contestants[username] = new Dictionary<string, int>();
            }

            if (!contestants[username].ContainsKey(contest))
            {
                contestants[username][contest] = 0;
            }

            if (contestants[username][contest] < points)
            {
                contestants[username][contest] = points;
            }
        }
    }
}

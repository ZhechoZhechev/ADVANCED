using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {

            string input = string.Empty;

            List<Vlogger> database = new List<Vlogger>();

            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] info = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string action = info[1];

                if (action == "joined")
                {
                    string vloggerName = info[0];

                    Vlogger vlogger = new Vlogger(vloggerName);

                    if (database.Any(x => x.Name == vloggerName))
                    {
                        continue;
                    }

                    database.Add(vlogger);
                }
                else
                {
                    string firstVlogger = info[0];
                    string secondVlogger = info[2];

                    if (firstVlogger == secondVlogger || !database.Any(x => x.Name == firstVlogger) || !database.Any(x => x.Name == secondVlogger))
                    {
                        continue;
                    }

                    //if (firstVlogger == secondVlogger
                    //    || !database.Any(v => v.Name == firstVlogger)
                    //    || !database.Any(v => v.Name == secondVlogger))
                    //{
                    //    continue;
                    //}

                    Vlogger vlogger = database.Single(x => x.Name == firstVlogger);
                    vlogger.Following.Add(secondVlogger);
                    
                    Vlogger vloggerToFollow = database.Single(x => x.Name == secondVlogger);
                    vloggerToFollow.Followers.Add(firstVlogger);

                }
            }

            database = database.OrderByDescending(x => x.Followers.Count)
            .ThenBy(x => x.Following.Count).ToList();

            Console.WriteLine($"The V-Logger has a total of {database.Count} vloggers in its logs.");

            int count = 1;

            foreach (var vloggers in database)
            {
                Console.WriteLine($"{count}. {vloggers.Name} : {vloggers.Followers.Count} followers, {vloggers.Following.Count} following");
                if (count == 1)
                {
                    foreach (var follower in vloggers.Followers)
                    {
                        Console.WriteLine($"*  {follower}");
                    }

                }
                count++;
            }
        }
    }

    public class Vlogger
    {
        public string Name { get; set; }
        public SortedSet<string> Followers { get; set; }
        public HashSet<string> Following { get; set; }

        public Vlogger(string name)
        {
            Name = name;
            Followers = new SortedSet<string>();
            Following = new HashSet<string>();
        }
    }
}

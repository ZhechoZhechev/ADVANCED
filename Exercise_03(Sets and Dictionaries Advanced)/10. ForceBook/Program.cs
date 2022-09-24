using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, SortedSet<string>> sideAndUser = new SortedDictionary<string, SortedSet<string>>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {

                if (input.Contains('|'))
                {
                    string[] tokens = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                    string side = tokens[0];
                    string user = tokens[1];

                    if (!sideAndUser.Values.Any(x => x.Contains(user)))
                    {
                        IfSideExists(sideAndUser, side);
                        sideAndUser[side].Add(user);
                    }
                }
                else
                {
                    string[] tokens = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    string side = tokens[1];
                    string user = tokens[0];

                    foreach (var sideUsers in sideAndUser)
                    {
                        if (sideUsers.Value.Contains(user))
                        {
                            sideUsers.Value.Remove(user);
                            break;
                        }
                    }


                    IfSideExists(sideAndUser, side);
                    sideAndUser[side].Add(user);

                    Console.WriteLine($"{user} joins the {side} side!");
                }

            }
            var orderedByForceUsersCount = sideAndUser.OrderByDescending(c => c.Value.Count);

            foreach (var side in orderedByForceUsersCount)
            {
                if (side.Value.Count > 0)
                {
                    Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");
                    foreach (var user in side.Value)
                    {
                        Console.WriteLine($"! {user}");
                    }
                }
            }
        }

        private static void IfSideExists(SortedDictionary<string, SortedSet<string>> sideAndUser, string side)
        {
            if (!sideAndUser.ContainsKey(side))
            {
                sideAndUser.Add(side, new SortedSet<string>());
            }
        }
    }
}

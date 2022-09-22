using System;
using System.Collections.Generic;

namespace _08._SoftUni_Party
{
    class Program
    {
        static void Main()
        {
            HashSet<string> party = new HashSet<string>();


            while (true)
            {
                string commands = Console.ReadLine();
                if (commands == "PARTY")
                {
                    break;
                }
                party.Add(commands);
            }
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }
                if (party.Contains(input))
                {
                    party.Remove(input);
                }
            }

            Console.WriteLine(party.Count);

            foreach (var item in party)
            {
                char[] ch = item.ToCharArray();
                if (char.IsDigit(ch[0]))
                {
                    Console.WriteLine(item);
                }
            }
            foreach (var item in party)
            {
                char[] ch = item.ToCharArray();
                if (char.IsLetter(ch[0]))
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}

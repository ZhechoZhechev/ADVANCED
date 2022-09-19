using System;
using System.Collections.Generic;

namespace _06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> soungs = new Queue<string>();
            foreach (var item in input)
            {
                soungs.Enqueue(item);
            }
            bool nowSoung = false;
            while (soungs.Count > 0)
            {
                string comand = Console.ReadLine();
                switch (comand)
                {
                    case "Play":
                        if (soungs.Count > 0)
                        {
                            soungs.Dequeue();
                        }
                        else
                        {


                            nowSoung = true;
                        }

                        break;

                    case "Show":
                        Console.WriteLine(string.Join(", ", soungs));
                        break;


                    default:
                        string sub = comand.Substring(4);

                        if (soungs.Contains(sub))
                        {
                            Console.WriteLine($"{sub} is already contained!");
                        }
                        else
                        {
                            soungs.Enqueue(sub);
                        }

                        break;


                }
                if (nowSoung)
                {
                    break;
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
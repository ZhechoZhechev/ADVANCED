using System;
using System.Collections.Generic;
using System.Text;

namespace _09._Simple_Text_Editor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> text = new Stack<string>();
            StringBuilder stri = new StringBuilder();
            text.Push(stri.ToString());

            int numbOperations = int.Parse(Console.ReadLine());
            for (int i = 0; i < numbOperations; i++)
            {
                string[] comand = Console.ReadLine().Split();
                switch (comand[0])
                {
                    case "1":
                        stri.Append(comand[1]);
                        text.Push(stri.ToString());
                        break;
                    case "2":
                        int delit = int.Parse(comand[1]);
                        stri.Remove(stri.Length - delit, delit);

                        text.Push(stri.ToString());

                        break;
                    case "3":
                        int charPrint = int.Parse(comand[1]);
                        Console.WriteLine(stri[charPrint - 1]);

                        break;
                    case "4":
                        text.Pop();
                        stri = new StringBuilder();
                        stri.Append(text.Peek());

                        break;

                }
            }
        }
    }
}
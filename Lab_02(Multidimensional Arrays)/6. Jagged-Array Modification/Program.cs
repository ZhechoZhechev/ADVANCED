using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main()
        {
            int rowsCount = int.Parse(Console.ReadLine());

            int[][] jaggedMatrix = new int[rowsCount][];

            for (int i = 0; i < rowsCount; i++)
            {
                jaggedMatrix[i] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            string input = string.Empty;
            while ((input = Console.ReadLine())!= "END")
            {
                string[] commands = input.Split();

                string action = commands[0];
                int row = int.Parse(commands[1]);
                int col = int.Parse(commands[2]);
                int value = int.Parse(commands[3]);

                if (row < 0 || row >= jaggedMatrix.Length || col < 0 || col >= jaggedMatrix[row].Length)
                {
                    Console.WriteLine("Invalid coordinates");
                    continue; ;
                }
                {

                }
                switch (action)
                {
                    case "Add":

                        jaggedMatrix[row][col] += value;

                        break;
                    case "Subtract":

                        jaggedMatrix[row][col] -= value;

                        break;
                }
            }

            for (int row = 0; row < jaggedMatrix.Length; row++)
            {
                Console.WriteLine(string.Join(" ", jaggedMatrix[row]));
            }
            
        }
    }
}

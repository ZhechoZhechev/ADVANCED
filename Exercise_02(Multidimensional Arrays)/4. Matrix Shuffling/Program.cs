using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main()
        {
            int[] RowsAndCols = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = RowsAndCols[0];
            int cols = RowsAndCols[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLongLength(0); row++)
            {
                string[] colElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < matrix.GetLongLength(1); col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (commands[0] != "swap" || commands.Count() != 5) 
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                } 
                if (int.Parse(commands[1]) < 0 || int.Parse(commands[1]) > rows
                || int.Parse(commands[2]) < 0 || int.Parse(commands[2]) > cols
                || int.Parse(commands[3]) < 0 || int.Parse(commands[3]) > rows
                || int.Parse(commands[4]) < 0 || int.Parse(commands[4]) > cols) 
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }

                string firstEleToSwap = matrix[int.Parse(commands[1]), int.Parse(commands[2])];
                matrix[int.Parse(commands[1]), int.Parse(commands[2])] = matrix[int.Parse(commands[3]), int.Parse(commands[4])];
                matrix[int.Parse(commands[3]), int.Parse(commands[4])] = firstEleToSwap;
                
                MatrixPrint(rows, cols, matrix);
            }

        }

        private static void MatrixPrint(int rows, int cols, string[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}

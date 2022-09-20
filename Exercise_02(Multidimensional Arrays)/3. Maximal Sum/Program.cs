using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main()
        {
            int[] RowsAndCols = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = RowsAndCols[0];
            int cols = RowsAndCols[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLongLength(0); row++)
            {
                int[] colElements = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                for (int col = 0; col < matrix.GetLongLength(1); col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }

            int squareSum = int.MinValue;
            int maxRowIndex = 0;
            int MaxColIndex = 0;

            for (int row = 0; row < rows -2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    int curSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                        matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                        matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                    if (curSum > squareSum)
                    {
                        squareSum = curSum;
                        maxRowIndex = row;
                        MaxColIndex = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {squareSum}");
            for (int row = maxRowIndex; row < maxRowIndex +3; row++)
            {
                for (int col = MaxColIndex; col < MaxColIndex +3; col++)
                {
                    Console.Write($"{matrix[row,col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}

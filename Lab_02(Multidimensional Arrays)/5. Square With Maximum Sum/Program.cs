using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
{
    class Program
    {
        static void Main()
        {
            int[] rowsAndCols = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] colElements = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = colElements[col];
                }
            }

            int maxSum = int.MinValue;
            int rowMaxIndex = -1;
            int colMaxIndex = -1;

            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cols - 1; j++)
                {
                    int curMaxSum = matrix[i, j] + matrix[i + 1, j] + matrix[i, j + 1] + matrix[i + 1, j + 1];
                    if (curMaxSum > maxSum)
                    {
                        maxSum = curMaxSum;
                        rowMaxIndex = i;
                        colMaxIndex = j;
                    }
                }
            }

            Console.WriteLine($"{matrix[rowMaxIndex, colMaxIndex]} {matrix[rowMaxIndex, colMaxIndex + 1]}");
            Console.WriteLine($"{matrix[rowMaxIndex + 1, colMaxIndex]} {matrix[rowMaxIndex + 1, colMaxIndex + 1]}");
            Console.WriteLine(maxSum);

        }
    }
}

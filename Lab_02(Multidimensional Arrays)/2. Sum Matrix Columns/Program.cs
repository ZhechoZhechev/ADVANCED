using System;
using System.Linq;

namespace _2._Sum_Matrix_Columns
{
    class Program
    {
        static void Main()
        {
            int[] rowsAndCols = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = rowsAndCols[0];
            int cols = rowsAndCols[1];

            int[,] intMatrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] columnElements = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    intMatrix[row, col] = columnElements[col];
                }
            }
            for (int i = 0; i < cols; i++)
            {
                int columnSum = 0;
                for (int j = 0; j < rows; j++)
                {
                    columnSum += intMatrix[j, i];
                }
                Console.WriteLine(columnSum);
            }
        }
    }
}

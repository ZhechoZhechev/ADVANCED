using System;
using System.Linq;

namespace _5._Snake_Moves
{
    class Program
    {
        static void Main()
        {
            int[] RowsAndCols = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = RowsAndCols[0];
            int cols = RowsAndCols[1];

            char[,] matrix = new char[rows, cols];

            string colElements = Console.ReadLine();

            int curentWordIndex = 0;

            for (int row = 0; row < matrix.GetLongLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLongLength(1); col++)
                    {
                        if (curentWordIndex == colElements.Length)
                        {
                            curentWordIndex = 0;
                        }
                        matrix[row, col] = colElements[curentWordIndex];
                        curentWordIndex++;
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        if (curentWordIndex == colElements.Length)
                        {
                            curentWordIndex = 0;
                        }
                        matrix[row, col] = colElements[curentWordIndex];
                        curentWordIndex++;
                    }
                }
            }

            MatrixPrint(rows, cols, matrix);
        }
        private static void MatrixPrint(int rows, int cols, char[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}

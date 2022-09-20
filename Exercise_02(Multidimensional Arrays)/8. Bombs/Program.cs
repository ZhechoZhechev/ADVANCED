using System;
using System.Linq;

namespace _8._Bombs
{
    class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] colContent = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = colContent[col];
                }
            }


            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            foreach (var pair in input)
            {
                string[] indexes = pair.Split(",");
                int row = int.Parse(indexes[0]);
                int col = int.Parse(indexes[1]);

                Explode(row, col, size, matrix);
            }
            int activeCellsCount = 0;
            int activeCellsSum = 0;
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        activeCellsCount++;
                        activeCellsSum += matrix[row, col];
                    }
                }
            }
            Console.WriteLine($"Alive cells: {activeCellsCount}");
            Console.WriteLine($"Sum: {activeCellsSum}");

            PrintMatrix(size, matrix);
        }

        private static void PrintMatrix(int size, int[,] matrix)
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        private static void Explode(int row, int col, int size, int[,] matrix)
        {
            int explPower = matrix[row, col];
            if (explPower > 0)
            {
                matrix[row, col] = 0;
                
                if (IsbombedCellVallid(row - 1, col - 1, size) && matrix[row - 1, col - 1] > 0)
                {
                    matrix[row - 1, col - 1] -= explPower;
                }
                if (IsbombedCellVallid(row - 1, col, size) && matrix[row - 1, col] > 0)
                {
                    matrix[row - 1, col] -= explPower;
                }
                if (IsbombedCellVallid(row - 1, col + 1, size) && matrix[row - 1, col + 1] > 0)
                {
                    matrix[row - 1, col + 1] -= explPower;
                }
                if (IsbombedCellVallid(row, col - 1, size) && matrix[row, col - 1] > 0)
                {
                    matrix[row, col - 1] -= explPower;
                }
                if (IsbombedCellVallid(row, col + 1, size) && matrix[row, col + 1] > 0)
                {
                    matrix[row, col+1] -= explPower; ;
                }
                if (IsbombedCellVallid(row + 1, col - 1, size) && matrix[row + 1, col - 1] > 0)
                {
                    matrix[row + 1, col - 1] -= explPower;
                }
                if (IsbombedCellVallid(row + 1, col, size) && matrix[row + 1, col] > 0)
                {
                    matrix[row + 1, col] -= explPower;
                }
                if (IsbombedCellVallid(row + 1, col + 1, size) && matrix[row + 1, col + 1] > 0)
                {
                    matrix[row + 1, col + 1] -= explPower;
                }
                //PrintMatrix(size, matrix);
            }

            static bool IsbombedCellVallid(int row, int col, int size)
            {
                return row >= 0 && row < size && col >= 0 && col < size;
            }
        }
    }
}

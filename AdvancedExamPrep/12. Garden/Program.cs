using System;
using System.Linq;

namespace _12._Garden
{
    class Program
    {
        static void Main()
        {
            int[] rowCol = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            int rows = rowCol[0];
            int cols = rowCol[1];

            int[,] garden = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    garden[i, j] = 0;
                }
            }
            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                int[] coordinates = input.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();
                int row = coordinates[0];
                int col = coordinates[1];

                if (AreCoordinatesVallid(row, col, garden))
                {
                    
                    for (int i = 0; i < garden.GetLength(0); i++)
                    {
                        if (garden[i, col] == 1) garden[i, col] = 2;
                        else garden[i, col] = 1;

                    }
                    for (int i = 0; i < garden.GetLength(1); i++)
                    {
                        if (garden[row, i] == 1) garden[row, i] = 2;
                        else garden[row, i] = 1;
                    }
                    garden[row, col] = 1;
                    //PrintGarden(garden);
                }
                else
                {
                    Console.WriteLine("Invalid coordinates.");
                }
            }
            PrintGarden(garden);
        }
        private static bool AreCoordinatesVallid(int row, int col, int[,] garden)
        {
            return row >= 0 && row < garden.GetLength(0) && col >= 0 && col < garden.GetLength(1);
        }
        private static void PrintGarden(int[,] garden) 
        {
            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    Console.Write($"{garden[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}

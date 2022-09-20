using System;
using System.Linq;

namespace Miner
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = rows;
            string[] commandArray = Console.ReadLine().Split().ToArray();
            char[,] matrix = new char[rows, cols];
            int rowStart = 0;
            int colStart = 0;
            
            for (int row = 0; row < rows; row++)
            {
                char[] currentLine = Console.ReadLine().Split().Select(char.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = currentLine[col];
                    if (matrix[row, col] == 's')
                    {
                        rowStart = row;
                        colStart = col;
                    }
                }
            }

            foreach (string command in commandArray)
            {
                int nextRow = rowStart;
                int nextCol = colStart;

                switch (command)
                {
                    case "up":
                        nextRow--;
                        break;
                    case "down":
                        nextRow++;
                        break;
                    case "left":
                        nextCol--;
                        break;
                    case "right":
                        nextCol++;
                        break;
                }

                if (nextRow < 0 || nextRow >= rows || nextCol < 0 || nextCol >= cols) continue;

                rowStart = nextRow;
                colStart = nextCol;

                switch (matrix[nextRow, nextCol])
                {
                    case 'e':
                        Console.WriteLine($"Game over! ({nextRow}, {nextCol})");
                        return;
                    case 'c':
                        matrix[nextRow, nextCol] = '*';
                        break;
                }
            }

            int countCoalsLeft = matrix.Cast<char>().Count(symbol => symbol == 'c');

            Console.WriteLine(countCoalsLeft == 0
                ? $"You collected all coals! ({rowStart}, {colStart})"
                : $"{countCoalsLeft} coals left. ({rowStart}, {colStart})");
        }
    }
}
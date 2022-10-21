using System;
using System.Linq;

namespace _23._Truffle_Hunter
{
    class Program
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            char[,] forest = new char[rows, rows];

            for (int row = 0; row < rows; row++)
            {
                char[] colsInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < rows; col++)
                {
                    forest[row, col] = colsInfo[col];

                }
            }
            int whiteCount = 0;
            int summerCount = 0;
            int blackCount = 0;
            int eatenByBoar = 0;

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Stop the hunt")
            {
                string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (commands.Length == 3)
                {
                    int row = int.Parse(commands[1]);
                    int col = int.Parse(commands[2]);
                    if (AreCoordinatesVallid(row, col, forest))
                    {
                        if (forest[row, col] == 'B')
                        {
                            blackCount++;
                        }
                        else if (forest[row, col] == 'S')
                        {
                            summerCount++;
                        }
                        else if (forest[row, col] == 'W')
                        {
                            whiteCount++;
                        }
                        forest[row, col] = '-';
                    }

                }
                else if (commands.Length == 4)
                {
                    int boarRow = int.Parse(commands[1]);
                    int boarCol = int.Parse(commands[2]);
                    string direction = commands[3];
                    BoarMove(boarRow, boarCol, ref eatenByBoar, direction, forest);
                }
            }
            Console.WriteLine($"Peter manages to harvest {blackCount} black," +
                $" {summerCount} summer, and {whiteCount} white truffles.");
            Console.WriteLine($"The wild boar has eaten {eatenByBoar} truffles.");
            PrintMatrix(forest);
        }

        private static void BoarMove(int boarRow, int boarCol, ref int eatenByBoar, string direction, char[,] forest)
        {
            if (direction == "up")
            {
                while (boarRow >= 0)
                {
                    if (forest[boarRow, boarCol] == 'B' || forest[boarRow, boarCol] == 'S'
                        || forest[boarRow, boarCol] == 'W')
                    {
                        eatenByBoar++;
                        forest[boarRow , boarCol] = '-';
                    }
                        boarRow -= 2;
                }
            }
            else if (direction == "down")
            {
                while (boarRow <= forest.GetLength(0) - 1)
                {
                    if (forest[boarRow, boarCol] == 'B' || forest[boarRow , boarCol] == 'S'
                        || forest[boarRow , boarCol] == 'W')
                    {
                        eatenByBoar++;
                        forest[boarRow , boarCol] = '-';
                    }
                        boarRow += 2;
                }
            }
            else if (direction == "left")
            {
                while (boarCol >= 0)
                {
                    if (forest[boarRow, boarCol] == 'B' || forest[boarRow, boarCol] == 'S'
                        || forest[boarRow, boarCol] == 'W')
                    {
                        eatenByBoar++;
                        forest[boarRow, boarCol] = '-';
                    }
                        boarCol -= 2;
                }
            }
            else if (direction == "right")
            {
                while (boarCol <= forest.GetLength(1) - 1)
                {
                    if (forest[boarRow, boarCol] == 'B' || forest[boarRow, boarCol ] == 'S'
                        || forest[boarRow, boarCol ] == 'W')
                    {
                        eatenByBoar++;
                        forest[boarRow, boarCol] = '-';
                    }
                        boarCol += 2;
                }
            }
        }
        public static bool AreCoordinatesVallid(int row, int col, char[,] forest)
        {
            return row >= 0 && row < forest.GetLength(0) && col >= 0 && col < forest.GetLength(1);
        }
        private static void PrintMatrix(char[,] forest)
        {
            for (int row = 0; row < forest.GetLength(0); row++)
            {
                for (int col = 0; col < forest.GetLength(1); col++)
                {
                    Console.Write($"{forest[row, col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}

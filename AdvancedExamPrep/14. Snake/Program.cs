using System;

namespace _14._Snake
{
    class Program
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            char[,] teritory = new char[rows, rows];

            int snakeRow = 0;
            int snakeCol = 0;
            int foodQuantity = 0;
            bool isSnakeOut = false;

            for (int row = 0; row < rows; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < rows; col++)
                {
                    teritory[row, col] = input[col];
                    if (teritory[row, col] == 'S')
                    {
                        snakeRow = row;
                        snakeCol = col;
                    }
                }
            }
            while (foodQuantity < 10)
            {
                string command = Console.ReadLine();
                if (command == "up")
                {
                    if (AreCoordinatesVallid(snakeRow -1, snakeCol, teritory))
                    {
                        Move(-1, 0, ref snakeRow, ref snakeCol, ref foodQuantity, teritory);
                    }
                    else
                    {
                        teritory[snakeRow, snakeCol] = '.';
                        isSnakeOut = true;
                        break;
                    }
                }
                else if (command == "down")
                {
                    if (AreCoordinatesVallid(snakeRow + 1, snakeCol, teritory))
                    {
                        Move(1, 0, ref snakeRow, ref snakeCol, ref foodQuantity, teritory);
                    }
                    else
                    {
                        teritory[snakeRow, snakeCol] = '.';
                        isSnakeOut = true;
                        break;
                    }
                }
                else if (command == "left")
                {
                    if (AreCoordinatesVallid(snakeRow, snakeCol -1, teritory))
                    {
                        Move(0, -1, ref snakeRow, ref snakeCol, ref foodQuantity, teritory);
                    }
                    else
                    {
                        teritory[snakeRow, snakeCol] = '.';
                        isSnakeOut = true;
                        break;
                    }
                }
                else if (command == "right")
                {
                    if (AreCoordinatesVallid(snakeRow, snakeCol + 1, teritory))
                    {
                        Move(0, 1, ref snakeRow, ref snakeCol, ref foodQuantity, teritory);
                    }
                    else
                    {
                        teritory[snakeRow, snakeCol] = '.';
                        isSnakeOut = true;
                        break;
                    }
                }
            }
            if (isSnakeOut) Console.WriteLine("Game over!");
            if (foodQuantity == 10) Console.WriteLine("You won! You fed the snake.");
            Console.WriteLine($"Food eaten: {foodQuantity}");
            PrintTeritory(teritory);
        }
        private static void PrintTeritory(char[,] teritory)
        {
            for (int row = 0; row < teritory.GetLength(0); row++)
            {
                for (int col = 0; col < teritory.GetLength(1); col++)
                {
                    Console.Write(teritory[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void Move(int row, int col, ref int snakeRow, ref int snakeCol, ref int foodQuantity, char[,] teritory)
        {
            int newRow = snakeRow + row;
            int newCol = snakeCol + col;

            if (teritory[newRow, newCol] == '*')
            {
                teritory[snakeRow, snakeCol] = '.';
                teritory[newRow, newCol] = 'S';
                foodQuantity++;
                snakeRow = newRow;
                snakeCol = newCol;

            }
            else if (teritory[newRow, newCol] == 'B')
            {
                int secondBRow = 0;
                int secondBCol = 0;
                for (int i = 0; i < teritory.GetLength(0); i++)
                {
                    for (int j = 0; j < teritory.GetLength(1); j++)
                    {
                        if (teritory[i, j]== 'B' && i != newRow && j != newCol)
                        {
                            secondBRow = i;
                            secondBCol = j;
                        }
                    }
                }
                teritory[snakeRow, snakeCol] = '.';
                teritory[newRow, newCol] = '.';
                teritory[secondBRow, secondBCol] = 'S';
                snakeRow = secondBRow;
                snakeCol = secondBCol;
            }
            else if (teritory[newRow, newCol] == '-')
            {
                teritory[snakeRow, snakeCol] = '.';
                teritory[newRow, newCol] = 'S';
                snakeRow = newRow;
                snakeCol = newCol;
            }
        }

        private static bool AreCoordinatesVallid(int row, int col, char[,] teritory)
        {
            return row >= 0 && row < teritory.GetLength(0) && col >= 0 && col < teritory.GetLength(1);
        }
    }
}

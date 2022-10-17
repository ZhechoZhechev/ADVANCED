using System;
using System.Linq;

namespace _10._Warships
{
    class Program
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            string[] coordinatesInfo = Console.ReadLine()
                .Split(",", StringSplitOptions.RemoveEmptyEntries);

            char[,] field = new char[rows, rows];

            int playerOneShipCount = 0;
            int playerTwoShipCount = 0;
            int totalShipsSunk = 0;

            for (int i = 0; i < rows; i++)
            {
                char[] fieldInput = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();

                for (int k = 0; k < rows; k++)
                {
                    field[i, k] = fieldInput[k];
                    if (field[i, k] == '<')
                    {
                        playerOneShipCount++;
                    }
                    if (field[i, k] == '>')
                    {
                        playerTwoShipCount++;
                    }
                }
            }

            for (int i = 0; i < coordinatesInfo.Length; i++)
            {

                int[] coordinates = coordinatesInfo[i]
                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse).ToArray();

                    int row = coordinates[0];
                    int col = coordinates[1];
                    if (AreCoordinatesVallid(row, col, field))
                    {
                        if (field[row, col] == '>')
                        {
                            field[row, col] = 'X';
                            playerTwoShipCount--;
                            totalShipsSunk++;
                        }
                        else if (field[row, col] == '<')
                        {
                            field[row, col] = 'X';
                            playerOneShipCount--;
                            totalShipsSunk++;
                        }
                        else if (field[row, col] == '#')
                        {
                            IfMineIsHit(row, col, ref playerOneShipCount, ref playerTwoShipCount, ref totalShipsSunk, field);

                        }
                    }

                if (playerTwoShipCount == 0)
                {
                    Console.WriteLine($"Player One has won the game! {totalShipsSunk} ships have been sunk in the battle.");
                    break;
                }
                else if (playerOneShipCount == 0)
                {
                    Console.WriteLine($"Player Two has won the game! {totalShipsSunk} ships have been sunk in the battle.");
                    break;
                }
            }
            if (playerOneShipCount > 0 && playerTwoShipCount > 0)
            {
                Console.WriteLine($"It's a draw! Player One has {playerOneShipCount} ships left. Player Two has {playerTwoShipCount} ships left.");
            }
        }

        private static void IfMineIsHit(int row, int col, ref int playerOneShipCount,
            ref int playerTwoShipCount, ref int totalShipsSunk, char[,] field)
        {
            if (AreCoordinatesVallid(row - 1, col - 1, field))
            {
                field[row, col] = 'X';
                if (field[row - 1, col - 1] == '<')
                {
                    playerOneShipCount--;
                    totalShipsSunk++;
                    field[row - 1, col - 1] = 'X';
                }
                else if (field[row - 1, col - 1] == '>')
                {
                    playerTwoShipCount--;
                    totalShipsSunk++;
                    field[row - 1, col - 1] = 'X';
                }
            }
            if (AreCoordinatesVallid(row - 1, col, field))
            {
                field[row, col] = 'X';
                if (field[row - 1, col] == '<')
                {
                    playerOneShipCount--;
                    totalShipsSunk++;
                    field[row - 1, col] = 'X';
                }
                else if (field[row - 1, col] == '>')
                {
                    playerTwoShipCount--;
                    totalShipsSunk++;
                    field[row - 1, col] = 'X';
                }
            }
            if (AreCoordinatesVallid(row - 1, col + 1, field))
            {
                field[row, col] = 'X';
                if (field[row - 1, col + 1] == '<')
                {
                    playerOneShipCount--;
                    totalShipsSunk++;
                    field[row - 1, col + 1] = 'X';
                }
                else if (field[row - 1, col + 1] == '>')
                {
                    playerTwoShipCount--;
                    totalShipsSunk++;
                    field[row - 1, col + 1] = 'X';
                }
            }
            if (AreCoordinatesVallid(row, col + 1, field))
            {
                field[row, col] = 'X';
                if (field[row, col + 1] == '<')
                {
                    playerOneShipCount--;
                    totalShipsSunk++;
                    field[row, col + 1] = 'X';
                }
                else if (field[row, col + 1] == '>')
                {
                    playerTwoShipCount--;
                    totalShipsSunk++;
                    field[row, col + 1] = 'X';
                }
            }
            if (AreCoordinatesVallid(row + 1, col + 1, field))
            {
                field[row, col] = 'X';
                if (field[row + 1, col + 1] == '<')
                {
                    playerOneShipCount--;
                    totalShipsSunk++;
                    field[row + 1, col + 1] = 'X';
                }
                else if (field[row + 1, col + 1] == '>')
                {
                    playerTwoShipCount--;
                    totalShipsSunk++;
                    field[row + 1, col + 1] = 'X';
                }
            }
            if (AreCoordinatesVallid(row + 1, col, field))
            {
                field[row, col] = 'X';
                if (field[row + 1, col] == '<')
                {
                    playerOneShipCount--;
                    totalShipsSunk++;
                    field[row + 1, col] = 'X';
                }
                else if (field[row + 1, col] == '>')
                {
                    playerTwoShipCount--;
                    totalShipsSunk++;
                    field[row + 1, col] = 'X';
                }
            }
            if (AreCoordinatesVallid(row + 1, col - 1, field))
            {
                field[row, col] = 'X';
                if (field[row + 1, col - 1] == '<')
                {
                    playerOneShipCount--;
                    totalShipsSunk++;
                    field[row + 1, col - 1] = 'X';
                }
                else if (field[row + 1, col - 1] == '>')
                {
                    playerTwoShipCount--;
                    totalShipsSunk++;
                    field[row + 1, col - 1] = 'X';
                }
            }
            if (AreCoordinatesVallid(row, col - 1, field))
            {
                field[row, col] = 'X';
                if (field[row, col - 1] == '<')
                {
                    playerOneShipCount--;
                    totalShipsSunk++;
                    field[row, col - 1] = 'X';
                }
                else if (field[row, col - 1] == '>')
                {
                    playerTwoShipCount--;
                    totalShipsSunk++;
                    field[row, col - 1] = 'X';
                }
            }
        }

        private static bool AreCoordinatesVallid(int row, int col, char[,] field)
        {
            return row >= 0 && row < field.GetLength(0) && col >= 0 && col < field.GetLength(1);
        }
    }
}

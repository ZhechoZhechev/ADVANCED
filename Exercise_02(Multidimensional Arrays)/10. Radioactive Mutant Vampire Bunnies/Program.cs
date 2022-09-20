using System;
using System.Linq;

namespace BunnyGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] n = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[,] lair = new char[n[0], n[1]];
            char[,] newLair = new char[n[0], n[1]];
            int playerRow = 0;
            int playerCol = 0;
            bool hasDied = false;
            bool hasWon = false;

            for (int row = 0; row < n[0]; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();

                for (int col = 0; col < n[1]; col++)
                {
                    lair[row, col] = input[col];
                    newLair[row, col] = input[col];

                    if (input[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            char[] directions = Console.ReadLine().ToCharArray();

            for (int i = 0; i < directions.Length; i++)
            {
                if (directions[i] == 'U')
                {
                    if (playerRow - 1 < 0)
                    {
                        lair[playerRow, playerCol] = '.';
                        newLair[playerRow, playerCol] = '.';
                        hasWon = true;
                    }
                    else if (lair[playerRow - 1, playerCol] == '.')
                    {
                        lair[playerRow, playerCol] = '.';
                        newLair[playerRow, playerCol] = '.';
                        lair[playerRow - 1, playerCol] = 'P';
                        newLair[playerRow - 1, playerCol] = 'P';
                        playerRow--;
                    }
                    else if (lair[playerRow - 1, playerCol] == 'B')
                    {
                        lair[playerRow, playerCol] = '.';
                        newLair[playerRow, playerCol] = '.';
                        hasDied = true;
                        playerRow--;
                    }
                }
                else if (directions[i] == 'D')
                {
                    if (playerRow + 1 == lair.GetLength(0))
                    {
                        lair[playerRow, playerCol] = '.';
                        newLair[playerRow, playerCol] = '.';
                        hasWon = true;
                    }
                    else if (lair[playerRow + 1, playerCol] == '.')
                    {
                        lair[playerRow, playerCol] = '.';
                        newLair[playerRow, playerCol] = '.';
                        lair[playerRow + 1, playerCol] = 'P';
                        newLair[playerRow + 1, playerCol] = 'P';
                        playerRow++;
                    }
                    else if (lair[playerRow + 1, playerCol] == 'B')
                    {
                        lair[playerRow, playerCol] = '.';
                        newLair[playerRow, playerCol] = '.';
                        hasDied = true;
                        playerRow++;
                    }
                }
                else if (directions[i] == 'R')
                {
                    if (playerCol + 1 == lair.GetLength(1))
                    {
                        lair[playerRow, playerCol] = '.';
                        newLair[playerRow, playerCol] = '.';
                        hasWon = true;
                    }
                    else if (lair[playerRow, playerCol + 1] == '.')
                    {
                        lair[playerRow, playerCol] = '.';
                        newLair[playerRow, playerCol] = '.';
                        lair[playerRow, playerCol + 1] = 'P';
                        newLair[playerRow, playerCol + 1] = 'P';
                        playerCol++;
                    }
                    else if (lair[playerRow, playerCol + 1] == 'B')
                    {
                        lair[playerRow, playerCol] = '.';
                        newLair[playerRow, playerCol] = '.';
                        hasDied = true;
                        playerCol++;
                    }
                }
                else if (directions[i] == 'L')
                {
                    if (playerCol - 1 < 0)
                    {
                        lair[playerRow, playerCol] = '.';
                        newLair[playerRow, playerCol] = '.';
                        hasWon = true;
                    }
                    else if (lair[playerRow, playerCol - 1] == '.')
                    {
                        lair[playerRow, playerCol] = '.';
                        newLair[playerRow, playerCol] = '.';
                        lair[playerRow, playerCol - 1] = 'P';
                        newLair[playerRow, playerCol - 1] = 'P';
                        playerCol--;
                    }
                    else if (lair[playerRow, playerCol - 1] == 'B')
                    {
                        lair[playerRow, playerCol] = '.';
                        newLair[playerRow, playerCol] = '.';
                        hasDied = true;
                        playerCol--;
                    }
                }

                for (int row = 0; row < lair.GetLength(0); row++)
                {
                    for (int col = 0; col < lair.GetLength(1); col++)
                    {
                        if (lair[row, col] == 'B')
                        {
                            //up
                            if (row - 1 >= 0 && lair[row - 1, col] == '.')
                            {
                                newLair[row - 1, col] = 'B';
                            }
                            else if (row - 1 >= 0 && lair[row - 1, col] == 'P')
                            {
                                newLair[row - 1, col] = 'B';
                                hasDied = true;
                            }

                            //down
                            if (row + 1 < lair.GetLength(0) && lair[row + 1, col] == '.')
                            {
                                newLair[row + 1, col] = 'B';
                            }
                            else if (row + 1 < lair.GetLength(0) && lair[row + 1, col] == 'P')
                            {
                                newLair[row + 1, col] = 'B';
                                hasDied = true;
                            }

                            //right
                            if (col + 1 < lair.GetLength(1) && lair[row, col + 1] == '.')
                            {
                                newLair[row, col + 1] = 'B';
                            }
                            else if (col + 1 < lair.GetLength(1) && lair[row, col + 1] == 'P')
                            {
                                newLair[row, col + 1] = 'B';
                                hasDied = true;
                            }

                            //left
                            if (col - 1 >= 0 && lair[row, col - 1] == '.')
                            {
                                newLair[row, col - 1] = 'B';
                            }
                            else if (col - 1 >= 0 && lair[row, col - 1] == 'P')
                            {
                                newLair[row, col - 1] = 'B';
                                hasDied = true;
                            }
                        }
                    }
                }

                for (int row = 0; row < newLair.GetLength(0); row++)
                {
                    for (int col = 0; col < newLair.GetLength(1); col++)
                    {
                        if (lair[row, col] != newLair[row, col])
                        {
                            lair[row, col] = newLair[row, col];
                        }
                    }
                }

                if (hasWon == true)
                {
                    for (int row = 0; row < lair.GetLength(0); row++)
                    {
                        for (int col = 0; col < lair.GetLength(1); col++)
                        {
                            Console.Write(lair[row, col]);
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine($"won: {playerRow} {playerCol}");
                    return;
                }
                else if (hasDied == true)
                {
                    for (int row = 0; row < lair.GetLength(0); row++)
                    {
                        for (int col = 0; col < lair.GetLength(1); col++)
                        {
                            Console.Write(lair[row, col]);
                        }
                        Console.WriteLine();
                    }
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    return;
                }
            }

        }
    }
}
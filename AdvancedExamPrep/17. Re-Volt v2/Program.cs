using System;
using System.Collections.Generic;
using System.Data;

namespace _02_Re_Volt
{
    class Program
    {
        static void Main(string[] args)
        {
            int sizeN = int.Parse(Console.ReadLine());
            int countOfCommands = int.Parse(Console.ReadLine());

            var matrix = new char[sizeN, sizeN];

            var playerRow = 0;
            var playerCol = 0;

            bool isWon = false;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string currentRow = Console.ReadLine();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                    if (matrix[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
            for (int i = 0; i < countOfCommands; i++)
            {
                string command = Console.ReadLine();

                matrix[playerRow, playerCol] = '-';

                if (command == "up")
                {
                    if (playerRow - 1 >= 0)
                    {
                        playerRow--;
                    }
                    else
                    {
                        playerRow = matrix.GetLength(0) - 1;
                    }

                    while (matrix[playerRow, playerCol] != '-' && matrix[playerRow, playerCol] != 'F')
                    {
                        if (matrix[playerRow, playerCol] == 'T')
                        {
                            playerRow++;
                        }
                        else if (matrix[playerRow, playerCol] == 'B')
                        {
                            playerRow--;
                        }

                        if (playerRow < 0)
                        {
                            playerRow = matrix.GetLength(0) - 1;
                        }

                    }
                    if (matrix[playerRow, playerCol] == 'F')
                    {
                        isWon = true;
                        break;
                    }
                    matrix[playerRow, playerCol] = 'f';

                }

                else if (command == "down")
                {
                    if (playerRow + 1 < matrix.GetLength(0))
                    {
                        playerRow++;
                    }
                    else
                    {
                        playerRow = 0;
                    }
                    while (matrix[playerRow, playerCol] != '-' && matrix[playerRow, playerCol] != 'F')
                    {
                        if (matrix[playerRow, playerCol] == 'T')
                        {
                            playerRow--;
                        }
                        else if (matrix[playerRow, playerCol] == 'B')
                        {
                            playerRow++;
                        }

                        if (playerRow == matrix.GetLength(0))
                        {
                            playerRow = 0;
                        }

                    }

                    if (matrix[playerRow, playerCol] == 'F')
                    {
                        isWon = true;
                        break;
                    }
                    matrix[playerRow, playerCol] = 'f';

                }

                else if (command == "left")
                {
                    if (playerCol - 1 >= 0)
                    {
                        playerCol--;
                    }
                    else
                    {
                        playerCol = matrix.GetLength(1) - 1;
                    }

                    while (matrix[playerRow, playerCol] != '-' && matrix[playerRow, playerCol] != 'F')
                    {
                        if (matrix[playerRow, playerCol] == 'T')
                        {
                            playerCol++;
                        }
                        else if (matrix[playerRow, playerCol] == 'B')
                        {
                            playerCol--;
                        }
                        if (playerCol < 0)
                        {
                            playerCol = matrix.GetLength(1) - 1;
                        }

                    }
                    if (matrix[playerRow, playerCol] == 'F')
                    {
                        isWon = true;
                        break;
                    }
                    matrix[playerRow, playerCol] = 'f';

                }

                else if (command == "right")
                {
                    if (playerCol + 1 < matrix.GetLength(1))
                    {
                        playerCol++;
                    }
                    else
                    {
                        playerCol = 0;
                    }

                    while (matrix[playerRow, playerCol] != '-' && matrix[playerRow, playerCol] != 'F')
                    {
                        if (matrix[playerRow, playerCol] == 'T')
                        {
                            playerCol--;
                        }
                        else if (matrix[playerRow, playerCol] == 'B')
                        {
                            playerCol++;
                        }

                        if (playerCol == matrix.GetLength(1))
                        {
                            playerCol = 0;
                        }

                    }
                    if (matrix[playerRow, playerCol] == 'F')
                    {
                        isWon = true;
                        break;
                    }
                    matrix[playerRow, playerCol] = 'f';
                }

            }
            if (isWon)
            {
                matrix[playerRow, playerCol] = 'f';
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }
            MatrixPrint(matrix);
        }
        static void MatrixPrint(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
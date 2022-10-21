using System;

namespace _16._Re_Volt
{
    class Program
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int commandsNum = int.Parse(Console.ReadLine());

            char[,] playGround = new char[rows, rows];

            int playerRow = 0;
            int playerCol = 0;
            bool isPlayerWon = false;
            for (int row = 0; row < rows; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < rows; col++)
                {
                    playGround[row, col] = input[col];
                    if (playGround[row, col] == 'f')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            for (int i = 0; i < commandsNum; i++)
            {
                if (isPlayerWon) break;

                string command = Console.ReadLine();
                string lastCommand = command;

                if (command == "up")
                {
                    if (AreCoordinatesVallid(playerRow - 1, playerCol, playGround))
                    {
                        Move(-1, 0, ref playerRow, ref playerCol, ref isPlayerWon, playGround, lastCommand);
                    }
                    else
                    {
                        playGround[playerRow, playerCol] = '-';
                        playerRow = playGround.GetLength(0) - 1;
                        playGround[playerRow, playerCol] = 'f';
                        if (playGround[playerRow, playerCol] == 'F')
                        {
                            playGround[playerRow, playerCol] = 'f';
                            isPlayerWon = true;
                        }

                    }
                }
                else if (command == "down")
                {
                    if (AreCoordinatesVallid(playerRow + 1, playerCol, playGround))
                    {
                        Move(1, 0, ref playerRow, ref playerCol, ref isPlayerWon, playGround, lastCommand);
                    }
                    else
                    {
                        playGround[playerRow, playerCol] = '-';
                        playerRow = 0;
                        playGround[playerRow, playerCol] = 'f';
                        if (playGround[playerRow, playerCol] == 'F')
                        {
                            playGround[playerRow, playerCol] = 'f';
                            isPlayerWon = true;
                        }
                    }
                }
                else if (command == "left")
                {
                    if (AreCoordinatesVallid(playerRow, playerCol - 1, playGround))
                    {
                        Move(0, -1, ref playerRow, ref playerCol, ref isPlayerWon, playGround, lastCommand);
                    }
                    else
                    {
                        playGround[playerRow, playerCol] = '-';
                        playerCol = playGround.GetLength(1) - 1;
                        playGround[playerRow, playerCol] = 'f';
                        if (playGround[playerRow, playerCol] == 'F')
                        {
                            playGround[playerRow, playerCol] = 'f';
                            isPlayerWon = true;
                        }
                    }
                }
                else
                {
                    if (AreCoordinatesVallid(playerRow, playerCol + 1, playGround))
                    {
                        Move(0, 1, ref playerRow, ref playerCol, ref isPlayerWon, playGround, lastCommand);
                    }
                    else
                    {
                        playGround[playerRow, playerCol] = '-';
                        playerCol = 0;
                        playGround[playerRow, playerCol] = 'f';
                        if (playGround[playerRow, playerCol] == 'F')
                        {
                            playGround[playerRow, playerCol] = 'f';
                            isPlayerWon = true;
                        }
                    }
                }
                //PrintPlayGround(playGround);
            }
            if (isPlayerWon) Console.WriteLine("Player won!");
            else Console.WriteLine("Player lost!");
            PrintPlayGround(playGround);
        }
        private static void PrintPlayGround(char[,] playGround)
        {
            for (int row = 0; row < playGround.GetLength(0); row++)
            {
                for (int col = 0; col < playGround.GetLength(1); col++)
                {
                    Console.Write(playGround[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void Move(int row, int col, ref int playerRow, ref int playerCol, ref bool isPlayerWon, char[,] playGround, string lastCommand)
        {
            int newRow = playerRow + row;
            int newCol = playerCol + col;
            if (playGround[newRow, newCol] == '-')
            {
                playGround[playerRow, playerCol] = '-';
                playGround[newRow, newCol] = 'f';
                playerRow = newRow;
                playerCol = newCol;

            }
            else if (playGround[newRow, newCol] == 'B')
            {
                playGround[playerRow, playerCol] = '-';
                if (lastCommand == "up")
                {
                    if (newRow == 0)
                    {
                        newRow = playGround.GetLength(0) - 1;
                        if (playGround[newRow, newCol] == 'F')
                        {
                            playGround[newRow, newCol] = 'f';
                            //playGround[playerRow, playerCol] = '-';
                            isPlayerWon = true;
                        }
                    }
                    else
                    {
                        newRow--;
                        isPlayerWon = BonusCheck(playerRow, playerCol, isPlayerWon, playGround, newRow, newCol);
                    }
                }
                else if (lastCommand == "down")
                {
                    if (newRow == playGround.GetLength(0) - 1)
                    {
                        newRow = 0;
                        if (playGround[newRow, newCol] == 'F')
                        {
                            playGround[newRow, newCol] = 'f';
                            //playGround[playerRow, playerCol] = '-';
                            isPlayerWon = true;
                        }
                    }
                    else
                    {
                        newRow++;
                        isPlayerWon = BonusCheck(playerRow, playerCol, isPlayerWon, playGround, newRow, newCol);
                    }

                }
                else if (lastCommand == "left")
                {
                    if (newCol == 0)
                    {
                        newCol = playGround.GetLength(1) - 1;
                        if (playGround[newRow, newCol] == 'F')
                        {
                            playGround[newRow, newCol] = 'f';
                            //playGround[playerRow, playerCol] = '-';
                            isPlayerWon = true;
                        }
                    }
                    else
                    {
                        newCol--;
                        isPlayerWon = BonusCheck(playerRow, playerCol, isPlayerWon, playGround, newRow, newCol);
                    }
                }
                else
                {
                    if (newCol == playGround.GetLength(1) - 1)
                    {
                        newCol = 0;
                        if (playGround[newRow, newCol] == 'F')
                        {
                            playGround[newRow, newCol] = 'f';
                            //playGround[playerRow, playerCol] = '-';
                            isPlayerWon = true;
                        }
                    }
                    else
                    {
                        newCol++;
                        isPlayerWon = BonusCheck(playerRow, playerCol, isPlayerWon, playGround, newRow, newCol);
                    }
                }
                playerRow = newRow;
                playerCol = newCol;
            }
            else if (playGround[newRow, newCol] == 'T')
            {
            }
            else if (playGround[newRow, newCol] == 'F')
            {
                isPlayerWon = true;
                playGround[playerRow, playerCol] = '-';
                playGround[newRow, newCol] = 'f';
                playerRow = newRow;
                playerCol = newCol;
            }
        }

        private static bool BonusCheck(int playerRow, int playerCol, bool isPlayerWon, char[,] playGround, int newRow, int newCol)
        {
            if (playGround[newRow, newCol] == '-')
            {
                playGround[playerRow, playerCol] = '-';
                playGround[newRow, newCol] = 'f';
            }
            else if (playGround[newRow, newCol] == 'F')
            {
                isPlayerWon = true;
            }

            return isPlayerWon;
        }

        private static bool AreCoordinatesVallid(int row, int col, char[,] playGround)
        {
            return row >= 0 && row < playGround.GetLength(0) && col >= 0 && col < playGround.GetLength(1);
        }
    }
}

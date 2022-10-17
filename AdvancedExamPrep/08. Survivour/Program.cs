using System;
using System.Linq;

namespace _08._Survivour
{
    class Program
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            char[][] beaches = new char[rows][];

            int tokensCollected = 0;
            int opponentTokens = 0;

            for (int i = 0; i < rows; i++)
            {
                char[] rowInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();
                beaches[i] = rowInput;
            }

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Gong")
            {
                string[] cmds = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (cmds.Count() == 3)
                {
                    int row = int.Parse(cmds[1]);
                    int col = int.Parse(cmds[2]);
                    
                    if (AreCoordsVallid(row, col, beaches))
                    {
                        if (beaches[row][col] == 'T')
                        {
                            tokensCollected++;
                            beaches[row][col] = '-';
                        }
                    }
                }
                else if (cmds.Count() == 4)
                {
                    int row = int.Parse(cmds[1]);
                    int col = int.Parse(cmds[2]);
                    string direction = cmds[3];

                    if (AreCoordsVallid(row, col, beaches))
                    {
                        if (beaches[row][col] == 'T')
                        {
                            opponentTokens++;
                            beaches[row][col] = '-';
                        }
                        OpponentMove(row, col, direction, ref opponentTokens, beaches);
                    }
                }
            }
            foreach (var line in beaches)
            {
                var currentLine = string.Join(' ', line);
                Console.WriteLine(currentLine);
            }
            Console.WriteLine($"Collected tokens: {tokensCollected} ");
            Console.WriteLine($"Opponent's tokens: {opponentTokens} ");
        }
        private static bool AreCoordsVallid(int row, int col, char[][] beaches) 
        {
            return row >= 0 && row < beaches.GetLength(0)
                && col >= 0 && col < beaches[row].Length;
        }
        private static void OpponentMove(int row, int col, string direction, ref int opponentTokens,  char[][] beaches)
        {
            int oppRow = row;
            int oppCol = col;
            switch (direction)
            {
                case "up":
                    for (int i = 0; i < 3; i++)
                    {
                        if (AreCoordsVallid(oppRow - 1, oppCol, beaches))
                        {
                            if (beaches[oppRow -1][oppCol] == 'T')
                            {
                                opponentTokens++;
                                beaches[oppRow - 1][oppCol] = '-';
                                oppRow--;
                            }
                            else oppRow--;
                        }
                        else break;
                    }
                    break;
                case "down":
                    for (int i = 0; i < 3; i++)
                    {
                        if (AreCoordsVallid(oppRow + 1, oppCol, beaches))
                        {
                            if (beaches[oppRow + 1][oppCol] == 'T')
                            {
                                opponentTokens++;
                                beaches[oppRow + 1][oppCol] = '-';
                                oppRow++;
                            }
                            else oppRow++;
                        }
                        else break;
                    }
                    break;
                case "left":
                    for (int i = 0; i < 3; i++)
                    {
                        if (AreCoordsVallid(oppRow, oppCol -1, beaches))
                        {
                            if (beaches[oppRow][oppCol -1] == 'T')
                            {
                                opponentTokens++;
                                beaches[oppRow][oppCol -1] = '-';
                                oppCol--;
                            }
                            else oppCol--;
                        }
                        else break;
                    }
                    break;
                case "right":
                    for (int i = 0; i < 3; i++)
                    {
                        if (AreCoordsVallid(oppRow, oppCol + 1, beaches))
                        {
                            if (beaches[oppRow][oppCol + 1] == 'T')
                            {
                                opponentTokens++;
                                beaches[oppRow][oppCol + 1] = '-';
                                oppCol++;
                            }
                            else oppCol++;
                        }
                        else break;
                    }
                    break;
            }
        }
    }
}

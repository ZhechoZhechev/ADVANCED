using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Pawn_Wars
{
    class Program
    {
        static void Main()
        {
            Dictionary<int, string> rowsToChess = new Dictionary<int, string>();
            rowsToChess.Add(0, "8");
            rowsToChess.Add(1, "7");
            rowsToChess.Add(2, "6");
            rowsToChess.Add(3, "5");
            rowsToChess.Add(4, "4");
            rowsToChess.Add(5, "3");
            rowsToChess.Add(6, "2");
            rowsToChess.Add(7, "1");

            Dictionary<int, string> colsToChess = new Dictionary<int, string>();
            colsToChess.Add(0, "a");
            colsToChess.Add(1, "b");
            colsToChess.Add(2, "c");
            colsToChess.Add(3, "d");
            colsToChess.Add(4, "e");
            colsToChess.Add(5, "f");
            colsToChess.Add(6, "g");
            colsToChess.Add(7, "h");

            const int ROWS = 8;

            char[,] chessBoard = new char[ROWS, ROWS];

            int whitePRow = 0;
            int whitePCol = 0;

            int blackPRow = 0;
            int blackPCol = 0;

            for (int row = 0; row < ROWS; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < ROWS; col++)
                {
                    chessBoard[row, col] = input[col];
                    if (chessBoard[row, col] == 'w')
                    {
                        whitePRow = row;
                        whitePCol = col;
                    }
                    if (chessBoard[row, col] == 'b')
                    {
                        blackPRow = row;
                        blackPCol = col;
                    }
                }
            }

            while (true)
            {
                if (IsInMatrix(whitePRow - 1, whitePCol - 1) && chessBoard[whitePRow - 1,whitePCol - 1] == 'b')
                {
                    whitePRow = whitePRow - 1;
                    whitePCol = whitePCol - 1;
                    Console.WriteLine($"Game over! White capture on {colsToChess[whitePCol]}{rowsToChess[whitePRow]}.");
                    break;
                }
                else if (IsInMatrix(whitePRow - 1, whitePCol + 1) && chessBoard[whitePRow - 1, whitePCol + 1] == 'b')
                {
                    whitePRow = whitePRow - 1;
                    whitePCol = whitePCol + 1;
                    Console.WriteLine($"Game over! White capture on {colsToChess[whitePCol]}{rowsToChess[whitePRow]}.");
                    break;
                }
                else
                {
                    chessBoard[whitePRow, whitePCol] = '-';
                    chessBoard[whitePRow - 1, whitePCol] = 'w';
                    whitePRow--;
                    if (whitePRow == 0)
                    {
                        Console.WriteLine($"Game over! White pawn is promoted to a queen at {colsToChess[whitePCol]}{rowsToChess[whitePRow]}.");
                        break;
                    }
                }
                if (IsInMatrix(blackPRow + 1, blackPCol + 1) && chessBoard[blackPRow+1, blackPCol+1] == 'w')
                {
                    blackPRow = blackPRow + 1;
                    blackPCol = blackPCol + 1;
                    Console.WriteLine($"Game over! Black capture on {colsToChess[blackPCol]}{rowsToChess[blackPRow]}.");
                    break;
                }
                else if (IsInMatrix(blackPRow + 1, blackPCol - 1) && chessBoard[blackPRow + 1, blackPCol - 1] == 'w')
                {
                    blackPRow = blackPRow + 1;
                    blackPCol = blackPCol - 1;
                    Console.WriteLine($"Game over! Black capture on {colsToChess[blackPCol]}{rowsToChess[blackPRow]}.");
                    break;
                }
                else
                {
                    chessBoard[blackPRow, blackPCol] = '-';
                    chessBoard[blackPRow + 1, blackPCol] = 'b';
                    blackPRow++;
                    if (blackPRow == 7)
                    {
                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {colsToChess[blackPCol]}{rowsToChess[blackPRow]}.");
                        break;
                    }
                }
            }
        }
        //private static bool AreCoordinatesVallid(int row, int col, char[,] wall)
        //{
        //    return row >= 0 && row < wall.GetLength(0) && col >= 0 && col < wall.GetLength(1);
        //}
        private static bool IsInMatrix(int row, int col)
        {
            return row >= 0 && row <= 7 && col >= 0 && col <= 7;
        }
    }
}

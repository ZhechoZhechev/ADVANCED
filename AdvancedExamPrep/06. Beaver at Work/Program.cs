using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Beaver_at_Work
{
    class Program
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            char[,] pond = new char[rows, rows];

            int beaverRow = 0;
            int beaverCol = 0;
            string lastDirection = string.Empty;
            int branchesCount = 0;
            Stack<char> branches = new Stack<char>();

            for (int row = 0; row < rows; row++)
            {
                char[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int col = 0; col < rows; col++)
                {
                    pond[row, col] = input[col];
                    if (pond[row, col] == 'B')
                    {
                        beaverRow = row;
                        beaverCol = col;
                    }
                    if (char.IsLower(pond[row, col]))
                    {
                        branchesCount++;
                    }
                }
            }
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "end" && branchesCount != 0)
            {
                lastDirection = command;
                
                switch (command)
                {
                    case "up":
                        if (AreCoordinatesVallid(beaverRow-1, beaverCol, pond))
                        {
                            Move(-1, 0, ref beaverRow, ref beaverCol, ref branchesCount, lastDirection, branches, pond);
                        }
                        else
                        {
                            if(branches.Any()) branches.Pop();
                        }
                        break;
                    case "down":
                        if (AreCoordinatesVallid(beaverRow+1, beaverCol, pond))
                        {
                            Move(1, 0, ref beaverRow, ref beaverCol, ref branchesCount, lastDirection, branches, pond);
                        }
                        else
                        {
                            if (branches.Any()) branches.Pop();
                        }
                        break;
                    case "left":
                        if (AreCoordinatesVallid(beaverRow,beaverCol -1, pond))
                        {
                            Move(0, -1, ref beaverRow, ref beaverCol,ref branchesCount, lastDirection, branches, pond);
                        }
                        else
                        {
                            if (branches.Any()) branches.Pop();
                        }
                        break;
                    case "right":
                        if (AreCoordinatesVallid(beaverRow,beaverCol +1, pond))
                        {
                            Move(0, 1, ref beaverRow, ref beaverCol, ref branchesCount, lastDirection, branches, pond);
                        }
                        else
                        {
                            if (branches.Any()) branches.Pop();
                        }
                        break;
                }
            }
            if (branchesCount > 0)
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {branchesCount} branches left.");
            }
            else
            {
                Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches.Reverse())}.");
            }

            for (int i = 0; i < pond.GetLength(0); i++)
            {
                for (int j = 0; j < pond.GetLength(1); j++)
                {
                    Console.Write((char)pond[i, j]);
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }

        public static bool AreCoordinatesVallid(int row, int col, char[,] pond)
        {
            return row >= 0 && row < pond.GetLength(0) && col >= 0 && col < pond.GetLength(1);
        }
        public static void Move(int row, int col,ref int beaverRow,ref int beaverCol,ref int branchesCount,
            string lastDirection, Stack<char> branches, char[,] pond)
        {
            int newBRow = beaverRow + row;
            int newBCol = beaverCol + col;
            if (char.IsLower(pond[newBRow, newBCol]))
            {
                branches.Push(pond[newBRow, newBCol]);
                branchesCount--;
                pond[newBRow, newBCol] = 'B';
                pond[beaverRow, beaverCol] = '-';
                beaverRow = newBRow;
                beaverCol = newBCol;
            }
            else if (pond[newBRow, newBCol] == '-')
            {
                pond[newBRow, newBCol] = 'B';
                pond[beaverRow, beaverCol] = '-';
                beaverRow = newBRow;
                beaverCol = newBCol;
            }
            else if (pond[newBRow, newBCol] == 'F')
            {
                pond[newBRow, newBCol] = '-';
                if (lastDirection == "up")
                {
                    if (newBRow == 0)
                    {
                        //pound[newBRow, newBCol] = '-';
                        if (char.IsLower(pond[pond.GetLength(0) - 1, newBCol]))
                        {
                            branches.Push(pond[pond.GetLength(0) - 1, newBCol]);
                            branchesCount--;
                        }
                        pond[pond.GetLength(0) - 1, newBCol] = 'B';
                        pond[beaverRow, beaverCol] = '-';
                        beaverRow = pond.GetLength(0) - 1;
                    }
                    else
                    {
                        if (char.IsLower(pond[0, newBCol]))
                        {
                            branches.Push(pond[0, newBCol]);
                            branchesCount--;
                        }
                        pond[0, newBCol] = 'B';
                        pond[beaverRow, beaverCol] = '-';
                        beaverRow = 0;
                    }
                }
                else if (lastDirection == "down")
                {
                    if (newBRow == pond.GetLength(0) - 1)
                    {
                        //pound[newBRow, newBCol] = '-';
                        if (char.IsLower(pond[0, newBCol]))
                        {
                            branches.Push(pond[0, newBCol]);
                            branchesCount--;
                        }
                        pond[0, newBCol] = 'B';
                        pond[beaverRow, beaverCol] = '-';
                        beaverRow = 0;
                    }
                    else
                    {
                        if (char.IsLower(pond[pond.GetLength(0) - 1, newBCol]))
                        {
                            branches.Push(pond[pond.GetLength(0) - 1, newBCol]);
                            branchesCount--;
                        }
                        pond[pond.GetLength(0) - 1, newBCol] = 'B';
                        pond[beaverRow, beaverCol] = '-';
                        beaverRow = pond.GetLength(0) - 1;
                    }
                }
                else if (lastDirection == "left") 
                {
                    if (newBCol == 0)
                    {
                        //pound[newBRow, newBCol] = '-';
                        if (char.IsLower(pond[newBRow, pond.GetLength(1) - 1]))
                        {
                            branches.Push(pond[newBRow, pond.GetLength(1) - 1]);
                            branchesCount--;
                        }
                        pond[newBRow, pond.GetLength(1) - 1] = 'B';
                        pond[beaverRow, beaverCol] = '-';
                        beaverCol = pond.GetLength(1) - 1;
                    }
                    else
                    {
                        if (char.IsLower(pond[newBRow, 0]))
                        {
                            branches.Push(pond[newBRow, 0]);
                            branchesCount--;
                        }
                        pond[newBRow, 0] = 'B';
                        pond[beaverRow, beaverCol] = '-';
                        beaverCol = 0;
                    }
                }
                else if (lastDirection == "right")
                {
                    if (newBCol == pond.GetLength(1) - 1)
                    {
                        //pound[newBRow, newBCol] = '-';
                        if (char.IsLower(pond[newBRow, 0]))
                        {
                            branches.Push(pond[newBRow, 0]);
                            branchesCount--;
                        }
                        pond[newBRow, 0] = 'B';
                        pond[beaverRow, beaverCol] = '-';
                        beaverCol = 0;
                    }
                    else
                    {
                        if (char.IsLower(pond[newBRow, pond.GetLength(1) - 1]))
                        {
                            branches.Push(pond[newBRow, pond.GetLength(1) - 1]);
                            branchesCount--;
                        }
                        pond[newBRow, pond.GetLength(1) - 1] = 'B';
                        pond[beaverRow, beaverCol] = '-';
                        beaverCol = pond.GetLength(1) - 1;
                    }
                }
            }
            else
            {
                pond[newBRow, newBCol] = 'B';
                pond[beaverRow, beaverCol] = '-';
                beaverRow = newBRow;
                beaverCol = newBCol;
            }
        }
    }
}

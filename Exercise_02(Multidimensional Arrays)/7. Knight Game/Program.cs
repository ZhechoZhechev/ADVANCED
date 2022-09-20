using System;

namespace _7._Knight_Game
{
    class Program
    {
        static void Main()
        {

            int size = int.Parse(Console.ReadLine());

            if (size < 3)
            {
                Console.WriteLine(0);
                return;
            }

            char[,] board = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                string colContent = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    board[row, col] = colContent[col];
                }
            }

            int knightsRemoved = 0;

            while (true)
            {
                int mostAttackingCount = 0;
                int mostAttackingKnightRow = 0;
                int mostAttackingKnightCol = 0;

                for (int row = 0; row < size; row++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        if (board[row,col] == 'K')
                        {
                            int curKnightAttacks = CountAttackedKnights(row, col, size, board);
                            
                            if (curKnightAttacks > mostAttackingCount)
                            {
                                mostAttackingCount = curKnightAttacks;
                                mostAttackingKnightRow = row;
                                mostAttackingKnightCol = col;
                            }
                        }

                    }
                }
                if (mostAttackingCount == 0)
                {
                    break;
                }
                else
                {
                    board[mostAttackingKnightRow, mostAttackingKnightCol] = '0';
                    knightsRemoved++;
                }
            }
            Console.WriteLine(knightsRemoved);
        }

        static int CountAttackedKnights(int row, int col, int size, char[,] board)
        {
            int attackedKnights = 0;
            //horizontal left-up
            if (IsAttackedCellVallid(row -1, col -2, size))
            {
                if (board[row - 1, col - 2] == 'K')
                {
                    attackedKnights++;
                }
            }
            
            if (IsAttackedCellVallid(row + 1, col - 2, size))
            {
                if (board[row + 1, col - 2] == 'K')
                {
                    attackedKnights++;
                }
            }

            if (IsAttackedCellVallid(row - 1, col + 2, size))
            {
                if (board[row - 1, col + 2] == 'K')
                {
                    attackedKnights++;
                }
            }

            if (IsAttackedCellVallid(row + 1, col + 2, size))
            {
                if (board[row + 1, col + 2] == 'K')
                {
                    attackedKnights++;
                }
            }

            if (IsAttackedCellVallid(row - 2, col - 1, size))
            {
                if (board[row - 2, col - 1] == 'K')
                {
                    attackedKnights++;
                }
            }

            if (IsAttackedCellVallid(row - 2, col + 1, size))
            {
                if (board[row - 2, col + 1] == 'K')
                {
                    attackedKnights++;
                }
            }

            if (IsAttackedCellVallid(row + 2, col - 1, size))
            {
                if (board[row + 2, col - 1] == 'K')
                {
                    attackedKnights++;
                }
            }

           if (IsAttackedCellVallid(row + 2, col + 1, size))
            {
                if (board[row + 2, col + 1] == 'K')
                {
                    attackedKnights++;
                }
            }

            return attackedKnights;
        }
        static bool IsAttackedCellVallid(int row, int col, int size) 
        {
            return row >= 0 && row < size && col >= 0 && col < size;
        }
    }
}

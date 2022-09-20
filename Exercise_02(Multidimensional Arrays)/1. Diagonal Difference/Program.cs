using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            int[,] intMatrix = new int[rows, rows];
            
            int rightDiagSum = 0;
            int leftDiagSum = 0;

            for (int row = 0; row < rows; row++)
            {
                int[] colInput = Console.ReadLine().Trim().Split().Select(int.Parse).ToArray();
                
                for (int col = 0; col < rows; col++)
                {
                    intMatrix[row, col] = colInput[col];
                    
                    if (row == col)
                    {
                        rightDiagSum += intMatrix[row, col];
                    }
                    if (col == rows - 1 - row)
                    {
                        leftDiagSum += intMatrix[row, col];
                    }
                }
            }

            Console.WriteLine(Math.Abs(rightDiagSum - leftDiagSum));
        }
    }
}

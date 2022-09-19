using System;
using System.Linq;

namespace _3._Primary_Diagonal
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int rows = n;
            int columns = n;

            int[,] intMatrix = new int[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                int[] colNums = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < columns; col++)
                {
                    intMatrix[row, col] = colNums[col];
                }
            }
            int primDiagSum = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i == j)
                    {
                        primDiagSum += intMatrix[i, j];
                    }
                }
            }
            Console.WriteLine(primDiagSum);
        }
    }
}

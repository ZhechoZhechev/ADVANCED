using System;

namespace _7._Pascal_Triangle
{
    class Program
    {
        static void Main()
        {
            long rowsCount = long.Parse(Console.ReadLine());

            long[][] jaggedMatrix = new long[rowsCount][];

            jaggedMatrix[0] = new long[1];
            jaggedMatrix[0][0] = 1;

            for (long row = 1; row < rowsCount; row++)
            {
                jaggedMatrix[row] = new long[row + 1];
                jaggedMatrix[row][0] = 1;
                jaggedMatrix[row][jaggedMatrix[row].Length - 1] = 1;

                for (long col = 1; col < jaggedMatrix[row].Length - 1; col++)
                {
                    long leftDiagonal = jaggedMatrix[row - 1][col - 1];
                    long rightDiagonal = jaggedMatrix[row - 1][col];

                    jaggedMatrix[row][col] = leftDiagonal + rightDiagonal;
                }
            }

            for (int row = 0; row < jaggedMatrix.Length; row++)
            {
                Console.WriteLine($"{string.Join(" ", jaggedMatrix[row])}");
            }
        }
    }
}

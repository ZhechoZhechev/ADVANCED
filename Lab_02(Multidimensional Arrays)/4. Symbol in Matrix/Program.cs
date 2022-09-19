using System;

namespace _4._Symbol_in_Matrix
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int rows = n;
            int columns = n;

            char[,] charMatrix = new char[rows, columns];

            for (int row = 0; row < rows; row++)
            {
                string colInput = Console.ReadLine();
                
                for (int col = 0; col < columns; col++)
                {
                    charMatrix[row, col] = colInput[col];
                }
            }
            char symbol = char.Parse(Console.ReadLine());

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (charMatrix[i,j] == symbol)
                    {
                        Console.WriteLine($"({i}, {j})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{symbol} does not occur in the matrix");
        }
    }
}

using System;
using System.Linq;

namespace Problem_02
{
    class Program
    {
        static void Main()
        {
            //квадратна матрица
            int rows = int.Parse(Console.ReadLine());
            string racingNumber = Console.ReadLine();

            char[,] raceTrack = new char[rows, rows];

            int killometersCovered = 0;
            int carRow = 0;
            int carCol = 0;
            bool carWon = false;

            for (int row = 0; row < rows; row++)
            {
                char[] colsInfo = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse)
                    .ToArray();
                for (int col = 0; col < rows; col++)
                {
                    raceTrack[row, col] = colsInfo[col];
                }
            }
            raceTrack[carRow, carCol] = 'C';

            string commands = string.Empty;
            while ((commands = Console.ReadLine()) != "End")
            {

                if (carWon) break;

                if (commands == "up")
                {
                    Move(-1, 0, ref carRow, ref carCol, ref carWon, ref killometersCovered, raceTrack);
                }
                else if (commands == "down")
                {
                    Move(1, 0, ref carRow, ref carCol, ref carWon, ref killometersCovered, raceTrack);
                }
                else if (commands == "left")
                {
                    Move(0, -1, ref carRow, ref carCol, ref carWon, ref killometersCovered, raceTrack);
                }
                else if (commands == "right")
                {
                    Move(0, 1, ref carRow, ref carCol, ref carWon, ref killometersCovered, raceTrack);
                }
            }

            if (carWon)
            {
                Console.WriteLine($"Racing car {racingNumber} finished the stage!");
            }
            else
            {
                Console.WriteLine($"Racing car {racingNumber} DNF.");
            }
            Console.WriteLine($"Distance covered {killometersCovered} km.");
            PrintMatrix(raceTrack);
        }

        private static void Move(int row, int col, ref int carRow, ref int carCol, ref bool carWon, ref int killometersCovered, char[,] raceTrack)
        {
            int newRow = carRow + row;
            int newCol = carCol + col;

            if (raceTrack[newRow, newCol] == '.')
            {
                raceTrack[carRow, carCol] = '.';
                carRow = newRow;
                carCol = newCol;
                killometersCovered += 10;
            }
            else if (raceTrack[newRow, newCol] == 'T')
            {
                raceTrack[carRow, carCol] = '.';
                raceTrack[newRow, newCol] = '.';
                int secondSRow = 0;
                int secondSCol = 0;
                for (int i = 0; i < raceTrack.GetLength(0); i++)
                {
                    for (int j = 0; j < raceTrack.GetLength(1); j++)
                    {
                        if (raceTrack[i, j] == 'T' && (i != newRow || j != newCol))
                        {
                            secondSRow = i;
                            secondSCol = j;
                            break;
                        }
                    }
                }
                carRow = secondSRow;
                carCol = secondSCol;
                killometersCovered += 30;
            }
            else if (raceTrack[newRow, newCol] == 'F')
            {
                raceTrack[carRow, carCol] = '.';
                carRow = newRow;
                carCol = newCol;
                killometersCovered += 10;
                carWon = true;
            }
            raceTrack[carRow, carCol] = 'C';
        }
        private static void PrintMatrix(char[,] raceTrack)
        {
            for (int row = 0; row < raceTrack.GetLength(0); row++)
            {
                for (int col = 0; col < raceTrack.GetLength(1); col++)
                {
                    Console.Write($"{raceTrack[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }

}

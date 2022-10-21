using System;

namespace _20._Help_A_Mole
{
    class Program
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            char[,] playField = new char[rows, rows];

            int molRow = 0;
            int molCol = 0;
            int molPoints = 0;

            for (int row = 0; row < rows; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < rows; col++)
                {
                    playField[row, col] = input[col];
                    if (playField[row, col] == 'M')
                    {
                        molRow = row;
                        molCol = col;
                    }
                }
            }
            string commands = string.Empty;
            while ((commands = Console.ReadLine()) != "End" && molPoints < 25)
            {
                if (commands == "up")
                {
                    Move(-1, 0, ref molRow, ref molCol, ref molPoints, playField);
                }
                else if (commands == "down")
                {
                    Move(1, 0, ref molRow, ref molCol, ref molPoints, playField);
                }
                else if (commands == "left")
                {
                    Move(0, -1, ref molRow, ref molCol, ref molPoints, playField);
                }
                else if (commands == "right")
                {
                    Move(0, 1, ref molRow, ref molCol, ref molPoints, playField);
                }
            }
            string result = string.Empty;
            result = molPoints >= 25 ? "Yay! The Mole survived another game!" : "Too bad! The Mole lost this battle!";
            Console.WriteLine(result);
            result = molPoints >= 25 ? $"The Mole managed to survive with a total of {molPoints} points." :
                $"The Mole lost the game with a total of {molPoints} points.";
            Console.WriteLine(result);
            PrintMatrix(playField);
        }

        private static void Move(int row, int col, ref int molRow, ref int molCol, ref int molPoints, char[,] playField)
        {
            int newRow = molRow + row;
            int newCol = molCol + col;
            if (AreCoordinatesVallid(newRow, newCol, playField))
            {
                if (playField[newRow, newCol] == '-')
                {
                    playField[molRow, molCol] = '-';
                    molRow = newRow;
                    molCol = newCol;
                }
                else if (char.IsDigit(playField[newRow, newCol]))
                {
                    playField[molRow, molCol] = '-';
                    char curChar = playField[newRow, newCol];
                    int curDigit = (int)Char.GetNumericValue(curChar);
                    molPoints += curDigit;
                    molRow = newRow;
                    molCol = newCol;
                }
                else if (playField[newRow, newCol] == 'S')
                {
                    int secondSRow = 0;
                    int secondSCol = 0;
                    for (int i = 0; i < playField.GetLength(0); i++)
                    {
                        for (int j = 0; j < playField.GetLength(1); j++)
                        {
                            if (playField[i, j] == 'S' && (i != newRow || j != newCol))
                            {
                                secondSRow = i;
                                secondSCol = j;
                                break;
                            }
                        }
                    }
                    playField[newRow, newCol] = '-';
                    playField[molRow, molCol] = '-';
                    molRow = secondSRow;
                    molCol = secondSCol;
                    molPoints -= 3;

                }
                
                playField[molRow, molCol] = 'M';
            }
            else
            {
                Console.WriteLine("Don't try to escape the playing field!");
            }
        }

        public static bool AreCoordinatesVallid(int row, int col, char[,] playField)
        {
            return row >= 0 && row < playField.GetLength(0) && col >= 0 && col < playField.GetLength(1);
        }
        private static void PrintMatrix(char[,] playField)
        {
            for (int row = 0; row < playField.GetLength(0); row++)
            {
                for (int col = 0; col < playField.GetLength(1); col++)
                {
                    Console.Write($"{playField[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}

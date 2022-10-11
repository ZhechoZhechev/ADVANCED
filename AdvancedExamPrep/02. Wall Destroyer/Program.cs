using System;

namespace _02._Wall_Destroyer
{
    class Program
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());

            char[,] wall = new char[rows, rows];

            int holesMade = 1;
            int rodesHit = 0;
            int vankoRow = 0;
            int vankoCol = 0;

            bool isAlive = true;

            for (int row = 0; row < rows; row++)
            {
                string input = Console.ReadLine();
                for (int col = 0; col < rows; col++)
                {
                    wall[row, col] = input[col];
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < rows; col++)
                {
                    if (wall[row, col] == 'V')
                    {
                        vankoRow = row;
                        vankoCol = col;
                        break;
                    }
                }
            }
            string comand = string.Empty;

            while ((comand = Console.ReadLine()) != "End")
            {

                switch (comand)
                {
                    case "up":
                        if (AreCoordinatesVallid(vankoRow - 1, vankoCol, wall))
                        {
                            if (wall[vankoRow - 1, vankoCol] == 'C')
                            {
                                wall[vankoRow, vankoCol] = '*';
                                vankoRow = vankoRow - 1;
                                holesMade++;
                                wall[vankoRow, vankoCol] = 'E';
                                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesMade} hole(s).");
                                PrintConsole(wall);
                                return;
                            }
                            else if (wall[vankoRow - 1, vankoCol] == 'R')
                            {
                                rodesHit++;
                                Console.WriteLine($"Vanko hit a rod!");
                            }
                            else if (wall[vankoRow - 1, vankoCol] == '-')
                            {
                                wall[vankoRow, vankoCol] = '*';
                                vankoRow = vankoRow - 1;
                                wall[vankoRow, vankoCol] = 'V';
                                holesMade++;
                            }
                            else if (wall[vankoRow - 1, vankoCol] == '*')
                            {
                                wall[vankoRow, vankoCol] = '*';
                                Console.WriteLine($"The wall is already destroyed at position [{vankoRow - 1}, {vankoCol}]!");
                                vankoRow = vankoRow - 1;
                                wall[vankoRow, vankoCol] = 'V';
                            }
                        }
                        break;
                    case "down":
                        if (AreCoordinatesVallid(vankoRow + 1, vankoCol, wall))
                        {
                            if (wall[vankoRow + 1, vankoCol] == 'C')
                            {
                                wall[vankoRow, vankoCol] = '*';
                                vankoRow = vankoRow + 1;
                                holesMade++;
                                wall[vankoRow, vankoCol] = 'E';
                                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesMade} hole(s).");
                                PrintConsole(wall);
                                return;
                            }
                            else if (wall[vankoRow + 1, vankoCol] == 'R')
                            {
                                rodesHit++;
                                Console.WriteLine($"Vanko hit a rod!");
                            }
                            else if (wall[vankoRow + 1, vankoCol] == '-')
                            {
                                wall[vankoRow, vankoCol] = '*';
                                vankoRow = vankoRow + 1;
                                wall[vankoRow, vankoCol] = 'V';
                                holesMade++;
                            }
                            else if (wall[vankoRow + 1, vankoCol] == '*')
                            {
                                wall[vankoRow, vankoCol] = '*';
                                Console.WriteLine($"The wall is already destroyed at position [{vankoRow + 1}, {vankoCol}]!");
                                vankoRow = vankoRow + 1;
                                wall[vankoRow, vankoCol] = 'V';
                            }
                        }
                        break;
                    case "left":
                        if (AreCoordinatesVallid(vankoRow, vankoCol - 1, wall))
                        {
                            if (wall[vankoRow, vankoCol - 1] == 'C')
                            {
                                wall[vankoRow, vankoCol] = '*';
                                vankoCol = vankoCol - 1;
                                holesMade++;
                                wall[vankoRow, vankoCol] = 'E';
                                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesMade} hole(s).");
                                PrintConsole(wall);
                                return;
                            }
                            else if (wall[vankoRow, vankoCol - 1] == 'R')
                            {
                                rodesHit++;
                                Console.WriteLine($"Vanko hit a rod!");
                            }
                            else if (wall[vankoRow, vankoCol - 1] == '-')
                            {
                                wall[vankoRow, vankoCol] = '*';
                                vankoCol = vankoCol - 1;
                                wall[vankoRow, vankoCol] = 'V';
                                holesMade++;
                            }
                            else if (wall[vankoRow, vankoCol - 1] == '*')
                            {
                                wall[vankoRow, vankoCol] = '*';
                                Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol - 1}]!");
                                vankoCol = vankoCol - 1;
                                wall[vankoRow, vankoCol] = 'V';
                            }
                        }
                        break;
                    case "right":
                        if (AreCoordinatesVallid(vankoRow, vankoCol + 1, wall))
                        {
                            if (wall[vankoRow, vankoCol + 1] == 'C')
                            {
                                wall[vankoRow, vankoCol] = '*';
                                vankoCol = vankoCol + 1;
                                holesMade++;
                                wall[vankoRow, vankoCol] = 'E';
                                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesMade} hole(s).");
                                PrintConsole(wall);
                                return;
                            }
                            else if (wall[vankoRow, vankoCol + 1] == 'R')
                            {
                                rodesHit++;
                                Console.WriteLine($"Vanko hit a rod!");
                            }
                            else if (wall[vankoRow, vankoCol + 1] == '-')
                            {
                                wall[vankoRow, vankoCol] = '*';
                                vankoCol = vankoCol + 1;
                                wall[vankoRow, vankoCol] = 'V';
                                holesMade++;
                            }
                            else if (wall[vankoRow, vankoCol + 1] == '*')
                            {
                                wall[vankoRow, vankoCol] = '*';
                                Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoCol + 1}]!");
                                vankoCol = vankoCol + 1;
                                wall[vankoRow, vankoCol] = 'V';
                            }
                        }
                        break;
                        //comand = Console.ReadLine();
                }
            }
           
                Console.WriteLine($"Vanko managed to make {holesMade} hole(s) and he hit only {rodesHit} rod(s).");

            PrintConsole(wall);

        }

        private static void PrintConsole(char[,] wall)
        {
            for (int row = 0; row < wall.GetLength(0); row++)
            {
                for (int col = 0; col < wall.GetLength(1); col++)
                {
                    Console.Write(wall[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static bool AreCoordinatesVallid(int row, int col, char[,] wall)
        {
            return row >= 0 && row < wall.GetLength(0) && col >= 0 && col < wall.GetLength(1);
        }
    }
}

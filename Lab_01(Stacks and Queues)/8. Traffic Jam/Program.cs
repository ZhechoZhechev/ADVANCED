using System;
using System.Collections;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    class Program
    {
        static void Main()
        {
            int greenPassCounter = int.Parse(Console.ReadLine());

            Queue<string> queuedCars = new Queue<string>();

            string input = string.Empty;

            int passedCarsCounter = 0;

            while ((input = Console.ReadLine()) != "end")
            {
                if (input != "green")
                {
                    queuedCars.Enqueue(input);
                }
                else
                {
                    for (int i = 1; i <= greenPassCounter; i++)
                    {
                        if (queuedCars.Count > 0)
                        {
                            string curCar = queuedCars.Dequeue();
                            Console.WriteLine($"{curCar} passed!");
                            passedCarsCounter++;
                        }
                    }
                }
            }
            Console.WriteLine($"{passedCarsCounter} cars passed the crossroads.");
        }
    }
}

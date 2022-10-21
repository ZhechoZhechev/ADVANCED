using System;
using System.Collections.Generic;
using System.Linq;

namespace _18._Crossroads
{
    class Program
    {
        static void Main()
        {
            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());


            Queue<string> cars = new Queue<string>();

            string curCar = string.Empty;
            string input = string.Empty;
            int totalCarPassed = 0;
            bool carsPassed = true;
            char charHit = default(char);

            while ((input = Console.ReadLine()) != "END")
            {
                if (input != "green")
                {
                    cars.Enqueue(input);
                }
                else
                {
                    int thisTurnGreen = greenLight;
                    int thisTurnWidnow = freeWindow;
                    while (cars.Any())
                    {
                        curCar = cars.Peek();
                        if (curCar.Length <= thisTurnGreen)
                        {
                            cars.Dequeue();
                            totalCarPassed++;
                            thisTurnGreen -= curCar.Length;
                            if (thisTurnGreen == 0)
                            {
                                break;
                            }
                        }
                        else if (curCar.Length <= thisTurnGreen + thisTurnWidnow)
                        {
                            cars.Dequeue();
                            totalCarPassed++;
                            break;
                        }
                        else
                        {
                            charHit = curCar[(thisTurnGreen + thisTurnWidnow)];
                            carsPassed = false;
                            break;
                        }
                    }

                }
            }
            if (carsPassed)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{totalCarPassed} total cars passed the crossroads.");
            }
            else
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{curCar} was hit at {charHit}.");
            }
        }
    }
}

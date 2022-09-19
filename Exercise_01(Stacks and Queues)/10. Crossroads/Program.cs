using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int greanLight = int.Parse(Console.ReadLine());
            int friWindow = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            int count = 0;
            bool flag = false;

            while (true)
            {
                string comand = Console.ReadLine();
                if (comand == "green")
                {
                    int tempGreenLight = greanLight;

                    while (true)
                    {
                        if (cars.Count == 0)
                        {
                            break;
                        }
                        string car = cars.Peek();
                        if (car.Length <= tempGreenLight)
                        {
                            cars.Dequeue();
                            count++;
                            tempGreenLight -= car.Length;
                            if (tempGreenLight == 0)
                            {
                                break;
                            }
                        }
                        else if (car.Length <= friWindow + tempGreenLight)
                        {
                            count++;
                            cars.Dequeue();
                            break;
                        }
                        else
                        {
                            // A crash happened!
                            //Hummer was hit at e.
                            Console.WriteLine("A crash happened!");
                            Console.WriteLine($"{car} was hit at {car[tempGreenLight + friWindow]}.");
                            return;

                        }
                    }
                }
                else if (comand == "END")
                {
                    flag = true;
                    break;
                }
                else
                {
                    cars.Enqueue(comand);
                }
            }

            if (flag)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{count} total cars passed the crossroads.");
            }

        }
    }
}
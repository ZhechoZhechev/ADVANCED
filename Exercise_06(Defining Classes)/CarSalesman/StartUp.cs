using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main()
        {
            int engineNum = int.Parse(Console.ReadLine());

            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < engineNum; i++)
            {
                string[] engineInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                engines.Add(CreateNewEngine(engineInfo));
            }

            int carNum = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();

            for (int i = 0; i < carNum; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                cars.Add(CreateACar(carInfo, engines));
            }
            foreach (Car item in cars)
            {
                Console.WriteLine(item);
            }

        }
        private static Car CreateACar(string[] carInfo, List<Engine> engines)
        {
            string model = carInfo[0];
            string modelEngine = carInfo[1];
            Engine engine = engines.Find(x => x.Model == modelEngine);
            if (carInfo.Length == 2)
            {
                return new Car(model, engine);
            }
            else if (carInfo.Length == 3)
            {
                bool isAnInteger = int.TryParse(carInfo[2], out _);
                if (isAnInteger)
                {
                    return new Car(model, engine, int.Parse(carInfo[2]));
                }
                else
                {
                    return new Car(model, engine, carInfo[2]);
                }
            }
            else
            {
                return new Car(model, engine, int.Parse(carInfo[2]), carInfo[3]);
            }

        }

        private static Engine CreateNewEngine(string[] engineInfo)
        {
            if (engineInfo.Length == 2)
            {
                return new Engine(engineInfo[0], int.Parse(engineInfo[1]));
            }
            else if (engineInfo.Length == 3)
            {
                string item = engineInfo[2];
                int displacement;
                bool isItAnInteger = int.TryParse(item, out displacement);
                if (isItAnInteger)
                {
                    return new Engine(engineInfo[0], int.Parse(engineInfo[1]), displacement);
                }
                else
                {
                    return new Engine(engineInfo[0], int.Parse(engineInfo[1]), item);
                }

            }
            else
            {
                int displacement = int.Parse(engineInfo[2]);
                string efficiency = engineInfo[3];

                return new Engine(engineInfo[0], int.Parse(engineInfo[1]), displacement, efficiency);
            }
           


        }
    }
}

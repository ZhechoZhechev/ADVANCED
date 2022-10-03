using System;
using System.Collections.Generic;
using System.Linq;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            List<Tire[]> tirePacks = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();
            string input;
            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] tireYearAndPressure = input.Split();
                Tire[] singleTires = new Tire[4];
                int indexCounter = 0;
                for (int i = 0; i < 4; i++)
                {
                    int tireYear = int.Parse(tireYearAndPressure[indexCounter]);
                    indexCounter++;
                    double pressureValue = double.Parse(tireYearAndPressure[indexCounter]);
                    singleTires[i] = new Tire(tireYear, pressureValue);
                    indexCounter++;
                }
                tirePacks.Add(singleTires);
            }

            while ((input = Console.ReadLine()) != "Engines done")
            {
                string[] engineInfo = input.Split();
                int horsePower = int.Parse(engineInfo[0]);
                double cubicCapacity = double.Parse(engineInfo[1]);
                engines.Add(new Engine(horsePower, cubicCapacity));
            }

            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] carInfo = input.Split();
                string make = carInfo[0];
                string model = carInfo[1];
                int year = int.Parse(carInfo[2]);
                double fuelQuantity = double.Parse(carInfo[3]);
                double fuelConsumption = double.Parse(carInfo[4]);
                int engineIndex = int.Parse(carInfo[5]);
                int tiresIndex = int.Parse(carInfo[6]);

                Tire[] currentCarTires = tirePacks[tiresIndex];
                Engine currentCarEngine = engines[engineIndex];
                cars.Add(new Car(make, model, year, fuelQuantity, fuelConsumption, currentCarEngine, currentCarTires));
            }

            List<Car> specialCars = cars
                .FindAll(c => c.Year >= 2017
                           && c.Engine.HorsePower > 330
                           && c.Tires.Select(t => t.Preassure).Sum() >= 9
                           && c.Tires.Select(t => t.Preassure).Sum() <= 10);

            foreach (Car car in specialCars)
            {
                car.Drive(20);
                Console.WriteLine(car);
            }

        }
    }
}

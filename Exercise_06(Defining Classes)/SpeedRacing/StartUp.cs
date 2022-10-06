using System;
using System.Collections.Generic;
using System.Linq;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main()
        {
            int carsCount = int.Parse(Console.ReadLine());

            List<Car> carsList = new List<Car>(); 

            for (int i = 0; i < carsCount; i++)
            {
                string[] carInfo = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = carInfo[0];
                double fuelAmount = double.Parse(carInfo[1]);
                double fuelConsmpPerKm = double.Parse(carInfo[2]);

                Car car = new Car(model, fuelAmount, fuelConsmpPerKm);
                carsList.Add(car);
            }

            string input = string.Empty;

            while ((input= Console.ReadLine()) != "End")
            {
                string[] commands = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string carModel = commands[1];
                int kmsToTravel = int.Parse(commands[2]);

                var curCar = carsList.First(x => x.Model == carModel);
                curCar.DriveACar(kmsToTravel);
            }
            foreach (Car car in carsList)
            {
                Console.WriteLine(car);
            }
        }
    }
}

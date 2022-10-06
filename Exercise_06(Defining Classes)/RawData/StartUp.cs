using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{
    class StartUp
    {
        static void Main()
        {
            int carsCount = int.Parse(Console.ReadLine());

            List<Car> cars = new List<Car>();
            
            for (int i = 0; i < carsCount; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Car car = new Car(
                    input[0],
                    int.Parse(input[1]),
                    int.Parse(input[2]),
                    int.Parse(input[3]),
                    input[4],
                    double.Parse(input[5]),
                    int.Parse(input[6]),
                    double.Parse(input[7]),
                    int.Parse(input[8]),
                    double.Parse(input[9]),
                    int.Parse(input[10]),
                    double.Parse(input[11]),
                    int.Parse(input[12])
                    );
                cars.Add(car);
            }

            string command = Console.ReadLine();

            List<string> filteredCars = new List<string>();

            if (command == "fragile")
            {
                filteredCars = cars.Where(x => x.Cargo.Type == "fragile" && x.Tyres.Any(y => y.Pressure < 1))
                    .Select(z => z.Model).ToList();
            }
            else
            {
                filteredCars = cars.Where(x => x.Cargo.Type == "flammable" && x.Engine.Power > 250)
                    .Select(z => z.Model).ToList();
            }

            Console.WriteLine(string.Join(Environment.NewLine, filteredCars));
        }
    }
}

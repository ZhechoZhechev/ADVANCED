using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        public Car()
        {
            TravelledDistance = 0;
        }
        public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer) :this()
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        }
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumptionPerKilometer { get; set; }
        public double TravelledDistance { get; set; }

        public void DriveACar(int distance) 
        {
            double consumedFuel = distance * FuelConsumptionPerKilometer;
            if (consumedFuel > FuelAmount)
            {
                Console.WriteLine("Insufficient fuel for the drive");
                return;
            }
            FuelAmount -= consumedFuel;
            TravelledDistance += distance;
        }
        public override string ToString()
        {
            return $"{Model} {FuelAmount:f2} {TravelledDistance}";
        }
    }
}

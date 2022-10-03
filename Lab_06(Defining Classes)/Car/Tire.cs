using System;


namespace CarManufacturer
{
    public class Tire
    {
        private int year;
        private double pressure;

        public int Year { get { return year; } set { year = value; } }
        public double Preassure { get { return pressure; } set { pressure = value; } }

        public Tire(int year, double preassure)
        {
            this.Year = year;
            this.Preassure = preassure;
        }
    }
}
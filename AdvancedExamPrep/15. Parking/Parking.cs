using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;

        public Parking(string type, int capacity)
        {
            Type = type;
            Capacity = capacity;
            Data = new List<Car>();
        }

        public List<Car> Data
        {
            get { return data; }
            set { data = value; }
        }
        public string Type { get; set; }
        public int Capacity { get; set; }
        public int Count => Data.Count;
        public void Add(Car car) 
        {
            if (Capacity > Data.Count)
            {
                Data.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model) 
        {
            var carToRemove = Data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
            if (carToRemove == null)
            {
                return false;
            }
            else
            {
                Data.Remove(carToRemove);
                return true;
            }
        }
        public Car GetLatestCar() 
        {
            return Data.OrderByDescending(x => x.Year).FirstOrDefault();
        }
        public Car GetCar(string manufacturer, string model) 
        {
            return Data.FirstOrDefault(x => x.Manufacturer == manufacturer && x.Model == model);
        }
        public string GetStatistics() 
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The cars are parked in {Type}:");
            foreach (var car in Data)
            {
                sb.AppendLine(car.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}

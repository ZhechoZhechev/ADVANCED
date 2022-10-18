using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TheRace
{
    public class Race
    {
        private List<Racer> data;

        public Race(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.data = new List<Racer>();
        }

        public List<Racer> Data
        {
            get { return data; }
            set { data = value; }
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count => Data.Count;

        public void Add(Racer Racer) 
        {
            if (Capacity > Data.Count)
            {
                Data.Add(Racer);
            }
        }
        public bool Remove(string name) 
        {
            var curRacer = Data.FirstOrDefault(x => x.Name == name);
            if (curRacer== null)
            {
                return false;
            }
            else
            {
                Data.Remove(curRacer);
                return true;
            }
        }
        public Racer GetOldestRacer() 
        {
            return Data.OrderByDescending(x => x.Age).FirstOrDefault();
        }
        public Racer GetRacer(string name) 
        {
            return Data.FirstOrDefault(x => x.Name == name);
        }
        public Racer GetFastestRacer() 
        {
            return Data.OrderByDescending(x => x.Car.Speed).FirstOrDefault();
        }
        public string Report() 
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Racers participating at {Name}:");
            foreach (var racer in Data)
            {
                sb.AppendLine(racer.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}

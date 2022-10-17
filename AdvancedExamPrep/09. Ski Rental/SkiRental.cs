using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SkiRental
{
    public class SkiRental
    {
        private List<Ski> data;

        public List<Ski> Data
        {
            get { return data; }
            set { data = value; }
        }

        public SkiRental(string name, int capacity)
        {
            this.data = new List<Ski>();
            Name = name;
            Capacity = capacity;
        }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.data.Count;

        public void Add(Ski ski) 
        {
            if (this.data.Count < Capacity)
            {
                this.data.Add(ski);
            }
        }
        public bool Remove(string manufacturer, string model) 
        {
            var skiToRemove = data.FirstOrDefault(x => x.Manufacturer == manufacturer
            && x.Model == model);
            if (skiToRemove != null)
            {
                this.data.Remove(skiToRemove);
                return true;
            }
            else return false;

        }
        public Ski GetNewestSki() 
        {
            return this.data.OrderByDescending(x => x.Year).FirstOrDefault();
        }
        public Ski GetSki(string manufacturer, string model) 
        {
            return this.data.FirstOrDefault(x => x.Manufacturer == manufacturer
            && x.Model == model);
        }
        public string GetStatistics() 
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The skis stored in {Name}:");
            foreach (var ski in this.data)
            {
                sb.AppendLine(ski.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerArchitecture
{
    public class Computer
    {
        public Computer(string model, int capacity)
        {
            Model = model;
            Capacity = capacity;
            Multiprocessor = new List<CPU>();
        }

        public string Model { get; set; }
        public int Capacity { get; set; }
        public List<CPU> Multiprocessor { get; set; }
        public int Count => Multiprocessor.Count;

        public void Add(CPU cpu) 
        {
            if (Capacity > Count)
            {
                Multiprocessor.Add(cpu);
            }
        }
        public bool Remove(string brand) 
        {
            var cpuToremove = Multiprocessor.FirstOrDefault(x => x.Brand == brand);
            if (cpuToremove == null)
            {
                return false;
            }
            else
            {
                Multiprocessor.Remove(cpuToremove);
                return true;
            }
            
        }
        public CPU MostPowerful() 
        {
            return Multiprocessor.OrderByDescending(x => x.Frequency).FirstOrDefault();
        }
        public CPU GetCPU(string brand) 
        {
            return Multiprocessor.FirstOrDefault(x => x.Brand == brand);
        }
        public string Report() 
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"CPUs in the Computer {Model}:");
            foreach (var cpu in Multiprocessor)
            {
                sb.AppendLine(cpu.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Renovators
{
    public class Catalog
    {
        public List<Renovator> Renovators { get; set; }
        public string Name { get; set; }
        public int NeededRenovators { get; set; }
        public string Project { get; set; }
        public int Count => this.Renovators.Count;
        public Catalog(string name, int neededRenovators, string project)
        {
            Renovators = new List<Renovator>();
            Name = name;
            NeededRenovators = neededRenovators;
            Project = project;
        }
        public string AddRenovator(Renovator renovator)
        {


            if (string.IsNullOrEmpty(renovator.Name) || string.IsNullOrEmpty(renovator.Type))
            {
                return "Invalid renovator's information.";
            }

            if (this.Count >= this.NeededRenovators)
            {
                return "Renovators are no more needed.";
            }

            if (renovator.Rate > 350)
            {
                return "Invalid renovator's rate.";
            }

            this.Renovators.Add(renovator);
            return $"Successfully added {renovator.Name} to the catalog.";
        }
        public bool RemoveRenovator(string name) 
        {
            var renovatorWeLookFor = this.Renovators.FirstOrDefault(x => x.Name == name);
            if (this.Renovators.Any(x => x.Name == name))
            {
                this.Renovators.Remove(renovatorWeLookFor);
                return true;
            }
            else return false;
        }
        public int RemoveRenovatorBySpecialty(string type) 
        {
            var renovatorsToRemove = this.Renovators.FindAll(x => x.Type == type);
            if (renovatorsToRemove.Count == 0 )
            {
                return 0;
            }
            else
            {
                foreach (var renovator in renovatorsToRemove)
                {
                    this.Renovators.Remove(renovator);
                }
                return renovatorsToRemove.Count;
            }
        }
        public Renovator HireRenovator(string name) 
        {
            var renovatorToHire = this.Renovators.FirstOrDefault(x => x.Name == name);
            if (renovatorToHire != default(Renovator))
            {
                renovatorToHire.Hired = true;
                return renovatorToHire;
            }
            return default(Renovator);
        }
        public List<Renovator> PayRenovators(int days) 
        {
            var renovatorsWorkingForDays = this.Renovators.FindAll(x => x.Days >= days);
            return renovatorsWorkingForDays;
        }
        public string Report() 
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Renovators available for Project {this.Project}:");

            var notHireRenovators = this.Renovators.FindAll(x => x.Hired == false);
            foreach (var renovator in notHireRenovators)
            {
                sb.AppendLine(renovator.ToString());
            }
            return sb.ToString().Trim();
        }
    }
}

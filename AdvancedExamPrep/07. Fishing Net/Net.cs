using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FishingNet
{
    public class Net
    {
        private List<Fish> fish;

        public List<Fish> Fish
        {
            get { return fish; }
            set { fish = value; }
        }


        private string material;

        public string Material
        {
            get { return material; }
            set { material = value; }
        }
        private int capacity;

        public int Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }
        public Net(string material, int capacity)
        {
            this.fish = new List<Fish>();
            this.material = material;
            this.capacity = capacity;
        }
        public int Count => this.fish.Count;

        public string AddFish(Fish fish)
        {
            if (string.IsNullOrWhiteSpace(fish.FishType) || fish.Length <= 0 || fish.Weight <= 0)
            {
                return "Invalid fish.";
            }
            else if (this.capacity == this.Count)
            {
                return "Fishing net is full.";
            }
            else
            {
                this.fish.Add(fish);
                return $"Successfully added {fish.FishType} to the fishing net.";
            }
        }
        public bool ReleaseFish(double weight) 
        {
            var fishToremove = this.fish.FirstOrDefault(x => x.Weight == weight);
            if (fishToremove == null) 
            {
                return false;
            }
            else
            {
                this.fish.Remove(fishToremove);
                return true;
            }

        }
        public Fish GetFish(string fishType) 
        {
            var fishToSearch = this.fish.FirstOrDefault(x => x.FishType == fishType);
            if (fishToSearch != null)
            {
                return fishToSearch;
            }
            else
            {
                return default(Fish);
            }
        }
        public Fish GetBiggestFish() 
        {
            return this.fish.OrderByDescending(x => x.Length).FirstOrDefault();
        }
        public string Report() 
        {
            var orderedFish = this.fish.OrderByDescending(x => x.Length);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Into the {this.material}:");
            foreach (Fish fish in orderedFish)
            {
                sb.AppendLine(fish.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}

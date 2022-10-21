using System.Collections.Generic;
using System.Linq;

namespace Zoo
{
    public class Zoo
    {
        private List<Animal> animals;

        public Zoo(string name, int capacity)
        {
            this.animals = new List<Animal>();
            Name = name;
            Capacity = capacity;
        }

        public List<Animal> Animals
        {
            get { return animals; }
            set { animals = value; }
        }
        public string Name { get; set; }
        public int Capacity { get; set; }

        public string AddAnimal(Animal animal) 
        {
            if (string.IsNullOrWhiteSpace(animal.Species))
            {
                return "Invalid animal species.";
            }
            else if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }
            else if (this.animals.Count >= Capacity)
            {
                return "The zoo is full.";
            }
            this.animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }
        public int RemoveAnimals(string species) 
        {
            var animalsToRem = this.animals.FindAll(x => x.Species == species);
            if (animalsToRem.Count > 0)
            {
                this.animals.RemoveAll(x => x.Species == species);
            }
            return animalsToRem.Count;
        }
        public List<Animal> GetAnimalsByDiet(string diet) 
        {
            var animalsToRet = this.animals.FindAll(x => x.Diet == diet);
            return animalsToRet;
        }
        public Animal GetAnimalByWeight(double weight) 
        {
            return this.animals.FirstOrDefault(x => x.Weight == weight);
        }
        public string GetAnimalCountByLength(double minimumLength, double maximumLength) 
        {
            var animals = this.animals.FindAll(x => x.Length >= minimumLength && x.Length <= maximumLength);
            return $"There are {animals.Count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}

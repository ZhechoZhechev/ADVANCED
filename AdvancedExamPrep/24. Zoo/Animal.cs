namespace Zoo
{
    public class Animal
    {
        private string species;

        public string Species
        {
            get { return species; }
            set { species = value; }
        }
        private string diet;

        public string Diet
        {
            get { return diet; }
            set { diet = value; }
        }
        private double weight;

        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        private double lenght;

        public double Length
        {
            get { return lenght; }
            set { lenght = value; }
        }
        public Animal(string species, string diet, double weight, double lenght )
        {
            Species = species;
            Diet = diet;
            Weight = weight;
            Length = lenght;
        }
        public override string ToString()
        {
            return $"The {Species} is a {Diet} and weighs {Weight} kg.";
        }

    }
}

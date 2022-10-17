namespace FishingNet
{
    public class Fish
    {
        private string fishType;

        public string FishType
        {
            get { return fishType; }
            set { fishType = value; }
        }
        private double length;

        public double Length
        {
            get { return length; }
            set { length = value; }
        }
        private double weight;
        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        public Fish(string fishType, double length, double weight)
        {
            this.fishType = fishType;
            this.length = length;
            this.weight = weight;
        }
        public override string ToString()
        {
            return $"There is a {this.fishType}, {this.length} cm. long, and {this.weight} gr. in weight.";
        }
    }
}

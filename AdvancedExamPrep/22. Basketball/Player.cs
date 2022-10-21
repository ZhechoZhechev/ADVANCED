using System;
using System.Text;

namespace Basketball
{
    public class Player
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public double Rating { get; set; }
        public int Games { get; set; }
        public bool Retired { get; set; }
        public Player()
        {
            Retired = false;
        }
        public Player(string name, string possition, double rating, int games) : this()
        {
            Name = name;
            Position = possition;
            Rating = rating;
            Games = games;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"-Player: {Name}");
            sb.AppendLine($"--Position: {Position}");
            sb.AppendLine($"--Rating: {Rating}");
            sb.AppendLine($"--Games played: {Games}");
            return sb.ToString().TrimEnd(); 
        }
    }
}

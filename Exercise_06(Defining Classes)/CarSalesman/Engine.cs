using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    class Engine
    {
        public Engine(string model, int power)
        {
            Model = model;
            Power = power;
        }
        public Engine(string model, int power, int displacement) : this(model, power)
        {
            Displacement = displacement;
        }
        public Engine(string model, int power, string efficiency) : this(model, power)
        {
            Efficiency = efficiency;
        }
        public Engine(string model, int power, int displacement, string efficiency) : this(model, power)
        {
            Displacement = displacement;
            Efficiency = efficiency;
        }

        public string Model { get; set; }
        public int Power { get; set; }
        public int Displacement { get; set; }
        public string Efficiency { get; set; }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string displacementText = this.Displacement == 0 ? "n/a" : this.Displacement.ToString();
            string efficiencyText = this.Efficiency == null ? "n/a" : this.Efficiency.ToString();

            sb.AppendLine($"  {this.Model}:");
            sb.AppendLine($"    Power: {this.Power}");
            sb.AppendLine($"    Displacement: {displacementText}");
            sb.AppendLine($"    Efficiency: {efficiencyText}");
            return sb.ToString();
        }
    }
}

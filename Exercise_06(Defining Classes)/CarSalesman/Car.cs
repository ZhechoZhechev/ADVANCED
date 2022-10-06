using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    class Car
    {
        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
        }

        public Car(string model, Engine engine, int weight)
            : this(model, engine)
        {
            this.Weight = weight;
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine)
        {
            this.Color = color;
        }

        public Car(string model, Engine engine, int weight, string color)
            : this(model, engine)
        {
            this.Weight = weight;
            this.Color = color;
        }
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            string weightText = this.Weight == 0 ? "n/a" : this.Weight.ToString();
            string colorText = this.Color == null ? "n/a" : this.Color.ToString();

            sb.AppendLine($"{this.Model}:");
            sb.Append(this.Engine.ToString());
            sb.AppendLine($"  Weight: {weightText}");
            sb.Append($"  Color: {colorText}");
            return sb.ToString();
        }
    }
}

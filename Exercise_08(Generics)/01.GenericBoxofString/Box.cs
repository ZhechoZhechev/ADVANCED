using System;
using System.Collections.Generic;
using System.Text;

namespace _01.GenericBoxofString
{
   public class Box<T>
    {
        public List<T> Storage { get; set; }

        public Box()
        {
            Storage = new List<T>();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in Storage)
            {
                sb.AppendLine($"{typeof(T)}: {item.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}

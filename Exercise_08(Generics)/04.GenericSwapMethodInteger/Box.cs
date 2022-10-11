using System;
using System.Collections.Generic;
using System.Text;

namespace _04.GenericSwapMethodInteger
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
        public void Swap(int index1, int index2) 
        {
            T temp = Storage[index1];
            Storage[index1] = Storage[index2];
            Storage[index2] = temp;
        }
    }
}

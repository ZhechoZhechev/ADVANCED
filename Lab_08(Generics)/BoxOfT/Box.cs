using System;
using System.Collections.Generic;
using System.Text;

namespace BoxOfT
{
    class Box<T>
    {
        public List<T> TheBox { get; set; }
        public int Count { get; private set; }

        public Box()
        {
            TheBox = new List<T>();
        }
        public void Add(T element) 
        {
            TheBox.Add(element);
            Count++;
        }
        public T Remove() 
        {
            T element = TheBox[TheBox.Count - 1];
            TheBox.RemoveAt(TheBox.Count - 1);
            Count--;
            return element;
        }
    }
}

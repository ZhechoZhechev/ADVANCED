using System;


namespace OurCustomList
{
    class CustomList
    {
        private const int capacity = 2;
        private int[] items;
        public int Count { get; private set; }

        public CustomList()
        {
            this.items = new int[capacity];
        }
        public int this[int index]
        {
            get
            {
                CheckIndex(index);
                return items[index];
            }
            set
            {
                CheckIndex(index);
                items[index] = value;
            }
        }
        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < this.Count; i++)
            {
                int currentItem = this.items[i];

                action(currentItem);
            }
        }
        public void Swap(int firstIndex, int secondIndex) 
        {
            int temp = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = temp;
        }
        public bool Contains(int element) 
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i] == element)
                {
                    return true;
                }
            }
            return false;
        }
        public int RemoveAt(int index)
        {
            CheckIndex(index);

            int numToRetun = this.items[index];
            this.items[index] = default(int);

            ShiftLelt(index);

            this.Count--;
            if (this.Count == this.items.Length / 4)
            {
                Shrink();
            }
            return numToRetun;
        }
        public void Add(int element)
        {
            if (this.Count == this.items.Length)
            {
                this.Resize();
            }
            this.items[Count] = element;
            this.Count++;
        }
        public void InsertAt(int index, int item)
        {
            CheckIndex(index);

            if (this.Count == this.items.Length)
            {
                this.Resize();
            }
            ShitRight(index);

            this.items[index] = item;
            this.Count++;
        }

        private void ShitRight(int index)
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                this.items[i + 1] = this.items[i];
            }
        }

        private int[] Resize()
        {
            int[] newArray = new int[items.Length * 2];
            for (int i = 0; i < items.Length; i++)
            {
                newArray[i] = this.items[i];
            }
            this.items = newArray;
            return this.items;
        }
        private void CheckIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        private void ShiftLelt(int index)
        {
            this.items[index] = default(int);
            for (int i = index; i < this.Count; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }
        private void Shrink()
        {
            int[] shrinkedArr = new int[this.items.Length / 2];
            for (int i = 0; i < this.Count; i++)
            {
                shrinkedArr[1] = this.items[i];
            }
            this.items = shrinkedArr;
        }
    }


}

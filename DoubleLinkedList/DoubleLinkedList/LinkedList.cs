using System;
using System.Collections.Generic;
using System.Text;

namespace DoubleLinkedList
{
    public class LinkedList
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public int Count { get; private set; }

        public void AddFirst(int element)
        {
            Node ElToAdd = new Node(element);
            if (Count == 0)
            {
                Head = Tail = ElToAdd;
            }
            else
            {
                Node previousHead = Head;
                Head = ElToAdd;
                previousHead.Previous = Head;
                Head.Next = previousHead;
            }
            this.Count++;
        }
        public void AddLast(int element)
        {
            Node ElToAdd = new Node(element);
            if (Count == 0)
            {
                Head = Tail = ElToAdd;
            }
            else
            {
                Node previousTail = Tail;
                Tail = ElToAdd;
                previousTail.Next = Tail;
                Tail.Previous = previousTail;
            }
            this.Count++;
        }
        public int RemoveFirst() 
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            int curElement = this.Head.Value;
            this.Head = this.Head.Next;
            if (this.Head != null)
            {
                this.Head.Previous = null;
            }
            else
            {
                this.Tail = null;
            }
            return curElement;

        }
        public int RemoveLast() 
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }
            int curElement = this.Tail.Value;
            this.Tail = this.Tail.Previous;
            if (this.Tail != null)
            {
                this.Tail.Next = null;
            }
            else
            {
                this.Head = null;
            }
            return curElement;
        }
        public void ForEach(Action<int> action)
        {
            var curNode = this.Head;
            while (curNode != null) 
            {
                action(curNode.Value);
                curNode = curNode.Next;
            }
        }

        public int[] ToArray() 
        {
            int[] array = new int[this.Count];
            int counter = 0;
            var curNode = this.Head;
            while (curNode != null)
            {
                array[counter] = curNode.Value;
                curNode = curNode.Next;
                counter++;
            }
            return array;
        }
    }
}

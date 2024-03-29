﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        //public class LibraryIterator : IEnumerator<Book>
        //{
        //    public List<Book> Books { get; set; }

        //    public int currentIndex { get; set; }

        //    public Book Current => this.Books[currentIndex];

        //    object IEnumerator.Current => this.Current;

        //    public LibraryIterator(IEnumerable<Book> books)
        //    {
        //        this.Reset();
        //        this.Books = new List<Book>(books);
        //    }

        //    public void Dispose() { }

        //    public bool MoveNext()
        //    {
        //        return ++this.currentIndex < this.Books.Count();
        //    }

        //    public void Reset()
        //    {
        //        this.currentIndex = -1;
        //    }
        //}

        public List<Book> Books { get; set; }

        public Library(params Book[] books)
        {
            this.Books = new List<Book>(books);
            this.Books.Sort();
        }

        public IEnumerator<Book> GetEnumerator()
        {
            for (int i = 0; i < this.Books.Count; i++)
            {
                yield return this.Books[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}

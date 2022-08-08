using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> elements;
        private int currentIndex;

        public ListyIterator(params T[] data)
        {
            this.elements = new List<T>(data);
            int index = 0;
        }

        public bool HasNext() => currentIndex < elements.Count - 1;

        public bool Move()
        {
            bool canMove = HasNext();

            if (canMove)
            {
                currentIndex++;
            }

            return canMove;
        }

        public void Print()
        {
            CheckCollectionIfEmpty();
            Console.WriteLine(elements[currentIndex]);
        }

        public void PrintAll()
        {
            CheckCollectionIfEmpty();
            Console.WriteLine(string.Join(" ", elements));
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T element in elements)
            {
                yield return element;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private void CheckCollectionIfEmpty()
        {
            if (elements.Count == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }
        }
    }
}

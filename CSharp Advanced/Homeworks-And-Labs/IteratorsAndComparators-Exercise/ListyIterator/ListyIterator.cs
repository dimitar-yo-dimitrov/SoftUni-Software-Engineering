using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T>
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

        public void Ptint()
        {
            if (elements.Count == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }

            Console.WriteLine(elements[currentIndex]);
        }
    }
}

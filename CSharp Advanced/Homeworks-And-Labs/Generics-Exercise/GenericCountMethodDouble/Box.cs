using System;
using System.Collections.Generic;
using System.Text;

namespace GenericCountMethodDouble
{
    public class Box<T>
        where T : IComparable
    {
        private readonly List<T> elements;

        public Box()
        {
            this.elements = new List<T>();
        }

        public void Add(T element)
        {
            elements.Add(element);
        }

        public int CountGreaterThanTheValue(T element)
        {
            IsEmpty();

            int counter = 0;

            foreach (var item in elements)
            {
                if (item.CompareTo(element) > 0)
                {
                    counter++;
                }
            }

            return counter;
        }

        private void IsEmpty()
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException("List is empty!");
            }
        }
    }
}

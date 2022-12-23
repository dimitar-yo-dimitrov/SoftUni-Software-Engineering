using System;
using System.Collections.Generic;
using System.Text;

namespace GenericSwapMethodInteger
{
    public class Box<T>
    {
        private readonly List<T> items;

        public Box()
        {
            items = new List<T>();
        }

        public void Add(T item)
        {
            items.Add(item);
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            IsEmpty();
            IsRange(firstIndex, secondIndex);

            T temp = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = temp;
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (var item in items)
            {
                result.AppendLine($"{item.GetType()}: {item}");
            }

            return result.ToString().TrimEnd();
        }

        private void IsEmpty()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("List is empty!");
            }
        }

        private void IsRange(int firstIndex, int secondIndex)
        {
            if (firstIndex < 0 || firstIndex >= items.Count ||
                secondIndex < 0 || secondIndex >= items.Count)
            {
                throw new IndexOutOfRangeException();
            }
        }
    }
}

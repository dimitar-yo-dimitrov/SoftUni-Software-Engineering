using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Stack
{
    public class Stack<T> : IEnumerable<T>
    {
        private List<T> collection;

        public Stack(params T[] data)
        {
            this.collection = new List<T>(data);
        }

        public void Push(params T[] elements)
        {
            foreach (T element in elements)
            {
                collection.Insert(collection.Count, element);
            }
        }

        public void Pop()
        {
            collection.RemoveAt(collection.Count - 1);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = collection.Count - 1; i >= 0; i--)
            {
                yield return collection[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

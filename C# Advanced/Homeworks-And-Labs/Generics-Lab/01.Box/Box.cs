using System.Collections.Generic;

namespace BoxOfT
{
    public class Box<T>
    {
        private readonly Stack<T> box;

        public Box()
        {
            box = new Stack<T>();
        }

        // adds an element on the top of the list.
        public void Add(T element)
        {
            box.Push(element);
        }

        // removes the topmost element.
        public T Remove() => box.Pop();

        //	int Count { get; }
        public int Count => box.Count;
    }
}

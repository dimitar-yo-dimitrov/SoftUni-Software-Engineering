using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDataStructures
{
    public class CustomStack
    {
        private const int defultCapacity = 4;
        private int[] elements;

        public CustomStack()
        {
            this.elements = new int[defultCapacity];
            this.Count = 0;
        }

        public int Count { get; private set; }

        // Adds the given element to the stack
        public void Push(int element)
        {
            if (elements.Length == Count)
            {
                Resize();
            }

            elements[Count++] = element;
        }

        // Removes the last added element
        public int Pop()
        {
            CheckStackCount();

            Count--;

            var lastElement = elements[Count];
            elements[Count] = default;

            return lastElement;
        }

        // Returns the last element in the stack without removing it
        public int Peek()
        {
            CheckStackCount();

            var lastElement = elements[Count - 1];

            return lastElement;
        }

        // Goes through each of the elements in the stack
        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(elements[i]);
            }
        }

        private void Resize() => Resize(elements.Length * 4);

        private void Resize(int newSize)
        {
            int[] newValues = new int[newSize];

            for (int i = 0; i < elements.Length; i++)
            {
                newValues[i] = elements[i];
            }

            elements = newValues;
        }

        private void CheckStackCount()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("Stack is empty!");
            }
        }
    }
}

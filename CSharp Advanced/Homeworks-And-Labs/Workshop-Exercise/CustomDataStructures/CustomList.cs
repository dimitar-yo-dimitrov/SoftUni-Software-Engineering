using System;
using System.Collections.Generic;
using System.Text;

namespace CustomDataStructures
{
    public class CustomList
    {
        private const int defultCapacity = 2;
        private int[] elements;

        public CustomList()
        {
            this.elements = new int[defultCapacity];
            Count = 0;
        }

        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                CheckIndexOutOfRange(index);
                return elements[index];
            }
            set
            {
                CheckIndexOutOfRange(index);
                elements[index] = value;
            }
        }

        //	 Adds the given element to the end of the list
        public void Add(int element)
        {
            if (elements.Length == Count)
            {
                Resize();
            }

            elements[Count++] = element;
        }

        //	 Removes the element at the given index
        public void RemoveAt(int index)
        {
            CheckIndexOutOfRange(index);
            ShiftToLeft(index);
            Shrink();

            Count--;
        }

        // Implement void Insert(int Index, Int Item) Method
        public void Insert(int index, int element)
        {
            CheckIndexOutOfRange(index);
            ShiftToRight(index);

            elements[index] = element;
            Count++;
        }

        // Checks if the list contains the given element returns(True or False)
        public bool Contains(int element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (elements[i] == element)
                {
                    return true;
                }
            }

            return false;
        }

        // Swaps the elements at the given indexes
        public void Swap(int firstIndex, int secondIndex)
        {
            CheckIndexOutOfRange(firstIndex);
            CheckIndexOutOfRange(secondIndex);

            int temp = elements[firstIndex];
            elements[firstIndex] = elements[secondIndex];
            elements[secondIndex] = temp;
        }

        // Goes through each of the elements in the stack
        public void ForEach(Action<int> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(elements[i]);
            }
        }

        public void Shrink()
        {
            if (elements.Length / 4 > Count)
            {
                int[] newValues = new int[elements.Length / 2];

                for (int i = 0; i < Count; i++)
                {
                    newValues[i] = elements[i];
                }

                elements = newValues;
            }
        }

        private void ShiftToLeft(int index)
        {
            if (index < Count - 1)
            {
                for (int i = index; i < Count - 1; i++)
                {
                    elements[i] = elements[i + 1];
                }
            }

            elements[index] = default;
        }

        private void ShiftToRight(int index)
        {
            if (elements.Length == Count)
            {
                Resize();
            }

            for (int i = Count - 1; i >= index; i--)
            {
                elements[i + 1] = elements[i];
            }

            elements[index] = default;
        }

        private void Resize() => Resize(elements.Length * 2);

        private void Resize(int newSize)
        {
            int[] newValues = new int[newSize];

            for (int i = 0; i < elements.Length; i++)
            {
                newValues[i] = elements[i];
            }

            elements = newValues;
        }

        private void CheckIndexOutOfRange(int index)
        {
            if (index < 0 || index > Count - 1)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}

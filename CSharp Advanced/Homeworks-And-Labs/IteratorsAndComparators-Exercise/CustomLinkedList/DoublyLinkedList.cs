﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        public class ListNode
        {
            public ListNode(T value)
            {
                Value = value;
            }

            public ListNode PreviousElement { get; set; }
            public ListNode NextElement { get; set; }
            public T Value { get; set; }
        }

        private ListNode firstElement;
        private ListNode lastElement;

        // Read-only property (get only)
        public int Count { get; private set; }

        // adds an element at the beginning of the collection
        public void AddFirst(T element)
        {
            if (Count == 0)
            {
                firstElement = lastElement = new ListNode(element);
            }
            else
            {
                ListNode newElement = new ListNode(element);
                
                newElement.NextElement = firstElement;
                firstElement.PreviousElement = newElement;
                firstElement = newElement;
            }

            Count++;
        }

        // adds an element at the end of the collection
        public void AddLast(T element)
        {
            if (Count == 0)
            {
                firstElement = lastElement = new ListNode(element);
            }
            else
            {
                ListNode newElement = new ListNode(element);

                lastElement.NextElement = newElement;
                newElement.PreviousElement = lastElement;
                lastElement = newElement;
            }

            Count++;
        }

        // removes the element at the beginning of the collection
        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            T currentFirstValue = firstElement.Value;
            firstElement = firstElement.NextElement;
            
            if (lastElement != null)
            {
                lastElement.NextElement = null;
            }
            else
            {
                firstElement = null;
            }

            Count--;
            return currentFirstValue;
        }

        // removes the element at the end of the collection
        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            T currentLastValue = lastElement.Value;
            lastElement = lastElement.PreviousElement;
            
            if (lastElement != null)
            {
                lastElement.NextElement = null;
            }
            else // more than 1 item
            {
                firstElement = null;
            }

            Count--;
            return currentLastValue;
        }

        // goes through the collection and executes a given action
        public void ForEach(Action<T> action)
        {
            var currentElement = firstElement;

            while (currentElement != null)
            {
                action(currentElement.Value);
                currentElement = currentElement.NextElement;
            }
        }

        // returns the collection as an array
        public T[] ToArray()
        {
            T[] array = new T[Count];

            ListNode current = firstElement;

            int index = 0;

            while (current != null)
            {
                array[index++] = current.Value;
                current = current.NextElement;
            }

            return array;
        }

        public IEnumerator<T> GetEnumerator()
        {
            ListNode currentNode = this.firstElement;

            while (currentNode != null)
            {
                yield return currentNode.Value;

                currentNode = currentNode.NextElement;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

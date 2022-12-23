using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty() => Count == 0;

        public void AddRange(params string[] elements)
        {
            foreach (var element in elements)
            {
                Push(element);
            }
        }
    }
}

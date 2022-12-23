using System;
using System.Collections.Generic;

namespace _08.BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> openParentheses = new Stack<char>();

            bool isBalanced = true;

            foreach (var symbol in input)
            {
                if (symbol == '(' || symbol == '{' || symbol == '[')
                {
                    openParentheses.Push(symbol);
                }

                else
                {
                    if (openParentheses.Count == 0)
                    {
                        isBalanced = false;
                        break;
                    }

                    bool IsValid = (symbol == ')' && openParentheses.Peek() == '(')
                                   || (symbol == '}' && openParentheses.Peek() == '{')
                                   || (symbol == ']' && openParentheses.Peek() == '[');

                    if (IsValid)
                    {
                        openParentheses.Pop();
                    }

                    else
                    {
                        isBalanced = false;
                        break;
                    }
                }
            }

            if (isBalanced)
            {
                Console.WriteLine("YES");
            }

            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}

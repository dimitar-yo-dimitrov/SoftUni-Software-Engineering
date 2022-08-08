using System;
using System.Collections.Generic;
using System.Text;

namespace IteratorsAndComparators
{
    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book first, Book second)
        {
            int result = first.Title.CompareTo(second.Title);

            if (result == 0)
            {
                return second.Year.CompareTo(first.Year);
            }

            return result;
        }
    }
}

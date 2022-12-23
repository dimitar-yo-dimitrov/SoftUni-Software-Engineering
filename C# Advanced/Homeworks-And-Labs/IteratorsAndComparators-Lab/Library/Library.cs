using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators
{
    public class Library : IEnumerable<Book>
    {
        private SortedSet<Book> books;

        public Library(params Book[] books)
        {
            this.books = new SortedSet<Book>(books);
        }

        public void Add(Book book) => books.Add(book);

        public void Remove(Book book) => books.Remove(book);

        public IEnumerator<Book> GetEnumerator() => new LibraryIterator(books);

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class LibraryIterator : IEnumerator<Book>
        {
            private List<Book> books;
            private int index;

            public LibraryIterator(List<Book> books)
            {
                this.books = books;
                this.index = -1;
            }

            public Book Current => books[index];

            object IEnumerator.Current => Current;

            public bool MoveNext()
            {
                index++;
                return index < books.Count;
            }

            public void Reset() => index = -1;

            public void Dispose()
            {
            }
        }
    }
}
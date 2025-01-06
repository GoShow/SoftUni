using System.Collections;
using System.Collections.Generic;

namespace IteratorsAndComparators;

public class Library : IEnumerable<Book>
{
    private List<Book> books;

    public Library(params Book[] books)
    {
        this.books = new List<Book>(books);
    }

    public IEnumerator<Book> GetEnumerator()
    {
        books.Sort(new BookComparator());

        return new LibraryIterator(books);
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    private class LibraryIterator : IEnumerator<Book>
    {
        private int index = -1;
        private readonly List<Book> books;

        public LibraryIterator(IEnumerable<Book> books)
        {
            this.books = new List<Book>(books);
        }
        public Book Current => books[index];

        object IEnumerator.Current => Current;

        public bool MoveNext()
        {
            index++;

            return index < books.Count;
        }

        public void Dispose()
        {
        }

        public void Reset()
        {
            index = -1;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorsAndComparators
{
    public class Library: IEnumerable<Book>
    {
        private List<Book> books;

        public Library(params Book[] books)
        {
            this.books = new List<Book>(books);
        }

        public IEnumerator<Book> GetEnumerator()
        {
            return new LibraryIterator(books);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        private class LibraryIterator: IEnumerator<Book> 
        {
            private List<Book> books;
            private int currentIndex = -1;
            public Book currentBook => books[currentIndex];
            public LibraryIterator(List<Book> books)
            {
                this.books = books;
            }

            public Book Current => Current;

            object IEnumerator.Current => throw new NotImplementedException();

            public void Dispose()
            {
                
            }

            public bool MoveNext()
            {
                return ++currentIndex<books.Count;
            }

            public void Reset()
            {
                currentIndex = -1;
            }
        }
    }
}

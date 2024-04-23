using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class ReadingList
    {
        private Book[] books;
        public int Capacity { get; }
        public int Count { get; private set; }

        public ReadingList(int capacity)
        {
            Capacity = capacity;
            books = new Book[capacity];
            Count = 0;
        }

        public void AddBook(Book book)
        {
            if (Count < Capacity)
            {
                books[Count++] = book;
            }
            else
            {
                Console.WriteLine("The reading list is full. Cannot add more books.");
            }
        }

        public void RemoveBook(Book book)
        {
            int index = Array.IndexOf(books, book);
            if (index != -1)
            {
                for (int i = index; i < Count - 1; i++)
                {
                    books[i] = books[i + 1];
                }
                Count--;
            }
            else
            {
                Console.WriteLine("Book not found in the reading list.");
            }
        }

        public bool ContainsBook(Book book)
        {
            return Array.IndexOf(books, book) != -1;
        }

        public Book this[int index]
        {
            get
            {
                if (index >= 0 && index < Count)
                {
                    return books[index];
                }
                else
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }
            }
            set
            {
                if (index >= 0 && index < Count)
                {
                    books[index] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }
            }
        }

        public override string ToString()
        {
            if (Count == 0)
            {
                return "The reading list is empty.";
            }

            string result = "Reading List:\n";
            for (int i = 0; i < Count; i++)
            {
                result += $"{books[i]}\n";
            }
            return result;
        }
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework__shop__magazine_and_booklist;
namespace BookList
{
    internal class BookList: IEnumerable<Book>
    {
        private List<Book> books { get; set; }
        public BookList()
        {
            books = new List<Book>();
        }

        public List<Book> Books
        {
            //get { return new List<Book>(books); }
            get { return [.. books]; }//посоветовала студия
        }
        public void AddBook(Book book)
        {
            books.Add(book);
        }
        public void RemoveBook(Book book)
        {
            books.Remove(book);
        }
        public bool ContainsBook(Book book)
        {
            return books.Contains(book);
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            int count = 0;
            foreach (var book in books)
            {
                count++;
                sb.AppendLine($"Book {count}: Title: {book.Title}, Author: {book.Author}, Year: {book.Year}, Description: {book.Description}");
            }
            return sb.ToString();
        }

        public IEnumerator<Book> GetEnumerator()
        {
            for (int i = 0; i < books.Count; i++)
            {
                yield return books[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /*Задание 3
       Создайте приложение «Список книг для прочтения».
       Приложение должно позволять добавлять книги в список, удалять книги из списка, проверять есть ли книга в
       списке, и т. д. Используйте механизм свойств, перегрузки
       операторов, индексаторов. */

        public Book this[int index]
        {
            get
            {
                if (index < 0 || index >= books.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
                }
                return books[index];
            }
            set
            {
                if (index < 0 || index >= books.Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(index), "Index is out of range.");
                }
                books[index] = value;
            }
        }
    }
}

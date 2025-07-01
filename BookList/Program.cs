using Homework__shop__magazine_and_booklist;
using System;
namespace BookList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookList bookList = new BookList();
            bookList.AddBook(new Book("Balad of Sarah Berry"));
            bookList.AddBook(new Book("1984", "George Orwell", "Dystopian novel", 1949));
            bookList.AddBook(new Book("To Kill a Mockingbird", "Harper Lee", "Novel about racial injustice",1960));
            bookList.AddBook(new Book("The Great Gatsby", "F. Scott Fitzgerald", "Novel about the American dream", 1925));

            Book book = new Book("The Great Gatsby", "F. Scott Fitzgerald", "Novel about the American dream", 1925);
            //foreach (var book in bookList)
            //{
            //    Console.WriteLine(book);
            //}
            Console.WriteLine(bookList);
            bookList.RemoveBook(1);
            Console.WriteLine("Убрала первую книгу: ");
            Console.WriteLine(bookList);
            Console.WriteLine($"Содержит ли список книг \"{book.Title}\"? {(bookList.ContainsBook(book) ? "Да" : "Нет")}");
            bookList.RemoveBook(book);
            Console.WriteLine("Убрала книгу по объекту книги: ");
            Console.WriteLine(bookList);

        }
    }
}

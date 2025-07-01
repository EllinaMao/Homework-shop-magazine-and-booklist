using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework__shop__magazine_and_booklist
{/*Задание 3
Создайте приложение «Список книг для прочтения».
Приложение должно позволять добавлять книги в список, удалять книги из списка, проверять есть ли книга в
списке, и т. д. Используйте механизм свойств, перегрузки
операторов, индексаторов. */
    internal struct Book
    {   public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public Book()
        {
            Title = string.Empty;
            Description = string.Empty;
            Author = string.Empty;
            Year = 0;

        }
        public Book(string title, string description = "Unknown", string author = "Unknown", int year = 0)
        {
            Title = title;
            Description = description;
            Author = author;
            Year = year;
        }
        public override string ToString()
        {
            return $"Title: {Title}, Description: {Description},Author: {Author},  Year: {Year}\n";
        }


    }
}

using Task_5;

namespace Magazine_
{/*Задание 1
Ранее в одном из практических заданий вы создавали
класс «Журнал». Добавьте к уже созданному классу информацию о количестве сотрудников. Выполните перегрузку
+ (для увеличения количества сотрудников на указанную
величину), — (для уменьшения количества сотрудников
на указанную величину), == (проверка на равенство количества сотрудников), < и > (проверка на меньше или
больше количества сотрудников), != и Equals. Используйте
механизм свойств для полей класса.*/
    internal static class Program
    {
        static void Main(string[] args)
        {
            Magasine magazine = new Magasine("Tech Today", "mailadress@adress.ua", "A magazine about technology", +1234567890, new DateTime(2020, 1, 1), 50);
            Magasine magazine3 = new Magasine("Tech Today", "mailadress@adress.ua", "A magazine about technology", +1234567890, new DateTime(2020, 1, 1), 50);
            Magasine magazine4 = magazine;

            Console.WriteLine(magazine);
            Magasine magazine2 = magazine + 10; // Увеличение количества сотрудников на 10
            Console.WriteLine(magazine2);
            magazine2 = magazine2 - 5; // Уменьшение количества сотрудников на 5
            Console.WriteLine(magazine2);

            Console.WriteLine($"Сравнение сотрудников: {(magazine2 > magazine ? "Magazine2 has more employees" : "Magazine1 has more employees")}");
            Console.WriteLine($"Сравнение сотрудников: {(magazine2 < magazine ? "Magazine2 has fewer employees" : "Magazine1 has fewer employees")}");
            Console.WriteLine($"Сравнение сотрудников: {(magazine3 == magazine ? "Magazine3 employees equal Magazine1" : "Magazine3 employees not equal Magazine1")}");
            Console.WriteLine($"Сравнение сотрудников: {(magazine4 != magazine ? "Magazine4 employees not equal Magazine1" : "Magazine4 employees equal Magazine1")}");

            Console.WriteLine(magazine3.Equals(magazine));
        }
    }
}

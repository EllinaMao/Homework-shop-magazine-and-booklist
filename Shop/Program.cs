using System.Net.Mail;

namespace Task6
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            /*внутренний конструктор мейл адреса
            bool parseSuccess = TryParse(address, displayName, displayNameEncoding,
                        out (string displayName, string user, string host, Encoding displayNameEncoding) parsedData,
                        throwExceptionIfFail: true);
            что интерестно выкидывает исключение прямо в конструкторе и проверяет что адрес валиден и все значения вошли в внутренний конструктор который хранит в себе все данные
             */

            MailAddress email = new MailAddress("bratva@gmail.com","Antonio");
            Shop shop = new Shop("Лесная братва", email, "Мастера орешек", +380992927356, "Katareesna 12/34", 23.43);
            Shop shop3 = new Shop("Лесная братва", email, "Мастера орешек", +380992927356, "Katareesna 12/34", 23.43);
            Shop shop4 = shop;

            Console.WriteLine(shop);
            Shop shop2 = shop + 10.0; // Увеличение площади магазина на 10.0
            Console.WriteLine(shop2);
            shop2 = 5.0 - shop2 ; // Уменьшение площади магазина на 5.0
            Console.WriteLine(shop2);
            Console.WriteLine($"Сравнение площадей: {(shop2.Area > shop.Area ? "Shop2 bigger" : "Shop1 is bigger")}");
            Console.WriteLine($"Сравнение площадей: {(shop2.Area < shop.Area ? "Shop2 smaller" : "Shop1 is smaller")}");// Проверка на меньше

            Console.WriteLine($"Сравнение площадей: {(shop3 == shop ? "Shop2 area is equal to Shop1" : "Shop2 area is not equal to Shop1")}"); // Проверка на равенство
            Console.WriteLine($"Сравнение площадей: {(shop4 != shop ? "Shop2 area is not equal to Shop1" : "Shop2 area is equal to Shop1")}"); // Проверка на неравенство
            Console.WriteLine(shop3.Equals(shop));

        }
    }
}

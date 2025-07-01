using Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using Task4;
using static System.Formats.Asn1.AsnWriter;

namespace Task6
{
    /*Задание 6
Создайте класс «Магазин». Необходимо хранить в
полях класса: название магазина, адрес, описание профиля магазина, контактный телефон, контактный e-mail.
Реализуйте методы класса для ввода данных, вывода
данных, реализуйте доступ к отдельным полям через
методы класса

Задание 2
Ранее в одном из практических заданий вы создавали класс «Магазин». Добавьте к уже созданному классу
информацию о площади магазина. Выполните перегрузку + (для увеличения площади магазина на указанную
величину), — (для уменьшения площади магазина на
указанную величину), == (проверка на равенство площадей магазинов), < и > (проверка на меньше или больше
площади магазина), != и Equals. Используйте механизм
свойств для полей класса.

     */
    public class Shop : INameIO, IDescriptionIO, IPhoneIO, IDisplayInfo, IEmailIO
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        public long Phone { get; set; }
        public MailAddress Email { get; set; }
        public double Area { get; set; }

        public Shop()
        {
            Name = string.Empty;
            Email = new MailAddress("example@gmail.com");
            Description = string.Empty;
            Adress = string.Empty;
            Phone = 0;
            Area = 0.0;
        }
        public Shop(
            string name,
            string mailAddress = "example@gmail.com",
            string description = "Unknown",
            long phoneNumber = 0,
            string address = "Unknown",
            double area = 0.0)
        {
            Name = name;
            Email = new MailAddress(mailAddress); 
            Description = description;
            Phone = phoneNumber;
            Adress = address;
            Area = area;
        }
        public Shop(
            string name,
            MailAddress mailAddress,
            string description = "Unknown",
            long phoneNumber = 0,
            string address = "Unknown",
            double area = 0.0)
        {
            Name = name;
            Description = description;
            Email = mailAddress ?? new MailAddress("example@gmail.com");
            Phone = phoneNumber;
            Adress = address;
            Area = area;
        }
        public void InputName()
        {
            Console.Write("Введите название магазина: ");
            Name = Input.UserInput.GetStringFromUser();
        }
        public void InputDescription()
        {
            Console.Write("Введите описание профиля магазина: ");
            Description = Input.UserInput.GetStringFromUser();
        }
        public void InputEmail()
        {
            while (true)
            {
                try
                {
                    Console.Write("Введите контактный e-mail: ");
                    string emailInput = Input.UserInput.GetStringFromUser();
                    Email = new MailAddress(emailInput);
                    break;

                }
                catch
                {
                    Console.WriteLine("Некорректный e-mail. Пожалуйста, попробуйте еще раз.");
                }
            }

        }
        public void InputPhone()
        {
            while (true)
            {
                Console.Write("Введите контактный телефон: ");
                Phone = Input.UserInput.GetLongFromUser();
                if (Phone.ToString().Length == 11)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Некорректный номер телефона. Пожалуйста, введите 11 цифр.");
                }
            }
        }

        public void InputAdress()
        {
            Console.Write("Введите адресс магазина: ");
            Adress = UserInput.GetStringFromUser();
        }

        public void InputArea()
        {
            Console.Write("Введите площадь магазина: ");
            Area = Input.UserInput.GetDoubleFromUser();
        }
        public override string ToString()
        {
            string phoneFormatted = string.Format("{0:+# (###) ###-##-##}", Phone);
            return $"Название магазина: {Name}, Адрес: {Adress}, Описание профиля магазина: {Description}, Контактный телефон: {phoneFormatted}, Контактный e-mail: {Email}, Площадь магазина: {Area}\n";
        }
        public void DisplayInfo()
        {//полях класса:  название магазина, адрес, описание профиля магазина, контактный телефон, контактный e-mail
            string phoneFormatted = string.Format("{0:+# (###) ###-##-##}", Phone);
            Console.WriteLine($"Название магазина: {Name}" +
            $"\nAдрес: {Adress}" +
                $"\nОписание профиля магазина: {Description}" +
                $"\nКонтактный телефон:{phoneFormatted}" +
                $"\nКонтактный e-mail:{Email}" +
                $"\n Площадь магазина {Area}");
        }

        public static Shop operator +(Shop shop, double area)
        {
            try
            {
                if (area < 0)
                {
                    throw new ArgumentException("Площадь не может быть отрицательной.");
                }
                return new Shop
                {
                    Name = shop.Name,
                    Description = shop.Description,
                    Adress = shop.Adress,
                    Phone = shop.Phone,
                    Email = shop.Email,
                    Area = shop.Area + area
                };
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                return shop;
            }
        }
        public static Shop operator +(double area, Shop shop)
        { return shop + area; }
        public static Shop operator -(Shop shop, double area)
        {
            try
            {
                if (area < 0)
                {
                    throw new ArgumentException("Площадь не может быть отрицательной.");
                }
                return new Shop
                {
                    Name = shop.Name,
                    Description = shop.Description,
                    Adress = shop.Adress,
                    Phone = shop.Phone,
                    Email = shop.Email,
                    Area = shop.Area - area
                };
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                return shop;
            }
        }
        public static Shop operator -(double area, Shop shop)
        { return shop - area; }

        /*== (проверка на равенство площадей магазинов), < и > (проверка на меньше или больше
площади магазина), != и Equals. Используйте механизм
свойств для полей класса.
*/

        public static bool operator ==(Shop shop1, Shop shop2)
        {
            bool temp = Math.Abs(shop1.Area - shop2.Area) < 0.0001; // Используем небольшую погрешность для сравнения с плавающей точкой
            return temp;
        }

        public static bool operator !=(Shop shop1, Shop shop2)
        {
            return !(shop1 == shop2);
        }
        public static bool operator >(Shop shop1, Shop shop2)
        {
            return shop1.Area > shop2.Area;
        }
        public static bool operator <(Shop shop1, Shop shop2)
        {
            return shop1.Area < shop2.Area;
        }
        public override bool Equals(object? obj)
        {
            if (obj is Shop otherShop)
            {
                return
                    this.Name == otherShop.Name &&
                    this.Description == otherShop.Description &&
                    this.Adress == otherShop.Adress &&
                    this.Phone == otherShop.Phone &&
                    this.Email.Equals(otherShop.Email) &&
                    Math.Abs(this.Area - otherShop.Area) < 0.0001;
            }
            return false;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Description, Adress, Phone, Email, Area);

        }
    }
}



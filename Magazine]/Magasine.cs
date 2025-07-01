using Input;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Task4;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Task_5
{
    /*
Задание 5
Создайте класс «Журнал». Необходимо хранить в
полях класса: название журнала, год основания, описание журнала, контактный телефон, контактный e-mail.
Реализуйте методы класса для ввода данных, вывода
данных, реализуйте доступ к отдельным полям через
методы класса.

Ранее в одном из практических заданий вы создавали
класс «Журнал». Добавьте к уже созданному классу информацию о количестве сотрудников. Выполните перегрузку
+ (для увеличения количества сотрудников на указанную
величину), — (для уменьшения количества сотрудников
на указанную величину), == (проверка на равенство количества сотрудников), < и > (проверка на меньше или
больше количества сотрудников), != и Equals. Используйте
механизм свойств для полей класса.
     */
    public class Magasine : INameIO, IDescriptionIO, IPhoneIO, IDisplayInfo, IEmailIO
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public long Phone { get; set; }
        public MailAddress Email { get; set; }
        public DateTime YearOfCreation { get; set; }
        public int NumberOfEmployees { get; set; }
        public Magasine()
        {
            Name = string.Empty;
            Email = new MailAddress("example@gmail.com");
            Description = string.Empty;
            Phone = 0;
            YearOfCreation = DateTime.MinValue;
            NumberOfEmployees = 0;
        }
        public Magasine(string name, string mailadress = "example@gmail.com", string description = "Unknown", long phonenumber = 0, DateTime? yearOfCreation = null, int numberOfEmployees = 0)
        {
            Name = name;
            Email = new MailAddress(mailadress);
            Description = description;
            Phone = phonenumber;
            YearOfCreation = yearOfCreation ?? DateTime.MinValue;
            NumberOfEmployees = numberOfEmployees;
        }
        public Magasine(string name, MailAddress mailadress, string description = "Unknown", long phonenumber = 0, DateTime? yearOfCreation = null, int numberOfEmployees = 0)
        {
            Name = name;
            Email = mailadress;
            Description = description;
            Phone = phonenumber;
            YearOfCreation = yearOfCreation ?? DateTime.MinValue;
            NumberOfEmployees = numberOfEmployees;
        }
        public void InputName()
        {
            Console.Write("Введите название журнала: ");
            Name = Input.UserInput.GetStringFromUser();
        }
        public void InputDescription()
        {
            Console.Write("Введите описание журнала: ");
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
        public void InputNumberOfEmployees()
        {
            Console.Write("Введите количество сотрудников: ");
            NumberOfEmployees = Input.UserInput.GetIntFromUser();
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

        public void InputYearOfCreation()
        {
            Console.Write("Введите год основания журнала: ");
            YearOfCreation = UserInput.GetDateTimeFromUser("d.M.yyyy");
        }

        public override string ToString()
        {
            return $"Название журнала: {Name}, Год основания: {YearOfCreation.Year}, Описание: {Description}, Контактный телефон: {string.Format("{0:+# (###) ###-##-##}", Phone)}, Контактный e-mail: {Email}, Количество сотрудников:{NumberOfEmployees}\n";
        }
        public void DisplayInfo()
        {//полях класса: 1название журнала, 2год основания, 3описание журнала, 4контактный телефон, 5контактный e-mail.
            string phoneFormatted = string.Format("{0:+# (###) ###-##-##}", Phone);
            Console.WriteLine($"Название журнала: {Name}" +
            $"\nГод основания: {YearOfCreation}" +
                $"\nОписание журнала: {Description}" +
                $"\nКонтактный телефон:{phoneFormatted}" +
                $"\nКонтактный e-mail:{Email}" +
                $"\nКоличество сотрудников:{NumberOfEmployees}");
        }
        public static Magasine operator +(Magasine magasine, int numberOfEmployees)
        {
            return new Magasine
            {
                Name = magasine.Name,
                Description = magasine.Description,
                YearOfCreation = magasine.YearOfCreation,
                Phone = magasine.Phone,
                Email = magasine.Email,
                NumberOfEmployees = magasine.NumberOfEmployees + numberOfEmployees
            };
        }
        public static Magasine operator +(int numberOfEmployees, Magasine magasine)
        {
            return magasine + numberOfEmployees;
        }
        public static Magasine operator -(Magasine magasine, int numberOfEmployees)
        {
            return new Magasine
            {
                Name = magasine.Name,
                Description = magasine.Description,
                YearOfCreation = magasine.YearOfCreation,
                Phone = magasine.Phone,
                Email = magasine.Email,
                NumberOfEmployees = magasine.NumberOfEmployees - numberOfEmployees
            };
        }

        public static Magasine operator -(int numberOfEmployees, Magasine magasine)
        {
            return magasine - numberOfEmployees;
        }
        public static bool operator ==(Magasine magasine1, Magasine magasine2)
        {
            return magasine1.NumberOfEmployees == magasine2.NumberOfEmployees;
        }

        public static bool operator !=(Magasine magasine1, Magasine magasine2)
        {
            return !(magasine1 == magasine2);
        }

        /*Выполните перегрузку
+ (для увеличения количества сотрудников на указанную
величину), — (для уменьшения количества сотрудников
на указанную величину), == (проверка на равенство количества сотрудников), < и > (проверка на меньше или
больше количества сотрудников), != и Equals. Используйте
механизм свойств для полей класса.*/

        public override bool Equals(object? obj)
        {
            if (obj is Magasine other)
            {
                return Name == other.Name &&
                       Description == other.Description &&
                       Phone == other.Phone &&
                       Email.Address.Trim().ToLowerInvariant() == other.Email.Address.Trim().ToLowerInvariant() &&
                       YearOfCreation == other.YearOfCreation &&
                       NumberOfEmployees == other.NumberOfEmployees;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Description, Phone, Email, YearOfCreation, NumberOfEmployees);
        }

        public static bool operator >(Magasine magasine1, Magasine magasine2)
        {
            return magasine1.NumberOfEmployees > magasine2.NumberOfEmployees;
        }

        public static bool operator <(Magasine magasine1, Magasine magasine2)
        {
            return magasine1.NumberOfEmployees < magasine2.NumberOfEmployees;



        }
    }
}


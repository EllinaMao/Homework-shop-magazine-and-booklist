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
     */
    public class Magasine : INameIO, IDescriptionIO, IPhoneIO,IDisplayInfo, IEmailIO
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public long Phone { get; set; }
        public MailAddress Email { get; set; }
        public DateTime YearOfCreation { get; set; }

        public Magasine()
        {
            Name = string.Empty;
            Description = string.Empty;
            Email = new MailAddress("example@gmail.com");
            Phone = 0;
            YearOfCreation = DateTime.MinValue;
        }
        public Magasine(string name,  string description, string mailadress, long phonenumber, DateTime yearOfCreation)
        {
            Name = name;
            Description = description;
            Email = new MailAddress(mailadress);
            Phone = phonenumber;
            YearOfCreation = yearOfCreation;
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

        public void DisplayInfo()
        {//полях класса: 1название журнала, 2год основания, 3описание журнала, 4контактный телефон, 5контактный e-mail.
            string phoneFormatted = string.Format("{0:+# (###) ###-##-##}", Phone);
            Console.WriteLine($"Название журнала: {Name}" +
            $"\nГод основания: {YearOfCreation}" +
                $"\nОписание журнала: {Description}" +
                $"\nКонтактный телефон:{phoneFormatted}" +
                $"\nКонтактный e-mail:{Email}");
        }

    }

}


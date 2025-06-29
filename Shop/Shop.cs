using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Input;
using Task4;
using System.Net.Mail;

namespace Task6
{
    /*Задание 6
Создайте класс «Магазин». Необходимо хранить в
полях класса: название магазина, адрес, описание профиля магазина, контактный телефон, контактный e-mail.
Реализуйте методы класса для ввода данных, вывода
данных, реализуйте доступ к отдельным полям через
методы класса
     */
    public class Shop : INameIO, IDescriptionIO, IPhoneIO,IDisplayInfo, IEmailIO
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        public long Phone { get; set; }
        public MailAddress Email { get; set; }

        public Shop()
        {
            Name = string.Empty;
            Description = string.Empty;
            Adress = string.Empty;
            Email = new MailAddress("example@gmail.com");
            Phone = 0;
        }
        public Shop(string name,  string description, string mailadress, long phonenumber, string adress)
        {
            Name = name;
            Description = description;
            Email = new MailAddress(mailadress);
            Phone = phonenumber;
            Adress = adress;
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

        public void DisplayInfo()
        {//полях класса:  название магазина, адрес, описание профиля магазина, контактный телефон, контактный e-mail
            string phoneFormatted = string.Format("{0:+# (###) ###-##-##}", Phone);
            Console.WriteLine($"Название магазина: {Name}" +
            $"\nAдрес: {Adress}" +
                $"\nОписание профиля магазина: {Description}" +
                $"\nКонтактный телефон:{phoneFormatted}" +
                $"\nКонтактный e-mail:{Email}");
        }

    }

}


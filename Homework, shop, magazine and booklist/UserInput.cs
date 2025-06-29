using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Input
{
    public static class UserInput
    {
        public static int GetIntFromUser()
        {
            while (true)
            {
                try
                {
                    int number = Convert.ToInt32(Console.ReadLine());
                    //Console.Beep(); //^-^
                    return number;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine("Пожалуйста, введите корректное число:");
                }}}
        public static double GetDoubleFromUser()
        {
            while (true)
            {
                try
                {
                    double number = Convert.ToDouble(Console.ReadLine());
                    Console.Beep(); //^-^
                    return number;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine("Пожалуйста, введите корректное число:");
                }
            }
        }

        public static string GetStringFromUser()
        {
            while (true)
            {
                try
                {
                    string? input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        throw new ArgumentException("Ввод не может быть пустым или состоять только из пробелов.");
                    }
                    return input.Trim();
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine("Пожалуйста, введите корректную строку:");
                }
            }
        }

        public static DateTime GetDateTimeFromUser(string format = "d.M.yyyy")
        {
            while (true)
            {
                try
                {
                    Console.WriteLine($"Введите дату в формате {format}:");
                    string input = GetStringFromUser();
                    DateTime date = DateTime.ParseExact(input, format, System.Globalization.CultureInfo.CurrentCulture);
                    return date;
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Неверный формат даты. Пожалуйста, используйте формат {format}.");
                }
            }
        }

        public static long GetLongFromUser()
        {
            while (true)
            {
                try
                {
                    long number = Convert.ToInt64(Console.ReadLine());
                    //Console.Beep(); //^-^
                    return number;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                    Console.WriteLine("Пожалуйста, введите корректное число:");
                }
            }
        }








    }

}

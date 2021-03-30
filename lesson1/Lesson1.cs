using System;

namespace level1
{
    class Lesson1
    {
        static void Main(string[] args)
        {
            string name = null;

            Console.WriteLine("Введите свое имя:");
            name = Console.ReadLine();
            Console.WriteLine($"Здравствуйте, {name}. Текущее дата и время: {DateTime.Now}");

        }
    }
}

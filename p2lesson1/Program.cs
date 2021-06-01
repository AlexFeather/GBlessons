using System;

namespace p2lesson1
{
    class Program
    {


        static void Main(string[] args)
        {
            BlockSchemeMethod();
        }

        static int Input()
        {
            Console.WriteLine("Введите значение для n:");
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException("Введенное значение не является числом");
            }
        }

        static void BlockSchemeMethod()
        {
            int n;
            int d = 0;
            int i;

            n = Input();

            for (i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    d++;
                }
            }

            if (d == 0)
                Console.WriteLine("Простое");
            else
                Console.WriteLine("Не простое");

        }

    }
}

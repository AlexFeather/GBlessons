using System;
using System.Collections.Generic;

namespace lesson4
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.WriteLine(@"
            Введите номер задания, чтобы увидеть результат его решения:
            1. Случайное ФИО.
            2. Сумма чисел в строке.
            3. Определение времени года.
            4. Число Фибоначчи.
            5. Нормализация строки.");
        }
    }

    class Ex1Names
    {

        protected class Name
        {
            protected string firstName { get; private set; }
            protected string lastName { get; private set; }
            protected string patronymic { get; private set; }

            public Name(string last, string first, string patro)
            {
                firstName = first;
                lastName = last;
                patronymic = patro;
            }

            public void ViewName()
            {
                Console.WriteLine($"{lastName} {firstName} {patronymic}");
            }
        }

        static string[] names = { "Александр", "Михаил", "Станислав", "Орест", "Святослав", "Алексей", "Иван", "Юрий", "Андрей", "Артем" };
        static string[] patronymics = { "Александрович", "Михаилович", "Станиславович", "Орестович", "Святославович", "Алексеевич", "Иванович", "Юрьевич", "Андреевич", "Артемович" };
        static string[] lastNames = { "Романов", "Пушной", "Станиславский", "Стругацкий", "Кац", "Туполев", "Токарев", "Калашников", "Айзимов", "Зеленко" };

        public static void GetName()
        {
            Random rnd = new Random();
            Name name = new Name(lastNames[rnd.Next(0, lastNames.Length - 1)], names[rnd.Next(0, names.Length - 1)], patronymics[rnd.Next(0, patronymics.Length - 1)]);
            name.ViewName();
        }
    }

    class Ex2Sum
    {
        public static void Linebreaker()
        {
            Console.WriteLine("Введите числа через пробелы:");
            string line = Console.ReadLine();
            string[] splitLine = line.Split(' ');
            int result = 0;
            for (int i = 0; i < splitLine.Length; i++)
            {
                if (int.TryParse(splitLine[i], out int number))
                {
                    result += number;
                }
            }
            Console.WriteLine(result);
        }
    }

    //Условие показалось мне слишком уж простым, поэтому я хочу решить эту задачу, используя Dictionary, чтобы потренироваться
    class Ex3Seasons
    {
        static bool initialized = false;

        [Flags]
        enum Seasons
        {
            Зима = 0,
            Весна,
            Лето,
            Осень
        }

        enum Months
        {
            Январь = 1,
            Февраль,
            Март,
            Апрель,
            Май,
            Июнь,
            Июль,
            Август,
            Сентябрь,
            Октябрь,
            Ноябрь,
            Декабрь
        }

        static Dictionary<Months, Seasons> correspondance = new Dictionary<Months, Seasons>();

        //Мне не очень нравится мое заполнения словаря, очень много условий, но я не придумал ничего лучше(
        static void Initialization()
        {
            for (int i = 1; i < 13; i++)
            {
                if (i <= 2 | i == 12)
                {
                    correspondance.Add((Months)i, Seasons.Зима);
                }
                else if (i >= 3 & i <= 5)
                {
                    correspondance.Add((Months)i, Seasons.Весна);
                }
                else if (i >= 6 & i <= 8)
                {
                    correspondance.Add((Months)i, Seasons.Лето);
                }
                else
                {
                    correspondance.Add((Months)i, Seasons.Осень);
                }
            }
            initialized = true;
        }

        public static void Interface()
        {
            if (!initialized)
            {
                Initialization();
            }
            Console.WriteLine("Введите порядковый номер месяца:");
            int number;
            if (int.TryParse(Console.ReadLine(), out number))
            {
                if (number >= 1 & number <= 12)
                {
                    SeasonPrint(CorrCheck(number));
                }
                else
                {
                    Console.WriteLine("Введите значение от 1 до 12.");
                    Interface();
                }
            }
            else
            {
                Console.WriteLine("Введенное Вами значение не является целым числом.");
                Interface();
            }
        }

        static Seasons CorrCheck(int number)
        {
            if (correspondance.TryGetValue((Months)number, out var result))
            {
                return result;
            }
            else
            {
                throw new Exception("Ошибка при преобразовании месяца в сезон.");
            }
        }

        static void SeasonPrint(Seasons season)
        {
            Console.WriteLine(season);
        }
    }

    class Ex4Fibonacci
    {
        static int i0 = 0;
        static int i1 = 1;

        public static void Interface()
        {
            Console.WriteLine("Введите номер числа Фибоначчи:");
            if (int.TryParse(Console.ReadLine(), out int result))
                Console.WriteLine($"Число Фибоначчи: {Calc(result)}");
            else
                Console.WriteLine("Введенное Вами значение не является целым числом.");
        }

        public static int Calc(int n)
        {
            if (n == 2)
                return i1;
            else
            {
                n--;
                int i2 = Calc(n) + i0;
                i0 = i1;
                i1 = i2;
                return i1;
            }
        }

    }

    class Ex5StringNormalize
    {
        static string str1 = "Предложение один Теперь предложение два Предложение три";
        static string str2;
        public static void Normalize()
        {
            Console.WriteLine($"Начальная строка: {str1}.");
            string[] splitStr = str1.Split(' ');
            for (int i = 0; i < splitStr.Length; i++)
            {
                if (i == splitStr.Length - 1)
                {
                    splitStr[i] = splitStr[i].Insert(splitStr[i].Length, ". ");
                    str2 += splitStr[i];
                }
                else if (i < splitStr.Length - 1 && char.IsUpper(splitStr[i + 1], 0))
                {
                    splitStr[i] = splitStr[i].Insert(splitStr[i].Length, ". ");
                    str2 += splitStr[i];
                }
                else
                {
                    splitStr[i] = splitStr[i].Insert(splitStr[i].Length, " ");
                    str2 += splitStr[i];
                }
            }

            Console.WriteLine(str2);
        }
    }
}

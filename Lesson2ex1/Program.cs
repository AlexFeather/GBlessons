using System;

namespace lesson2
{
    class Program
    {
        static float minT;
        static float maxT;
        static float averageT;
        static Months curMonth = 0;
        static bool averageTempUsed = false;

        [Flags]
        enum Months
        {
            Январь = 1,
            Февраль = 2,
            Март = 3,
            Апрель = 4,
            Май = 5,
            Июнь = 6,
            Июль = 7,
            Август = 8,
            Сентябрь = 9,
            Октябрь = 10,
            Ноябрь = 11,
            Декабрь = 12
        }

        static string bank = "Сбербанк";
        static string restaurant = "JonJoli";
        static string restaurantAdress = "Маросейка, д. 4/2, стр. 1";
        static int checkNumber = 25;
        static float sum = 3000.00f;

        static string check = @$"
            {bank} 
            {restaurant}
            {restaurantAdress}
            Оплата по счету, чек № {checkNumber}
            Безналичный расчет
            Сумма (руб):
            {sum}
            Выдано иностранцу с табуреткой.
            Подтверждается, что слона он купил в нашем магазине.
            Покупайте наших слонов!";

        enum days
        {
            Понедельник = 0b_1000000,
            Вторник = 0b_0100000,
            Среда = 0b_0010000,
            Четверг = 0b_0001000,
            Пятница = 0b_0000100,
            Суббота = 0b_0000010,
            Воскресенье = 0b_0000001
        }

        days weekdays = days.Понедельник | days.Вторник | days.Среда | days.Четверг | days.Пятница;
        days holidays = days.Суббота | days.Воскресенье;
        days fullweek = days.Понедельник | days.Вторник | days.Среда | days.Четверг | days.Пятница | days.Суббота | days.Воскресенье;
        days shortweek = days.Вторник | days.Среда | days.Четверг | days.Пятница;

        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {
            Console.WriteLine(@"Введите номер задачи, чтобы увидеть результаты решения:
1.Среднесуточная температура.
2.Название месяца.
3.Четность числа.
4.Чек из магазина.
6.Работа офиса.");
            int chosenNumber;
            if (int.TryParse(Console.ReadLine(), out chosenNumber))
            {
                switch (chosenNumber)
                {
                    case 1:
                        AverageTemp();
                        if (curMonth != 0)
                            SeasonInfo();
                        Menu();
                        break;
                    case 2:
                        CurMonth();
                        if (averageTempUsed)
                            SeasonInfo();
                        Menu();
                        break;
                    case 3:
                        IsEven();
                        Menu();
                        break;
                    case 4:
                        CheckInfo();
                        Menu();
                        break;
                    case 5:
                        Console.WriteLine("Такое задание есть, но результат его выполнения вызывается по-другому.");
                        break;
                    case 6:
                        OfficeSchedule();
                        break;
                    default:
                        Console.WriteLine("Задачи с таким номером в задании нет.");
                        break;
                }

            }
        }

        static void AverageTemp()
        {
            Console.WriteLine("Введите минимальную температуру за сутки:");
            minT = TryParseTemp(Console.ReadLine());
            Console.WriteLine("Введите максимальную темпеатуру за сутки:");
            maxT = TryParseTemp(Console.ReadLine());
            averageT = (minT + maxT) / 2;
            Console.WriteLine($"Средняя температура за сутки равна {averageT} градусов.");
            averageTempUsed = true;
        }

        static void CurMonth()
        {
            int enteredNumber;
            Console.WriteLine("Введите номер текущего месяца:");
            if (int.TryParse(Console.ReadLine(), out enteredNumber))
            {
                if (enteredNumber > 0 && enteredNumber < 13)
                {
                    curMonth = (Months)enteredNumber;
                    Console.WriteLine($"Текущий месяц: {curMonth}");
                }
            }
        }

        static void IsEven()
        {
            Console.WriteLine("Введите целое число:");
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                if (result % 2 == 0)
                {
                    Console.WriteLine("Число четное.");
                }
                else
                {
                    Console.WriteLine("Число нечетное.");
                }
            }
            else
            {
                Console.WriteLine("Введенное Вами значение не является числом.");
            }
        }

        static void CheckInfo()
        {
            Console.WriteLine(check);
        }

        static void SeasonInfo()
        {
            if((curMonth == Months.Декабрь || curMonth == Months.Январь || curMonth == Months.Февраль) && averageT > 0)
            {
                Console.WriteLine("Дождливая зима");
            }
        }

        static void OfficeSchedule()
        {

        }

        static float TryParseTemp(string Input)
        {
            if(float.TryParse(Input, out float result))
            {
                return result;
            }
            else
            {
                Console.WriteLine( "Введенное Вами значение не является числом.");
                AverageTemp();
                return 0.0f;
            }
        }

    }

}

using System;
using System.Collections.Generic;
using System.IO;

namespace Lesson5
{
    class Program
    {
        static void Main(string[] args)
        {
            Ex2CurTimeToFile();
            Ex4Workers();
        }

        static void Ex1TextToFile()
        {

            string path = "..\\Ex1.txt";

            Console.WriteLine("Введите предложение для сохранения в файл:");
            string str = Console.ReadLine();

            if(!File.Exists(path))
            {
                File.Create(path);
            }

            File.AppendAllText(path, str);
            File.AppendAllText(path, Environment.NewLine);

            Console.WriteLine("Запуск чтения:");
            Console.WriteLine(File.ReadAllText(path));
            
        }

        static void Ex2CurTimeToFile()
        {
            string path = "..\\startup.txt";

            if (!File.Exists(path))
            {
                File.Create(path);
            }

            File.AppendAllText(path, DateTime.Now.ToString());
            File.AppendAllText(path, Environment.NewLine);

        }

        static void Ex3NumsToBinaryFile()
        {
            string path = "..\\numbers.bin";

            if (!File.Exists(path))
            {
                File.Create(path);
            }

            Console.WriteLine("Введите числа от 0 до 255 через пробел:");
            string str = Console.ReadLine();

            //Дальнейший кривой код связан с тем, что я не хотел допустить лишних нулей в бинарник
            //Если есть способ сделать это красивее - прошу сообщить
            string[] strArray = str.Split(' ');
            List<byte> byteList = new List<byte>();

            for(int i = 0; i < strArray.Length; i++)
            {
                if (byte.TryParse(strArray[i], out byte result))
                {
                    byteList.Add(result);
                }
                else
                {
                    Console.WriteLine($"Введенное Вами значение: '{strArray[i]}' некорректно.");
                }
            }

            byte[] byteArray = new byte[byteList.Count];
            for(int i = 0; i < byteList.Count; i++)
            {
                byteArray[i] = byteList[i];
            }

            File.WriteAllBytes(path, byteArray);
        }

        class Worker
        {
            public string Name { get; private set; }
            public string Position { get; private set; }
            public string Email { get; private set; }
            public string PhoneNumber { get; private set; }
            public int Salary { get; private set; }
            public int Age { get; private set; }

            public Worker(string name, string position, string email, string phoneNumer, int salary, int age)
            {
                Name = name;
                Position = position;
                Email = email;
                PhoneNumber = phoneNumer;
                Salary = salary;
                Age = age;
            }

            public Worker() { }

            public void WorkerWrite()
            {
                Console.WriteLine($"{Position} {Name}, почта: {Email}, телефон: {PhoneNumber}, возраст: {Age}, зарплата: {Salary}.");
            }

        }

        static void Ex4Workers()
        {
            Worker[] Workers = new Worker[5];
            Workers[0] = new Worker("Иванов Иван", "Директор", "ivanov@mailbox.ru", "8-908-888-08-58", 100000, 48);
            Workers[1] = new Worker("Петров Петр", "Генеральный директор", "petrov@mailbox.ru", "8-908-888-08-48", 1000000, 49);
            Workers[2] = new Worker("Сидоров Сидор", "Генеральнейший директор", "sidorov@mailbox.ru", "8-908-888-08-38", 10000000, 50);
            Workers[3] = new Worker("Вася Пупкин", "Сын собственника", "pupkin@mailbox.ru", "8-908-888-08-08", 1000000000, 4);
            Workers[4] = new Worker("Андрей Работяжкин", "Оператор, Бухгалтер, Кассир, Грузчик, Дворник, Пекарь, Водолаз, Говновоз, Курьер, Водитель, Консультант, Коллектор", "slave@mailbox.ru", "8-900-177-11-11", 1, 25);

            foreach (Worker worker in Workers)
            {
                if (worker.Age >= 40)
                    worker.WorkerWrite();
            }
        }
    }
}

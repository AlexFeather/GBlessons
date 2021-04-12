using System;
using System.IO;

namespace Lesson5
{
    class Program
    {
        static void Main(string[] args)
        {
            Ex2CurTimeToFile();
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
    }
}

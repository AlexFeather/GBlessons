using System;
using System.Diagnostics;

namespace Lesson6
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManagerMenu();
        }

        static void TaskManagerMenu()
        {
            Console.WriteLine(@"
Выберите действие:
1. Показать список процессов.
2. Завершить процесс по ID.
3. Завершить процесс по имени.");
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                switch (result)
                {
                    case 1:
                        ProcessList();
                        TaskManagerMenu();
                        break;
                    case 2:
                        KillProcess(GetID());
                        TaskManagerMenu();
                        break;
                    case 3:
                        KillProcess(GetName());
                        TaskManagerMenu();
                        break;
                    default:
                        Console.WriteLine("Введенное Вами значение не соответствует ни одному из пунктов меню.");
                        TaskManagerMenu();
                        break;
                }
            }
            else
            {
                Console.WriteLine("Введенное Вами значение не является целым числом.");
            }
        }

        static void ProcessList()
        {
            Process[] processes = Process.GetProcesses();
            ShowList(processes);
        }

        static void KillProcess(int id)
        {
            Process sentenced = Process.GetProcessById(id);
            try
            {
                sentenced.Kill();
            }
            catch
            {
                ThrowAccessException();
            }
        }

        static void KillProcess(string name)
        {
            Process[] sentenced = Process.GetProcessesByName(name);
            switch (sentenced.Length)
            {
                case 0:
                    Console.WriteLine("Процессов с таким именем не было найдено.");
                    break;
                case 1:
                    try
                    {
                        sentenced[0].Kill();
                    }
                    catch
                    {
                        ThrowAccessException();
                    }
                    break;
                default:
                    MultipleProcessesScenario(sentenced);
                    break;

            }

        }

        static void MultipleProcessesScenario(Process[] processes)
        {
            Console.WriteLine(@"
По заданному имени нейдено несколько процессов. Вы можете прекратить один из них по его ID или все разом:
1. Показать список и прекратить один по ID.
2. Прекратить все процессы.");
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                switch (result)
                {
                    case 1:
                        ShowList(processes);
                        KillProcess(GetID());
                        break;
                    case 2:
                        foreach (Process element in processes)
                            try
                            {
                                element.Kill();
                            }
                            catch
                            {
                                ThrowAccessException();
                            }
                        break;
                    default:
                        Console.WriteLine("Введенное Вами значение не соответствует ни одному пункту меню.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Введенное Вами значение не является целым числом.");
            }
        }

        static int GetID()
        {
            Console.WriteLine("Введите ID процесса для поиска по ID:");
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                return result;
            }
            else
            {
                throw new Exception("Введенное значение не является целым числом.");
            }
        }

        static string GetName()
        {
            Console.WriteLine("Введите имя процесса для поиска по имени:");
            string str = Console.ReadLine();
            return str;
        }

        static void ShowList(Process[] processes)
        {
            foreach (Process element in processes)
                Console.WriteLine($"{element.Id}: {element.ProcessName}");
        }

        static void ThrowAccessException()
        {
            throw new Exception("Отказано в доступе.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Lesson6
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        static void ProcessList()
        {
            Process[] processes = Process.GetProcesses();
            ShowList(processes);
        }

        static void KillProcess(int id)
        {
            Process sentenced = Process.GetProcessById(id);
            sentenced.Kill();
        }

        static void KillProcess(string name)
        {
            Process[] sentenced = Process.GetProcessesByName(name);
            switch(sentenced.Length)
            {
                case 0:
                    Console.WriteLine("Процессов с таким именем не было найдено.");
                    break;
                case 1:
                    sentenced[0].Kill();
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
2. Прератить все процессы.");
            if(int.TryParse(Console.ReadLine(), out int result))
            {
                switch(result)
                {
                    case 1:
                        break;
                    case 2:
                        foreach (Process element in processes)
                            element.Kill();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                Console.WriteLine("Введенное Вами значение не является целым числом.");
            }
        }

        static void ShowList(Process[] processes)
        {
            foreach (Process element in processes)
                Console.WriteLine($"{element.Id}: {element.ProcessName}");
        }
    }
}

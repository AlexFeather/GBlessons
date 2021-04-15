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
            Process[] Processes = Process.GetProcesses();
            foreach(Process element in Processes)
                Console.WriteLine($"{element.Id}: {element.ProcessName}");
        }
    }
}

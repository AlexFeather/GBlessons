using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SecondAPI
{
    /*����� ������� ��� ��� �� ��������, ��� ��� �� ����� �������. ����, ����� �������� ������, �������� ������� ���������, �� �� ������� ����������
    � ������ �������, ����� ����� ������ ���� ��������� ��������? ������ ��� ��������� � ����� ������?
    �� ������ - �� ��� ��� �� ���� ������, ������ � ���� �� ������������ ����� PerfomanceCounter ���, ���� ������� ����� �� � ���, �� � ���?
    */
    public class Program
    {
        
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
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
    /*часть задания все еще не выполнил, так как не очень понимаю. сдаю, чтобы получить фидбэк, доделать задание интересно, но не хватает информации
    в первую очередь, агент сбора метрик идет отдельным проектом? какова его структура в таком случае?
    во вторую - до сих пор не могу понять, почему у меня не определяется класс PerfomanceCounter или, если рабоать нужно не с ним, то с чем?
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

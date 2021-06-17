using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet;

namespace p2lesson4
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Example1 ex1 = new Example1();
            ex1.FillArray();
            HashSet<string> ts = ex1.MakeHashSet();

        }


    }

    class Example1
    {
        string[] stringArray = new string[10000];
        Random rd = new Random();


        public void FillArray()
        {
            for(int i = 0; i < stringArray.Length; i++)
            {
                stringArray[i] = MakeRandomString();
            }
        }

        private string MakeRandomString()
        {
            StringBuilder sb = new StringBuilder();
            string newString = null;
            for(int i = 0; i < 10; i++)
            {
                sb.Append(Convert.ToChar(rd.Next(65, 90)));
            }
            newString = sb.ToString();
            return newString;
        }

        public void PrintArray()
        {
            foreach(string element in stringArray)
            {
                Console.WriteLine($"{element} ");
            }
        }


        public HashSet<string> MakeHashSet()
        {
            var ts = new HashSet<string>();
            foreach (string element in stringArray)
            {
                int temp = element.GetHashCode();
                ts.Add(temp.ToString());
            }
            return ts;
        }

        public void PrintHashSet(HashSet<string> ts)
        {
            foreach (string element in ts)
            {
                Console.WriteLine(element);
            }
        }

        class Benchmark
        {
            [Benchmark(Description = "")]


        }
    }
}

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Text;

namespace p2lesson4
{
    class Program
    {
        static void Main(string[] args)
        {


        }


    }

    public class Example1
    {
        string[] stringArray = new string[10000];
        Random rd = new Random();
        HashSet<int> hs;

        public bool IsContainsString(string str)
        {
            foreach (string element in stringArray)
            {
                if (element.Equals(str))
                    return true;
            }
            return false;
        }

        public bool IsContainsStringByHash(string str)
        {
            int hash = str.GetHashCode();
            foreach (int element in hs)
            {
                if (element.Equals(hash))
                {
                    return true;
                }

            }
            return false;
        }

        public void FillArray()
        {
            for (int i = 0; i < stringArray.Length; i++)
            {
                stringArray[i] = MakeRandomString();
            }
        }

        public string MakeRandomString()
        {
            StringBuilder sb = new StringBuilder();
            string newString = null;
            for (int i = 0; i < 10; i++)
            {
                sb.Append(Convert.ToChar(rd.Next(65, 90)));
            }
            newString = sb.ToString();
            return newString;
        }

        public void PrintArray()
        {
            foreach (string element in stringArray)
            {
                Console.WriteLine($"{element} ");
            }
        }


        public void MakeHashSet()
        {
            foreach (string element in stringArray)
            {
                int temp = element.GetHashCode();
                hs.Add(temp);
            }

        }

        public void PrintHashSet(HashSet<string> ts)
        {
            foreach (string element in ts)
            {
                Console.WriteLine(element);
            }
        }

        public class Benchmark
        {
            Example1 ex1 = new Example1();
            public void Init()
            {

            }
            [Benchmark(Description = "sraight search")]
            public void Test1()
            {
                ex1.FillArray();
                ex1.MakeHashSet();
                string str = ex1.MakeRandomString();
                ex1.IsContainsString(str);
            }
            [Benchmark(Description = "hash search")]
            public void Test2()
            {
                ex1.FillArray();
                ex1.MakeHashSet();
                string str = ex1.MakeRandomString();
                ex1.IsContainsStringByHash(str);
            }
        }


        public class UnitTest1
        {
            public void TestMethod()
            {
                

                BenchmarkRunner.Run<Benchmark>();
            }

        }
    }
}

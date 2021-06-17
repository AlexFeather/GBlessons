using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace p2lesson4
{
    class Program
    {
        static void Main(string[] args)
        {

            Example1 ex1 = new Example1();

            ex1.FillArray();
            HashSet<int> ts = ex1.MakeHashSet();


        }


    }

    class Example1
    {
        string[] stringArray = new string[10000];
        Random rd = new Random();

        public bool IsContainsString(string str)
        {
            foreach (string element in stringArray)
            {
                if (element.Equals(str))
                    return true;
            }
            return false;
        }

        public bool IsContainsStringByHash(string str, HashSet<int> ts)
        {
            int hash = str.GetHashCode();
            foreach (int element in ts)
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


        public HashSet<int> MakeHashSet()
        {
            var ts = new HashSet<int>();
            foreach (string element in stringArray)
            {
                int temp = element.GetHashCode();
                ts.Add(temp);
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
            [Benchmark(Description = "sraight search")]
            public void Test1()
            {
                Example1 ex1 = new Example1();
                string str = ex1.MakeRandomString();
                ex1.IsContainsString(str);
            }
            [Benchmark(Description = "hash search")]
            public void Test2(HashSet<int> hash)
            {
                Example1 ex1 = new Example1();
                string str = ex1.MakeRandomString();
                ex1.IsContainsStringByHash(str, hash);
            }
        }

        [TestClass]
        public class UnitTest1
    }
}

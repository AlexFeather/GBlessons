using System;
using System.Collections.Generic;
using System.Linq;


namespace p2lesson8
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rd = new Random();
            int[] input = new int[rd.Next(15, 35)];
            for(int i = 0; i < input.Length; i++)
            {
                input[i] = rd.Next(0, 1000);
            }
            Console.WriteLine("Input:");
            foreach(var element in input)
            {
                Console.WriteLine(element);
            }
            int[] result = BucketSort(input);
            Console.WriteLine("Result:");
            foreach (var element in result)
            {
                Console.WriteLine(element);
            }

        }

        static int[] BucketSort(int[] input)
        {

            const int bucketsNum = 10;
            int maxValue = input.Max();
            int minValue = input.Min();
            int diff = maxValue - minValue;
            int[] result = new int[input.Length];
            int i = 0;

            List<List<int>> buckets = new List<List<int>>();
            for(i = 0; i < bucketsNum; i++)
            {
                var bucket = new List<int>();
                buckets.Add(bucket);
            }

            foreach(int element in input)
            {
                buckets[(element - minValue) / diff].Add(element);
            }

            foreach(var element in buckets)
            {
                element.Sort();
            }

            i = 0;
            foreach(var bucket in buckets)
            {
                foreach(var element in bucket)
                {
                    result[i] = element;
                    i++;
                }
            }
            return result;

        }
    }
}

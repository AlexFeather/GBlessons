using System;

namespace p2lesson2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testArray = new int[] { 1, 2, 4, 6, 7, 3, 5, 8, 9, 0 };
            TestRun test1 = new TestRun(testArray, 3, 3);
            testArray = new int[] { 9, 27, 36, 81, 72, 45, 18, 54, 63, 90 };
            TestRun test2 = new TestRun(testArray, 18, 1);
            testArray = new int[] { 40, 15, 22, 69, 70, 104, 505, 8, 36, 64, 1001, 204, 606, 16 };
            TestRun test3 = new TestRun(testArray, 505, 11);
            testArray = new int[] { 1, 1, 2, 3, 4, 5, 5, 5, 6, 7, 7, 7 };
            TestRun test4 = new TestRun(testArray, 8, 8);
            Test(test1); //expected invalid
            Array.Sort(test1.Input);
            Test(test1); //expected valid
            Test(test2); //expected invalid
            Array.Sort(test2.Input);
            Test(test2); //expected valid
            Array.Sort(test3.Input);
            Test(test3); //expected valid
            Test(test4); //expected invalid
        }

        public static void Test(TestRun testRun)
        {
            int result = BinarySearch(testRun.Input, testRun.SearchValue);
            if(result == testRun.ExpectedResult)
                System.Console.WriteLine("VALID TEST");
            else
                System.Console.WriteLine("INVALID TEST");
        }

        public static int BinarySearch(int[] Array, int Value) //поскольку метод каждую итерацию делит общий массив входных данных пополам, можно утверждать что O(N) = log^2 N
        {
            int min = 0;
            int max = Array.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (Value == Array[mid])
                {
                    return mid;
                }
                else if (Value < Array[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }

        public void Test()
        {

        }

        public class TestRun
        {
            public int[] Input { get; set; }
            public int SearchValue { get; set; }
            public int ExpectedResult { get; set; }

            public TestRun(int[] input, int searchValue, int expResult)
            {
                Input = input;
                SearchValue = searchValue;
                ExpectedResult = expResult;
            }


        }
    }
}

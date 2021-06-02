using System;

namespace p2lesson1
{
    class Example3
    {
        class NegativeNumberException : Exception
        {
            public NegativeNumberException() : base("Fibonacci number can only be greater than zero") { }

        }

        class TestCase
        {
            public int Input { get; set; }
            public int ExpectedOutcome { get; set; }
            public Exception ExpectedException { get; set; }

            public TestCase(int input, int eo, Exception ee)
            {
                Input = input;
                ExpectedOutcome = eo;
                ExpectedException = ee;
            }
        }
        static void Main()
        {
            TestCase case1 = new TestCase(5, 5, new NegativeNumberException());
            TestCase case2 = new TestCase(-1, 0, new NegativeNumberException());
            TestCase case3 = new TestCase(7, 13, new NegativeNumberException());
            TestCase case4 = new TestCase(10, 55, new NegativeNumberException());
            TestCase case5 = new TestCase(11, 89, new NegativeNumberException());

            Test(case1);
            Test(case2);
            Test(case3);
            Test(case4);
            Test(case5);

        }

        static void Test(TestCase testCase)
        {
            try
            {
                var actual = Fibonacci(testCase.Input);

                if (actual == testCase.ExpectedOutcome)
                    Console.WriteLine("VALID TEST");
                else
                    Console.WriteLine("INVALID TEST");
            }
            catch(Exception ex)
            {
                if(testCase.ExpectedException != null)
                {
                    if(ex == testCase.ExpectedException)
                        Console.WriteLine("VALID TEST");
                    else
                        Console.WriteLine("INVALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
        }

        static int Fibonacci(int fn)
        {
            int n0 = 0;
            int n1 = 1;
            int n2 = 1;

            if (fn >= 2)
            {
                for (int i = 2; i <= fn; i++)
                {
                    n2 = n1 + n0;
                    n0 = n1;
                    n1 = n2;
                }

                return n2;
            }
            else if (fn == 1)
                return n0;
            else
                throw new NegativeNumberException();

        }
    }
}

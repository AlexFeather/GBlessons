using System;

namespace p2lesson1
{
    class Program
    {
        public class TestCase
        {
            public int n { get; set; }
            public bool ExpectedOutcome;

        }

        static void Main(string[] args)
        {
            TestCase Case1 = new TestCase
            {
                n = 5,
                ExpectedOutcome = true
            };

            TestCase Case2 = new TestCase
            {
                n = 11,
                ExpectedOutcome = true
            };

            TestCase Case3 = new TestCase
            {
                n = 12,
                ExpectedOutcome = false
            };

            TestCase Case4 = new TestCase
            {
                n = 133,
                ExpectedOutcome = false
            };

            TestCase Case5 = new TestCase
            {
                n = 109,
                ExpectedOutcome = true
            };

            TestMethod(Case1);
            TestMethod(Case2);
            TestMethod(Case3);
            TestMethod(Case4);
            TestMethod(Case5);

        }

        static void TestMethod(TestCase Case)
        {
            try
            {
                var actual = IsPrimeNumber(Case.n);

                if (actual == Case.ExpectedOutcome)
                {
                    Console.WriteLine("VALID TEST");
                }
                else
                {
                    Console.WriteLine("INVALID TEST");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("INVALID TEST");
            }

        }

        static int Input()
        {
            Console.WriteLine("Введите значение для n:");
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException("Введенное значение не является числом");
            }
        }

        static bool IsPrimeNumber(int n)
        {
            //int n;
            int d = 0;
            int i;

            //n = Input();

            for (i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    d++;
                }
            }

            if (d == 0)
                return true;
            else
                return false;

        }
    }
}

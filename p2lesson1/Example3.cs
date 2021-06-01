using System;

namespace p2lesson1
{
    class Example3
    {
        class NegativeNumberException : Exception
        {
            public NegativeNumberException() : base("Fibonacci number can only be greater than zero") { }

        }
        static void Main()
        {
            Console.WriteLine(Fibonacci(7).ToString());

        }

        static int Fibonacci(int fn)
        {
            int n0 = 0;
            int n1 = 1;
            int n2 = 1;

            if (fn >= 2)
            {
                for (int i = 3; i <= fn; i++)
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

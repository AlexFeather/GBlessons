using System;

namespace p2lesson1
{
    class Example3
    {
        static void Main()
        {
            Console.WriteLine(Fibonacci(7).ToString());

        }

        static int Fibonacci(int fn)
        {
            int n0 = 0;
            int n1 = 1;
            int n2 = 1;


            for (int i = 3; i <= fn; i++)
            {
                n2 = n1 + n0;
                n0 = n1;
                n1 = n2;
            }

            return n2;
        }
    }
}

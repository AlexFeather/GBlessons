using System;

namespace p2lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        class LenghtInputClass
        {
            public float X;
            public float Y;
        }

        struct LenghtInputStructFloat
        {
            public float X;
            public float Y;
        }

        struct LenghtInputStructDouble
        {
            public double X;
            public double Y;
        }

        static float Lenght_Float(LenghtInputClass input)
        {
            float result = MathF.Sqrt((input.X * input.X) + (input.Y * input.Y));
            return result;
        }

        
    }
}

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Text;

namespace p2lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        class FloatPointClass
        {
            public float X;
            public float Y;
        }

        struct FloatPointStruct
        {
            public float X;
            public float Y;
        }

        struct DoublePointStruct
        {
            public double X;
            public double Y;
        }




        static float LenghtFloat(FloatPointClass input1, FloatPointClass input2)
        {
            float Width = input1.X - input2.X;
            float Height = input1.Y = input2.Y;
            float result = MathF.Sqrt((Width * Width) + (Height * Height));
            return result;
        }

        static float LenghtFloat(FloatPointStruct input1, FloatPointStruct input2)
        {
            float Width = input1.X - input2.X;
            float Height = input1.Y = input2.Y;
            float result = MathF.Sqrt((Width * Width) + (Height * Height));
            return result;
        }

        static double LenghtDouble(DoublePointStruct input1, DoublePointStruct input2)
        {
            double Width = input1.X - input2.X;
            double Height = input1.Y = input2.Y;
            double result = Math.Sqrt((Width * Width) + (Height * Height));
            return result;
        }

        static double LenghtWithoutSqrt(DoublePointStruct input1, DoublePointStruct input2)
        {
            double Width = input1.X - input2.X;
            double Height = input1.Y = input2.Y;
            double result = (Width * Width) + (Height * Height);
            return result;
        }
    }
}


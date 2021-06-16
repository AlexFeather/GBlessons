using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Reports;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;
using System.Text;

namespace p2lessom3
{
    class Program
    {
        public Benchmark b = new Benchmark { };
        public static FloatPointClass classInput1 = new FloatPointClass { X = 10, Y = 140 };
        public static FloatPointClass classInput2 = new FloatPointClass { X = 200, Y = 150 };
        public static FloatPointStruct structFloatInput1 = new FloatPointStruct { X = 10, Y = 140 };
        public static FloatPointStruct structFloatInput2 = new FloatPointStruct { X = 200, Y = 150 };
        public static DoublePointStruct structDoubleInput1 = new DoublePointStruct { X = 10, Y = 140 };
        public static DoublePointStruct structDoubleInput2 = new DoublePointStruct { X = 200, Y = 150 };
        static void Main(string[] args)
        {
            UnitTest1.TestMethod1();
        }

        public class FloatPointClass
        {
            public float X;
            public float Y;
        }

        public struct FloatPointStruct
        {
            public float X;
            public float Y;
        }

        public struct DoublePointStruct
        {
            public double X;
            public double Y;
        }


        static public float LenghtFloat(FloatPointClass input1, FloatPointClass input2)
        {
            float Width = input1.X - input2.X;
            float Height = input1.Y - input2.Y;
            float result = MathF.Sqrt((Width * Width) + (Height * Height));
            return result;
        }

        static public float LenghtFloat(FloatPointStruct input1, FloatPointStruct input2)
        {
            float Width = input1.X - input2.X;
            float Height = input1.Y - input2.Y;
            float result = MathF.Sqrt((Width * Width) + (Height * Height));
            return result;
        }

        static public double LenghtDouble(DoublePointStruct input1, DoublePointStruct input2)
        {
            double Width = input1.X - input2.X;
            double Height = input1.Y - input2.Y;
            double result = Math.Sqrt((Width * Width) + (Height * Height));
            return result;
        }

        static public double LenghtWithoutSqrt(DoublePointStruct input1, DoublePointStruct input2)
        {
            double Width = input1.X - input2.X;
            double Height = input1.Y - input2.Y;
            double result = (Width * Width) + (Height * Height);
            return result;
        }

    }

    public class Benchmark
    {
        [Benchmark(Description = "Lenght Float using class")]
        public void Measurment1()
        {
            Program.LenghtFloat(Program.classInput1, Program.classInput2);
        }

        [Benchmark(Description = "Lenght Float using struct")]
        public void Measurment2()
        {
            Program.LenghtFloat(Program.structFloatInput1, Program.structFloatInput1);
        }

        [Benchmark(Description = "Lenght Double using struct with sqrt")]
        public void Measurment3()
        {
            Program.LenghtDouble(Program.structDoubleInput1, Program.structDoubleInput1);
        }

        [Benchmark(Description = "Lenght Double using struct without sqrt")]
        public void Measurment4()
        {
            Program.LenghtWithoutSqrt(Program.structDoubleInput1, Program.structDoubleInput1);
        }
    }

    public class UnitTest1
    {
        public static void TestMethod1()
        {
            BenchmarkRunner.Run<Benchmark>();
        }
    }
}
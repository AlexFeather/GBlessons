using System;

namespace Lesson3
{
    class Program
    {
        static void Main(string[] args)
        {
            DiagonalRead();
        }

        static void Menu()
        {

        }

        static void DiagonalRead()
        {
            int[,] mass1 = {
                { 4, 8, 5},
                { 15, 6, 1},
                { 9, 14, 18}
            };

            for (int i = 0; i < 3; i++ )
            {
                Console.WriteLine(mass1[i,i]);
            }
        }
    }
}

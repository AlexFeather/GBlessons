using System;
using System.Collections.Generic;
using System.Text;

namespace p2lesson1
{
    class Example2
    {
        public static int StrangeSum(int[] inputArray) //итог: O(N^3)
        {
            int sum = 0; //можно пренебречь по третьему правилу, если длина массива больше 1
            for (int i = 0; i < inputArray.Length; i++) //O(N^2 * N) = O(N^3) четвертое правило
            {
                for (int j = 0; j < inputArray.Length; j++) //O(N*N) = O (N^2) четвертое правило
                {
                    for (int k = 0; k < inputArray.Length; k++) //O(N(1+1+1) = O(3N), по пятому правилу тройкой можно пренебречь, так что O(N), первое правило)
                    {
                        int y = 0;// O(1)

                        if (j != 0)
                        {
                            y = k / j; //O(1)
                        }

                        sum += inputArray[i] + i + k + j + y; // O(1)
                    }
                }
            }

            return sum; //можно пренебречь по третьему правилу, если длина массива больше 1
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Utils
{
    static class Utils
    {
        // swap two variables
        public static void Swap<T>(ref T x, ref T y)
        {
            T temp = x;
            x = y;
            y = temp;
        }

        // fill array with a data value
        public static void Fill<T>(T[] array, T value)
        {
            int len = array.GetLength(0);
            for (int i = 0; i < len; i++)
                array[i] = value;
        }

        public static ulong WrapDiff(ulong high, ulong low)
        {
            // return the difference, accounting for possible wraparound
            return (high >= low) ? (high - low) : (high + ~low + 1);
        }
    }
}

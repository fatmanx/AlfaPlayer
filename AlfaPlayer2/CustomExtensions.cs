using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AlfaPlayer2
{
    public static class CustomExtensions
    {
        public static T Clamp<T>(this T val, T min, T max) where T : IComparable<T>
        {
            if (val.CompareTo(min) < 0) return min;
            else if (val.CompareTo(max) > 0) return max;
            else return val;
        }

        public static string Reverse(this string val)
        {
            char[] array = new char[val.Length];
            int forward = 0;
            for (int i = val.Length - 1; i >= 0; i--)
            {
                array[forward++] = val[i];
            }
            return new string(array);
        }

    }
}

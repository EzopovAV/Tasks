using System;
using System.Numerics;

namespace Task_1
{
    public static class MathExt
    {
        public static int Factorial(int n)
        {
            return n <= 1 ? 1 : n * Factorial(n - 1);
        }

        public static BigInteger MyFactorial(int n)
        {
            if (n < 0) throw new ArgumentOutOfRangeException("n", "n can't be negative");

            BigInteger result = 1;

            for (int i = 1; i < n; i++)
            {
                result = result * i;
            }

            return result;
        }
    }
}

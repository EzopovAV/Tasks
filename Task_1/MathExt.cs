using System;

namespace Task_1
{
    public static class MathExt
    {
        public static int Factorial(int n)
        {
            return n <= 1 ? 1 : n * Factorial(n - 1);
        }
    }
}

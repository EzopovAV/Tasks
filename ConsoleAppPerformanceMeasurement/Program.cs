using System;
using System.Diagnostics;
using Task_1;
using System.IO;

namespace ConsoleAppPerformanceMeasurement
{
    class Program
    {
        static void Main(string[] args)
        {
            PerformanceMeasurement(MathExt.Factorial, "Factorial.csv");

            // To correctly compare performance, change the return type MathExt.MyFactorial to int32.
            //PerformanceMeasurement(MathExt.MyFactorial, "MyFactorial.csv");
        }

        static void PerformanceMeasurement(Func<int, int> func, string fileName)
        {
            if (File.Exists(fileName)) File.Delete(fileName);

            for (int i = 0; i < 10000; i += 10)
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                func(i);

                sw.Stop();

                File.AppendAllLines(fileName,
                    new string[] { i.ToString() + "; " + sw.ElapsedTicks.ToString() });
            }
        }
    }
}

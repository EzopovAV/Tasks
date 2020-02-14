using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task_1.Test
{
    [TestClass]
    public class MathExt_Factorial_Test
    {
        [TestMethod]
        public void Factorial_0()
        {
            var a = Task_1.MathExt.Factorial(0);
            var b = 1;
            Assert.AreEqual(b, a);
        }
        [TestMethod]
        public void Factorial_1()
        {
            var a = Task_1.MathExt.Factorial(1);
            var b = 1;
            Assert.AreEqual(b, a);
        }
        [TestMethod]
        public void Factorial_5()
        {
            var a = Task_1.MathExt.Factorial(5);
            var b = 120;
            Assert.AreEqual(b, a);
        }
        [TestMethod]
        public void Factorial_20()
        {
            var a = Task_1.MathExt.Factorial(20);
            var b = 2432902008176640000;
            Assert.AreEqual(b, a);
        }
        [TestMethod]
        public void Factorial_minus3()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => Task_1.MathExt.Factorial(-3));
        }
        //[TestMethod]
        public void Factorial_100000()
        {
            Assert.IsNotInstanceOfType(Task_1.MathExt.Factorial(100000), typeof(StackOverflowException));
        }
    }
}

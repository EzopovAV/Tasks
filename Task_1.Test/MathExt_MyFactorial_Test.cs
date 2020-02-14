using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task_1.Test
{
    [TestClass]
    public class MathExt_MyMyFactorial_Test
    {
        [TestMethod]
        public void MyFactorial_0()
        {
            var a = Task_1.MathExt.MyFactorial(0);
            var b = 1;
            Assert.AreEqual(b, a);
        }
        [TestMethod]
        public void MyFactorial_1()
        {
            var a = Task_1.MathExt.MyFactorial(1);
            var b = 1;
            Assert.AreEqual(b, a);
        }
        [TestMethod]
        public void MyFactorial_5()
        {
            var a = Task_1.MathExt.MyFactorial(5);
            var b = 120;
            Assert.AreEqual(b, a);
        }
        [TestMethod]
        public void MyFactorial_20()
        {
            var a = Task_1.MathExt.MyFactorial(20);
            var b = 2432902008176640000;
            Assert.AreEqual(b, a);
        }
        [TestMethod]
        public void MyFactorial_minus3()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(
                () => Task_1.MathExt.MyFactorial(-3));
        }
        [TestMethod]
        public void MyFactorial_100000()
        {
            Assert.IsNotInstanceOfType(Task_1.MathExt.MyFactorial(100000), typeof(StackOverflowException));
        }
    }
}

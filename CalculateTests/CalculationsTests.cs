using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

using Pr4PogosyanNikolaeva.Pages;

namespace CalculateTests
{
    [TestClass]
    public class CalculationsTests
    {
        _2TaskPage task2 = new _2TaskPage();

        [TestMethod]
        public void TestMethod1Task()
        {
            var task1 = new _1TaskPage();
            int x = 2;
            int y = 3;
            int z = 4;

            double answer = (Math.Pow((y + Math.Pow(x - 1, 1.0 / 3.0)), 1.0 / 4.0)) /
                (  Math.Abs(x - y) * (    Math.Pow(Math.Sin(z),2)  +   Math.Tan(z)    ) );

            double ProgAns = task1.Calculate(x, y,z);
            Assert.AreEqual(ProgAns, answer, .001);
        }

        [TestMethod]
        public void TestMethod2_1Task()
        {
            int x = 2;
            int y = 2;
            double f1(int xx) => Math.Sinh(xx);

            double ans1 = Math.Pow(f1(x), 2) + y * y + Math.Sin(y);
            double ProgAns1 = task2.Calculate(x, y, task2.Sh);

            Assert.AreEqual(ProgAns1, ans1, .001);
        }
        [TestMethod]
        public void TestMethod2_2Task()
        {

            double f2(int xx) { return Math.Pow(xx, 2); }

            int x = 4;
            int y = 2;
            double ans2 = Math.Pow(f2(x) - y, 2) + Math.Cos(y);
            double ProgAns2 = task2.Calculate(x, y, task2.X2);

            Assert.AreEqual(ProgAns2, ans2, .001);
        }
        [TestMethod]
        public void TestMethod2_3Task()
        {

            double f3(int xx) => Math.Exp(xx);

            int x = -3;
            int y = 1;

            double ans3 = Math.Pow(y - f3(x), 2) + Math.Tan(y);
            double ProgAns3 = task2.Calculate(x, y, task2.EX);

            Assert.AreEqual(ProgAns3, ans3, .001);
        }


        [TestMethod]
        public void TestMethod3Task()
        {
            double x = 1;
            double b = 2;
            var task3 = new _3TaskPage();
            double answer = Math.Sqrt(Math.Abs(x - b)) / Math.Pow(Math.Abs(Math.Pow(b, 3) - Math.Pow(x, 3)), 3.0 / 2.0) + Math.Log(Math.Abs( x - b));
            double ProgAns = task3.CalculateFunction(x, b);

            Assert.AreEqual(ProgAns, answer, .001);

        }

    }
}

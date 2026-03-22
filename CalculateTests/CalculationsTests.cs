using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pr4PogosyanNikolaeva.Pages;
using System;
using System.Collections.Generic;

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

            double answer = 0.817;

            double ProgAns = task1.Calculate(x, y,z);
            Assert.AreEqual(ProgAns, answer, .001);
        }

        [TestMethod]
        public void TestMethod2_1Task()
        {
            int x = 2;
            int y = 2;

            double ans1 = 18.063;
            double ProgAns1 = task2.Calculate(x, y, task2.Sh);

            Assert.AreEqual(ProgAns1, ans1, .001);
        }
        [TestMethod]
        public void TestMethod2_2Task()
        {

            int x = 4;
            int y = 2;
            double ans2 = 195.583;
            double ProgAns2 = task2.Calculate(x, y, task2.X2);

            Assert.AreEqual(ProgAns2, ans2, .001);
        }
        [TestMethod]
        public void TestMethod2_3Task()
        {


            int x = -3;
            int y = 1;

            double ans3 = 2.460;
            double ProgAns3 = task2.Calculate(x, y, task2.EX);

            Assert.AreEqual(ProgAns3, ans3, .001);
        }


        [TestMethod]
        public void TestMethod3Task()
        {
            double x = 1;
            double b = 2;
            var task3 = new _3TaskPage();
            double answer = 0.053;
            double ProgAns = task3.CalculateFunction(x, b);

            Assert.AreEqual(ProgAns, answer, .001);

        }

        [TestMethod]
        public void TestMethod3_ListTask()
        {
            double x0 = -1;
            double dx = 1;
            double xk = 1;
            double b = 2;
            var task3 = new _3TaskPage();
            var answer =  new List<(double, double, bool)>
            {
                (-1, 1.163, true),
                (0, .756, true),
                (1, .054, true),
            };
            var ProgAns = task3.TabulateFunction(x0, xk, dx, b);

            for (int i = 0; i < answer.Count; i++) 
            {
                Assert.AreEqual(ProgAns[i], answer[i]);

            }
        }

    }
}

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
        public void TestMethod_Positive_1Task()
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
        public void TestMethod_Negative_DivisionByZero_1Task()
        {
            var task1 = new _1TaskPage();
            int x = 0;
            int y = 0;
            int z = 0;

            Assert.ThrowsException<System.DivideByZeroException>(() => task1.Calculate(x, y, z));

        }

        [TestMethod]
        public void TestMethod_Negative_1Task_Tang()
        {
            var task1 = new _1TaskPage();
            double x = 2;
            double y = 3;
            double z = Math.PI / 2; 

            Assert.ThrowsException<System.ArgumentException>(() => task1.Calculate(x, y, z), "Тангенс не определен (cos(z) = 0)");

        }

        [TestMethod]
        public void TestMethod_Positive_2_1Task()
        {
            int x = 2;
            int y = 2;

            double ans1 = 18.063;
            double ProgAns1 = task2.Calculate(x, y, task2.Sh);

            Assert.AreEqual(ProgAns1, ans1, .001);
        }
        
        [TestMethod]
        public void TestMethod_Positive_2_2Task()
        {

            int x = 4;
            int y = 2;
            double ans2 = 195.583;
            double ProgAns2 = task2.Calculate(x, y, task2.X2);

            Assert.AreEqual(ProgAns2, ans2, .001);
        }
        
        [TestMethod]
        public void TestMethod_Positive_2_3Task()
        {


            int x = -3;
            int y = 1;

            double ans3 = 2.460;
            double ProgAns3 = task2.Calculate(x, y, task2.EX);

            Assert.AreEqual(ProgAns3, ans3, .001);
        }

        [TestMethod]
        public void TestMethod_Negative_2Task_InvalidFunction()
        {
            var task2 = new _2TaskPage();
            int x = 2;
            int y = 2;

            Assert.ThrowsException<ArgumentNullException>(() => task2.Calculate(x, y, null));
        }

        [TestMethod]
        public void TestMethod_Positive_2Task_AllFunctions()
        {
            var task2 = new _2TaskPage();
            int x = 2;
            int y = 1;

            double resultSh = task2.Calculate(x, y, task2.Sh);
            double resultX2 = task2.Calculate(x, y, task2.X2);
            double resultEX = task2.Calculate(x, y, task2.EX);

            Assert.IsFalse(resultSh == resultX2 && resultX2 == resultEX,
                "Разные функции должны возвращать разные результаты");
        }


        [TestMethod]
        public void TestMethod_Positive_3Task()
        {
            double x = 1;
            double b = 2;
            var task3 = new _3TaskPage();
            double answer = 0.053;
            double ProgAns = task3.CalculateFunction(x, b);

            Assert.AreEqual(ProgAns, answer, .001);

        }

        [TestMethod]
        public void TestMethod_Positive_3_ListTask()
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
        [TestMethod]
        public void TestMethod_Negative_3Task_ReturnsNaN()
        {
            var task3 = new _3TaskPage();
            double x = 2;
            double b = 2; 

            double result = task3.CalculateFunction(x, b);

            Assert.IsTrue(double.IsNaN(result));
        }


        [TestMethod]
        public void TestMethod_Negative_3Task_Cube_ReturnsNaN()
        {
            var task3 = new _3TaskPage();
            double x = 1;
            double b = 1; 

            double result = task3.CalculateFunction(x, b);

            Assert.IsTrue(double.IsNaN(result), "Функция возвращает NaN при b^3 - x^3 = 0");
        }
    }
}

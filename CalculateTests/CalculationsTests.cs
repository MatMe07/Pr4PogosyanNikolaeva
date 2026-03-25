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
        public void Test_Positive_2Task_Sh_EqualsZero()
        {
            double x = 2;
            double y = 2;
            double expected = 18.063;
            double actual = task2.Calculate(x, y, task2.Sh);
            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestMethod]
        public void Test_Positive_2Task_Sh_GreaterThanZero()
        {
            double x = 3;
            double y = 1;
            double expected = 81.862;
            double actual = task2.Calculate(x, y, task2.Sh);
            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestMethod]
        public void Test_Positive_2Task_Sh_LessThanZero()
        {
            double x = 1;
            double y = 3;
            double expected = 3.188;
            double actual = task2.Calculate(x, y, task2.Sh);
            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestMethod]
        public void Test_Positive_2Task_X2_EqualsZero()
        {
            double x = 3;
            double y = 3;
            double expected = 90.141;
            double actual = task2.Calculate(x, y, task2.X2);
            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestMethod]
        public void Test_Positive_2Task_X2_GreaterThanZero()
        {
            double x = 4;
            double y = 2;
            double expected = 195.584;
            double actual = task2.Calculate(x, y, task2.X2);
            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestMethod]
        public void Test_Positive_2Task_X2_LessThanZero()
        {
            double x = 2;
            double y = 5;
            double expected = -2.381;
            double actual = task2.Calculate(x, y, task2.X2);
            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestMethod]
        public void Test_Positive_2Task_EX_EqualsZero()
        {
            double x = 1;
            double y = 1;
            double expected = 9.230;
            double actual = task2.Calculate(x, y, task2.EX);
            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestMethod]
        public void Test_Positive_2Task_EX_GreaterThanZero()
        {
            double x = 2;
            double y = 1;
            double expected = 41.36;
            double actual = task2.Calculate(x, y, task2.EX);
            Assert.AreEqual(expected, actual, 0.001);
        }

        [TestMethod]
        public void Test_Positive_2Task_EX_LessThanZero()
        {
            double x = 0;
            double y = 2;
            double expected = -1.185;
            double actual = task2.Calculate(x, y, task2.EX);
            Assert.AreEqual(expected, actual, 0.001);
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
        public void TestMethod_Positive_3Task_WithBreaks()
        {
            var task3 = new _3TaskPage();
            double x0 = -3;
            double xk = 3;
            double dx = 1;
            double b = 1;

            var results = task3.TabulateFunction(x0, xk, dx, b);

            var expected = new List<(double x, double y, bool isValid)>
            {
                (-3, -0.683, true),
                (-2, -0.548, true),
                (-1, -0.347, true),
                (0, -0.693, true),
                (1, double.NaN, false),
                (2, 0.693, true),
                (3, 0.896, true)
            };

            for (int i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i], results[i]);
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

 
    }
}

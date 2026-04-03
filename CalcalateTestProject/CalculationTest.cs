using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Pr4PogosyanNikolaeva;

namespace CalcalateTestProject
{
    [TestClass]
    public class CalculationTest
    {
        MainWindow wind = new MainWindow();
        [TestMethod]
        public void TestMethodPosAdd()
        {
            double res = wind.Calculate(2, 2, "+");
            Assert.AreEqual(4, res);

        }
        [TestMethod]
        public void TestMethodPosAddDouble()
        {
            double res = wind.Calculate(2.5, 2.5, "+");
            Assert.AreEqual(5.0, res);

        }

        [TestMethod]
        public void TestMethodPosSubtract() {
            double res = wind.Calculate(2, 2, "-");
            Assert.AreEqual(0, res);
        }
        [TestMethod]
        public void TestMethodPosMultiply()
        {
            double res = wind.Calculate(2, 2, "*");
            Assert.AreEqual(4, res);
        }
        [TestMethod]
        public void TestMethodPosDivide()
        {
            double res = wind.Calculate(2, 2, "/");
            Assert.AreEqual(1, res);
        }
        [TestMethod]
        public void TestMethodPosDivideDouble()
        {
            double res = wind.Calculate(1, 3, "/");
            Assert.AreEqual(0.33, res, 0.01);
        }

        [TestMethod]
        public void TestMethodExeption()
        {
            Assert.ThrowsException<DivideByZeroException>(() => wind.Calculate(2, 0, "/"));
        }
    }
}

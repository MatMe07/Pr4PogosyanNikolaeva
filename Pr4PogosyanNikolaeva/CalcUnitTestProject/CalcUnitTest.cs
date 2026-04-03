using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Pr4PogosyanNikolaeva;

namespace CalcUnitTestProject
{
    [TestClass]
    public class CalcUnitTest1
    {
        public MainWindow wind = new MainWindow();

        [TestMethod]
        public void Test_CalZarplAssist()
        {
            double res = 300;

            Assert.AreEqual(wind.CalculateDoxod(2, "ассистент"), res, .001);
        }
        [TestMethod]
        public void Test_CalZarplDozent()
        {
            double res = 500;

            Assert.AreEqual(wind.CalculateDoxod(2, "доцент"), res, .001);
        }
        [TestMethod]
        public void Test_CalZarplProfesor()
        {
            double res = 700;

            Assert.AreEqual(wind.CalculateDoxod(2, "профессор"), res, .001);
        }


        [TestMethod]
        public void Test_CalZarplProfesor_Negative()
        {
            Assert.ThrowsException<System.ArgumentException>(() => wind.CalculateDoxod(-1, "профессор"));
        }


        [TestMethod]
        public void Test_CalNalog()
        {
            double res = 26;

            Assert.AreEqual(wind.CalculateNalog(200), res, .001);
        }



    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pr4PogosyanNikolaeva;
using System;

namespace MatrixCipherUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        public MainWindow MainWindow = new MainWindow();    
        [TestMethod]
        public void TestMethod_EncryptText_R2C2()
        {
            string text = "СТОЛ";
            int row = 2;
            int col = 2;
            string expected = "СОТЛ";

            string actual = MainWindow.MatrixCipher(text, row, col, MainWindow.Encrypt);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod_DecryptText_R2C2()
        {
            string text = "СОТЛ";
            int row = 2;
            int col = 2;
            string expected = "СТОЛ";

            string actual = MainWindow.MatrixCipher(text, row, col, MainWindow.Decrypt);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestMethod_EncryptText_RowsZero_Exception()
        {
            string text = "ТЕСТ";
            int row = 0;
            int col = 3;

            Assert.ThrowsException<ArgumentException>(() =>
                MainWindow.MatrixCipher(text, row, col, MainWindow.Encrypt));
        }

        [TestMethod]
        public void TestMethod_EncryptText_MatrixSizeTooSmall_ThrowsException()
        {
            string text = "Крокодил";
            int row = 2;
            int col = 2;

            Assert.ThrowsException<ArgumentException>(() =>
                MainWindow.MatrixCipher(text, row, col, MainWindow.Encrypt));
        }

        [TestMethod]
        public void TestMethod_EncryptText_NotFullMatrix_AddsSpaces()
        {
            string text = "ПРИВЕТ";
            int row = 3;
            int col = 3;
            string expected = "ПВ РЕ ИТ ";

            string actual = MainWindow.MatrixCipher(text, row, col, MainWindow.Encrypt);

            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void TestMethod_DecryptText_WithSpaces_RemovesSpaces()
        {
            string text = "ПВ РЕ ИТ ";
            int row = 3;
            int col = 3;
            string expected = "ПРИВЕТ";

            string actual = MainWindow.MatrixCipher(text, row, col, MainWindow.Decrypt);

            Assert.AreEqual(expected, actual);
        }
    }
}

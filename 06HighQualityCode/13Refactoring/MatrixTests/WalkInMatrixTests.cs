using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Matrix;

namespace MatrixTests
{
    [TestClass]
    public class WalkInMatrixTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestWalkInMatrixOfSizeZero()
        {
            WalkInMatrix matrix = new WalkInMatrix(0);
        }

        [TestMethod]
        public void TestWalkInMatrixOfSizeOne()
        {
            WalkInMatrix matrix = new WalkInMatrix(1);
            matrix.Walk();
            string expected = "1";
            Assert.AreEqual(expected, matrix.ToString());
        }

        [TestMethod]
        public void TestWalkInMatrixOfSizeTwo()
        {
            WalkInMatrix matrix = new WalkInMatrix(2);
            matrix.Walk();
            string expected = "1   4   " + Environment.NewLine + "3   2";
            Assert.AreEqual(expected, matrix.ToString());
        }

        [TestMethod]
        public void TestWalkInMatrixOfSizeSix()
        {
            WalkInMatrix matrix = new WalkInMatrix(6);
            matrix.Walk();

            string expected = "1   16  17  18  19  20  " + Environment.NewLine +
                                "15  2   27  28  29  21  " + Environment.NewLine +
                                "14  31  3   26  30  22  " + Environment.NewLine +
                                "13  36  32  4   25  23  " + Environment.NewLine +
                                "12  35  34  33  5   24  " + Environment.NewLine +
                                "11  10  9   8   7   6";

            Assert.AreEqual(expected, matrix.ToString());
        }
    }
}

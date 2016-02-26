using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SdetUnityTestAssignment.FractionCalculator;

namespace SdetUnityTestAssignmentTests
{
    [TestClass]
    public class FractionCalculatorTest
    {
        #region Fraction Tests

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ZeroDenominatorTest()
        {
            Fraction f = new Fraction(1, 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ZeroFractionTest()
        {
            Fraction f = new Fraction(0, 0);
        }

        [TestMethod]
        public void ZeroNumeratorTest()
        {
            Fraction f = new Fraction(0, 1);
            Assert.IsTrue(f.Numerator == 0);
        }

        [TestMethod]
        public void FractionConstructorTest()
        {
            Fraction f = new Fraction(1, 2);
            Assert.IsTrue(f.Numerator == 1);
            Assert.IsTrue(f.Denominator == 2);
        }

        [TestMethod]
        public void NegativeNumeratorTest()
        {
            Fraction f = new Fraction(-1, 2);
            Assert.IsTrue(f.Numerator == -1);
            Assert.IsTrue(f.Denominator == 2);
        }

        [TestMethod]
        public void NegativeDenominatorTest()
        {
            Fraction f = new Fraction(1, -2);
            Assert.IsTrue(f.Numerator == -1);
            Assert.IsTrue(f.Denominator == 2);
        }

        [TestMethod]
        public void NegativeNumeratorAndDenominatorTest()
        {
            Fraction f = new Fraction(-1, -2);
            Assert.IsTrue(f.Numerator == 1);
            Assert.IsTrue(f.Denominator == 2);
        }

        [TestMethod]
        public void FractionToStringTest()
        {
            Fraction f = new Fraction(1, 2);
            Assert.AreEqual("1/2", f.ToString(), false);
        }

        [TestMethod]
        public void NegativeFractionToStringTest()
        {
            Fraction f = new Fraction(-1, 2);
            Assert.AreEqual("-1/2", f.ToString(), false);
        }

        [TestMethod]
        public void ZeroFractionToStringTest()
        {
            Fraction f = new Fraction(0, 2);
            Assert.AreEqual("0", f.ToString(), false);
        }

        #endregion

        #region FractionCalculator Tests

        #region Add operation tests

        [TestMethod]
        public void BasicAddTest()
        {
            Fraction f1 = new Fraction(1, 2);
            Fraction f2 = new Fraction(1, 2);

            Fraction result = FractionCalculator.Add(f1, f2);
            Assert.IsTrue(result.Numerator == 1);
            Assert.IsTrue(result.Denominator == 1);
        }

        [TestMethod]
        public void ZeroAddTest()
        {
            Fraction f1 = new Fraction(0, 1);
            Fraction f2 = new Fraction(0, 1);

            Fraction result = FractionCalculator.Add(f1, f2);
            Assert.IsTrue(result.Numerator == 0);
            Assert.IsTrue(result.Denominator == 1);
        }

        [TestMethod]
        public void ZeroFractionAddTest()
        {
            Fraction f1 = new Fraction(1, 2);
            Fraction f2 = new Fraction(0, 2);

            Fraction result = FractionCalculator.Add(f1, f2);
            Assert.IsTrue(result.Numerator == 1);
            Assert.IsTrue(result.Denominator == 2);
        }

        [TestMethod]
        public void ImproperFractionAddTest()
        {
            Fraction f1 = new Fraction(3, 2);
            Fraction f2 = new Fraction(5, 3);

            Fraction result = FractionCalculator.Add(f1, f2);
            Assert.IsTrue(result.Numerator == 19);
            Assert.IsTrue(result.Denominator == 6);
        }

        [TestMethod]
        public void ReducedFractionAddTest()
        {
            Fraction f1 = new Fraction(2, 6);
            Fraction f2 = new Fraction(4, 12);

            Fraction result = FractionCalculator.Add(f1, f2);
            Assert.IsTrue(result.Numerator == 2);
            Assert.IsTrue(result.Denominator == 3);
        }

        [TestMethod]
        public void NegativeFractionAddTest()
        {
            Fraction f1 = new Fraction(1, 2);
            Fraction f2 = new Fraction(-1, 2);

            Fraction result = FractionCalculator.Add(f1, f2);
            Assert.IsTrue(result.Numerator == 0);
            Assert.IsTrue(result.Denominator == 1);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void BigFractionAddTest()
        {
            Fraction f1 = new Fraction(Int32.MaxValue, Int32.MaxValue);
            Fraction f2 = new Fraction(Int32.MaxValue, Int32.MaxValue);

            Fraction result = FractionCalculator.Add(f1, f2);
        }

        #endregion

        #region Sub operation tests

        [TestMethod]
        public void BasicSubTest()
        {
            Fraction f1 = new Fraction(2, 3);
            Fraction f2 = new Fraction(1, 2);

            Fraction result = FractionCalculator.Sub(f1, f2);
            Assert.IsTrue(result.Numerator == 1);
            Assert.IsTrue(result.Denominator == 6);
        }

        [TestMethod]
        public void ZeroSubTest()
        {
            Fraction f1 = new Fraction(0, 1);
            Fraction f2 = new Fraction(0, 1);

            Fraction result = FractionCalculator.Sub(f1, f2);
            Assert.IsTrue(result.Numerator == 0);
            Assert.IsTrue(result.Denominator == 1);
        }

        [TestMethod]
        public void ZeroFractionSubTest()
        {
            Fraction f1 = new Fraction(1, 2);
            Fraction f2 = new Fraction(0, 2);

            Fraction result = FractionCalculator.Sub(f1, f2);
            Assert.IsTrue(result.Numerator == 1);
            Assert.IsTrue(result.Denominator == 2);
        }

        [TestMethod]
        public void FractionSubFromZeroTest()
        {
            Fraction f1 = new Fraction(0, 2);
            Fraction f2 = new Fraction(1, 2);

            Fraction result = FractionCalculator.Sub(f1, f2);
            Assert.IsTrue(result.Numerator == -1);
            Assert.IsTrue(result.Denominator == 2);
        }

        [TestMethod]
        public void SubBiggerFractionTest()
        {
            Fraction f1 = new Fraction(1, 2);
            Fraction f2 = new Fraction(2, 3);

            Fraction result = FractionCalculator.Sub(f1, f2);
            Assert.IsTrue(result.Numerator == -1);
            Assert.IsTrue(result.Denominator == 6);
        }

        [TestMethod]
        public void ImproperFractionSubTest()
        {
            Fraction f1 = new Fraction(5, 2);
            Fraction f2 = new Fraction(5, 3);

            Fraction result = FractionCalculator.Sub(f1, f2);
            Assert.IsTrue(result.Numerator == 5);
            Assert.IsTrue(result.Denominator == 6);
        }

        [TestMethod]
        public void ReducedFractionSubTest()
        {
            Fraction f1 = new Fraction(5, 9);
            Fraction f2 = new Fraction(2, 8);

            Fraction result = FractionCalculator.Sub(f1, f2);
            Assert.IsTrue(result.Numerator == 11);
            Assert.IsTrue(result.Denominator == 36);
        }

        [TestMethod]
        public void NegativeFractionSubTest()
        {
            Fraction f1 = new Fraction(-1, 2);
            Fraction f2 = new Fraction(1, 2);

            Fraction result = FractionCalculator.Sub(f1, f2);
            Assert.IsTrue(result.Numerator == -1);
            Assert.IsTrue(result.Denominator == 1);
        }

        [TestMethod]
        public void ZeroResultSubTest()
        {
            Fraction f1 = new Fraction(1, 2);
            Fraction f2 = new Fraction(1, 2);

            Fraction result = FractionCalculator.Sub(f1, f2);
            Assert.IsTrue(result.Numerator == 0);
            Assert.IsTrue(result.Denominator == 1);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void BigFractionSubTest()
        {
            Fraction f1 = new Fraction(Int32.MaxValue, Int32.MaxValue - 1);
            Fraction f2 = new Fraction(Int32.MaxValue, Int32.MaxValue - 2);

            Fraction result = FractionCalculator.Sub(f1, f2);
        }

        #endregion

        #region Mul operation tests

        [TestMethod]
        public void BasicMulTest()
        {
            Fraction f1 = new Fraction(1, 2);
            Fraction f2 = new Fraction(1, 3);

            Fraction result = FractionCalculator.Mul(f1, f2);
            Assert.IsTrue(result.Numerator == 1);
            Assert.IsTrue(result.Denominator == 6);
        }

        [TestMethod]
        public void ZeroMulTest()
        {
            Fraction f1 = new Fraction(0, 1);
            Fraction f2 = new Fraction(0, 1);

            Fraction result = FractionCalculator.Mul(f1, f2);
            Assert.IsTrue(result.Numerator == 0);
            Assert.IsTrue(result.Denominator == 1);
        }

        [TestMethod]
        public void ReducedMulTest()
        {
            Fraction f1 = new Fraction(2, 6);
            Fraction f2 = new Fraction(4, 8);

            Fraction result = FractionCalculator.Mul(f1, f2);
            Assert.IsTrue(result.Numerator == 1);
            Assert.IsTrue(result.Denominator == 6);
        }

        [TestMethod]
        public void NegativeFractionMulTest()
        {
            Fraction f1 = new Fraction(-1, 2);
            Fraction f2 = new Fraction(1, 3);

            Fraction result = FractionCalculator.Mul(f1, f2);
            Assert.IsTrue(result.Numerator == -1);
            Assert.IsTrue(result.Denominator == 6);
        }

        [TestMethod]
        public void NegativeFractionsMulTest()
        {
            Fraction f1 = new Fraction(-1, 2);
            Fraction f2 = new Fraction(-1, 3);

            Fraction result = FractionCalculator.Mul(f1, f2);
            Assert.IsTrue(result.Numerator == 1);
            Assert.IsTrue(result.Denominator == 6);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void BigFractionMulTest()
        {
            Fraction f1 = new Fraction(1, Int32.MaxValue);
            Fraction f2 = new Fraction(2, Int32.MaxValue);

            Fraction result = FractionCalculator.Mul(f1, f2);
        }

        #endregion

        #region Div operation tests

        [TestMethod]
        public void BasicDivTest()
        {
            Fraction f1 = new Fraction(1, 2);
            Fraction f2 = new Fraction(1, 3);

            Fraction result = FractionCalculator.Div(f1, f2);
            Assert.IsTrue(result.Numerator == 3);
            Assert.IsTrue(result.Denominator == 2);
        }

        [TestMethod]
        [ExpectedException(typeof(DivideByZeroException))]
        public void ZeroDivTest()
        {
            Fraction f1 = new Fraction(0, 1);
            Fraction f2 = new Fraction(0, 1);

            Fraction result = FractionCalculator.Div(f1, f2);
        }

        [TestMethod]
        public void ReducedDivTest()
        {
            Fraction f1 = new Fraction(2, 6);
            Fraction f2 = new Fraction(4, 8);

            Fraction result = FractionCalculator.Div(f1, f2);
            Assert.IsTrue(result.Numerator == 2);
            Assert.IsTrue(result.Denominator == 3);
        }

        [TestMethod]
        public void NegativeFractionDivTest()
        {
            Fraction f1 = new Fraction(-1, 2);
            Fraction f2 = new Fraction(1, 3);

            Fraction result = FractionCalculator.Div(f1, f2);
            Assert.IsTrue(result.Numerator == -3);
            Assert.IsTrue(result.Denominator == 2);
        }

        [TestMethod]
        public void NegativeFractionsDivTest()
        {
            Fraction f1 = new Fraction(-1, 2);
            Fraction f2 = new Fraction(-1, 3);

            Fraction result = FractionCalculator.Div(f1, f2);
            Assert.IsTrue(result.Numerator == 3);
            Assert.IsTrue(result.Denominator == 2);
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void BigFractionDivTest()
        {
            Fraction f1 = new Fraction(2, Int32.MaxValue);
            Fraction f2 = new Fraction(3, Int32.MaxValue);

            Fraction result = FractionCalculator.Div(f1, f2);
        }

        #endregion

        #endregion
    }
}

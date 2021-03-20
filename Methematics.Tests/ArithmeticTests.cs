using System;
using Mathematics;
using Mathematics.Interfaces;
using NUnit.Framework;

namespace Methematics.Tests
{
    public class ArithmeticTests
    {
        private readonly IArithmetic _math;

        public ArithmeticTests()
        {
            _math = new Arithmetic();
        }

        [Test]
        public void Power_NegativeExponentInput_ZeroOutput()
        {
            var result = _math.TryPower(-1, -2);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Power_NegativeBaseInput_CorrectOutput()
        {
            var result = _math.TryPower(-2, 6);
            Assert.AreEqual(64, result);

            result = _math.TryPower(-2, 5);
            Assert.AreEqual(-32, result);
        }

        [Test]
        public void Power_NegativePowerWithFloatingPointInput_ZeroOutput()
        {
            var result = _math.TryPower(-1.5, 3);
            Assert.AreEqual(-3.375, result);
        }

        [Test]
        public void Power_ZeroInput_OneOutput()
        {
            var result = _math.TryPower(0, 0);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void Power_CorrectInputs_CorrectOutput()
        {
            var result = _math.TryPower(2, 3);
            Assert.AreEqual(8, result);
        }

        [Test]
        public void Power_CorrectInputWithFloatingPoint_CorrectOutput()
        {
            var result = _math.TryPower(2.3, 5);
            result = Math.Round(result, 2);
            Assert.AreEqual(64.36, result);
        }

        [Test]
        public void Round_WrongFloatPoint_NoErrorWrongOutput()
        {
            var result = _math.TryRound(2.345, -2);
            Assert.AreEqual(double.NaN, result);
        }

        [Test]
        public void Round_ZeroFloatPoint_NoErrorCorrectOutput()
        {
            var result = _math.TryRound(2.345, 0);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void Round_CorrectInput_CorrectOutput()
        {
            var result = _math.TryRound(2.3456, 2);
            Assert.AreEqual(2.35, result);

            result = _math.TryRound(2.3456, 3);
            Assert.AreEqual(2.346, result);

            result = _math.TryRound(-2.3456, 3);
            Assert.AreEqual(-2.346, result);
        }
    }
}
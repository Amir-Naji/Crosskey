using Mortgage.Interfaces;
using NUnit.Framework;

namespace Mortgage.Tests
{
    public class MathematicTests
    {
        private readonly IMathematic _math;

        public MathematicTests()
        {
            _math = new Mathematic();
        }

        [Test]
        public void Power_NegativeExponentInput_ZeroOutput()
        {
            var result = _math.Power(-1, -2);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void Power_NegativeBaseInput_CorrectOutput()
        {
            var result = _math.Power(-2, 6);
            Assert.AreEqual(64, result);

            result = _math.Power(-2, 5);
            Assert.AreEqual(-32, result);
        }

        [Test]
        public void Power_NegativePowerWithFloatingPointInput_ZeroOutput()
        {
            var result = _math.Power(-1.5, 3);
            var equal = result.Equals(-3.38);
            Assert.IsTrue(equal);
        }

        [Test]
        public void Power_ZeroInput_OneOutput()
        {
            var result = _math.Power(0, 0);
            Assert.AreEqual(1, result);
        }

        [Test]
        public void Power_CorrectInputs_CorrectOutput()
        {
            var result = _math.Power(2, 3);
            Assert.AreEqual(8, result);
        }

        [Test]
        public void Power_CorrectInputWithFloatingPoint_CorrectOutput()
        {
            var result = _math.Power(2.3, 5);
            var equal = result.Equals(64.38);
            Assert.IsTrue(equal);
        }
    }
}
using System;
using Mortgage.Interfaces;

namespace Mortgage
{
    public class Mathematic : IMathematic
    {
        public double Power(double basePower, int exponent)
        {
            return NotRoundedPower(basePower, exponent);
        }

        public double Round(double input, int digitAfterFloatingPoint)
        {
            var precision = Precision(digitAfterFloatingPoint);
            var value = input * precision;
            //value += 0.5;
            value = Convert.ToUInt64(value);
            return value / precision;
        }

        private double NotRoundedPower(double basePower, int exponent)
        {
            if (exponent < 0)
                return 0;
            if (exponent == 0)
                return 1;
            if (exponent == 1)
                return basePower;
            return Power(basePower, --exponent) * basePower;
        }

        private int Precision(int digitAfterFloatingPoint)
        {
            return Convert.ToInt32(Power(10, digitAfterFloatingPoint));
        }
    }
}
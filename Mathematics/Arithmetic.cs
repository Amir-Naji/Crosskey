using System;
using Mathematics.Interfaces;
using NLog;

namespace Mathematics
{
    public class Arithmetic : IArithmetic
    {
        private readonly Logger _logger;

        public Arithmetic()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }


        public double TryPower(double basePower, int exponent)
        {
            try
            {
                return Power(basePower, exponent);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return 0;
            }
        }

        public double TryRound(double input, int digitAfterFloatingPoint)
        {
            try
            {
                return Round(input, digitAfterFloatingPoint);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                return 0;
            }
        }

        private double Power(double basePower, int exponent)
        {
            if (exponent < 0)
                return 0;
            if (exponent == 0)
                return 1;
            if (exponent == 1)
                return basePower;
            return TryPower(basePower, --exponent) * basePower;
        }

        private double Round(double input, int digitAfterFloatingPoint)
        {
            var precision = Precision(digitAfterFloatingPoint);
            var value = input * precision;
            //value += 0.5;
            value = Convert.ToInt64(value);
            return value / precision;
        }


        private int Precision(int digitAfterFloatingPoint)
        {
            return Convert.ToInt32(TryPower(10, digitAfterFloatingPoint));
        }
    }
}
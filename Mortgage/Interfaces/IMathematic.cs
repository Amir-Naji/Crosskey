namespace Mortgage.Interfaces
{
    public interface IMathematic
    {
        double Power(double basePower, int exponent);

        double Round(double input, int digitAfterFloatingPoint);
    }
}
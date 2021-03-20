namespace Mathematics.Interfaces
{
    public interface IArithmetic
    {
        double TryPower(double basePower, int exponent);

        double TryRound(double input, int digitAfterFloatingPoint);
    }
}
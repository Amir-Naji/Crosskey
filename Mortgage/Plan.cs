using Mortgage.Interfaces;
using Repository.Models;

namespace Mortgage
{
    public class Plan : IPlan
    {
        private const int NumberOfMonthsInOneYear = 12;
        private readonly IMathematic _math;

        public Plan(IMathematic math)
        {
            _math = math;
        }

        public double FixedPayment(Customer customer)
        {
            var samePart = SamePart(MonthlyInterest(customer.Interest),
                customer.Years);

            return Calculate(customer, samePart);
        }

        private double Calculate(Customer customer, double samePart)
        {
            return customer.TotalLoan *
                   MonthlyInterest(customer.Interest) *
                   (samePart /
                    (samePart - 1));
        }


        private double SamePart(double interest, int years)
        {
            return _math.Power(1 + interest, NumberOfPayments(years));
        }

        private static int NumberOfPayments(int year)
        {
            return year * NumberOfMonthsInOneYear;
        }

        private static double MonthlyInterest(double interest)
        {
            return interest / (NumberOfMonthsInOneYear * 100);
        }
    }
}
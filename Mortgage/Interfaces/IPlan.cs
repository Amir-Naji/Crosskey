using Repository.Models;

namespace Mortgage.Interfaces
{
    public interface IPlan
    {
        double FixedPayment(Customer customer);
    }
}
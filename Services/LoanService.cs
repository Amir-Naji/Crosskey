using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mathematics.Interfaces;
using Mortgage.Interfaces;
using Repository.Interfaces;
using Repository.Models;
using Services.Interfaces;
using Services.Models;

namespace Services
{
    public class LoanService : ILoanService
    {
        private const string LoanTemplate =
            "{0} wants to borrow {1} € for period of {2} years and pay {3} € each month";

        private const string ErrorTemplate =
            "One of the values are less than zero";

        private readonly IArithmetic _arithmetic;

        private readonly IPlan _plan;
        private readonly ICustomerRepository _repository;

        public LoanService(ICustomerRepository repository, IPlan plan,
            IArithmetic arithmetic)
        {
            _arithmetic = arithmetic;
            _repository = repository;
            _plan = plan;
        }

        public async Task<List<string>> RunAsync()
        {
            var customers =
                await _repository.TryReadAsync().ConfigureAwait(false);

            return (from customer in customers
                let fixedPayment = _plan.FixedPayment(customer)
                select PopulateTemplate(customer, fixedPayment)).ToList();
        }

        public string RunAsync(Customer customer)
        {
            return CheckCustomer(customer) == ErrorMessage.None
                ? PopulateTemplate(customer, _plan.FixedPayment(customer))
                : ErrorTemplate;
        }

        private string PopulateTemplate(Customer customer,
            double fixedPayment)
        {
            return string.Format(LoanTemplate, customer.Name,
                customer.TotalLoan,
                customer.Years, _arithmetic.TryRound(fixedPayment, 2));
        }

        private static ErrorMessage CheckCustomer(Customer customer)
        {
            return AreBiggerThanZero(customer)
                ? ErrorMessage.None
                : ErrorMessage.LessThanZero;
        }


        private static bool AreBiggerThanZero(Customer customer)
        {
            return customer.TotalLoan >= 0 &&
                   customer.Years >= 0 &&
                   customer.Interest >= 0;
        }
    }
}
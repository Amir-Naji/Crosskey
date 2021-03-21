using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mathematics.Interfaces;
using Mortgage.Interfaces;
using Repository.Interfaces;
using Repository.Models;
using Services.Interfaces;

namespace Services
{
    public class LoanService : ILoanService
    {
        private const string Template =
            "{0} wants to borrow {1} € for period of {2} years and pay {3} € each month";

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
            return PopulateTemplate(customer, _plan.FixedPayment(customer));
        }

        private string PopulateTemplate(Customer customer,
            double fixedPayment)
        {
            return string.Format(Template, customer.Name, customer.TotalLoan,
                customer.Years, _arithmetic.TryRound(fixedPayment, 2));
        }
    }
}
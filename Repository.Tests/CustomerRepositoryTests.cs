using System.Threading.Tasks;
using NUnit.Framework;
using Repository.Interfaces;

namespace Repository.Tests
{
    public class CustomerRepositoryTests
    {
        private readonly ICustomerRepository _customer;

        public CustomerRepositoryTests()
        {
            _customer = new CustomerRepository("prospects.txt");
        }

        [Test]
        public async Task TryReadAsync_NoInput_CorrectListOfCustomers()
        {
            var result = await _customer.TryReadAsync().ConfigureAwait(false);
            Assert.IsNotEmpty(result);
            Assert.AreEqual(3, result.Count);
        }
    }
}
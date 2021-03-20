using System.Threading.Tasks;
using Mathematics;
using Mortgage;
using NUnit.Framework;
using Repository;
using Services.Interfaces;

namespace Services.Tests
{
    public class LoanServiceTests
    {
        private readonly ILoanService _service;

        public LoanServiceTests()
        {
            _service = new LoanService(new CustomerRepository("prospects.txt"),
                new Plan(new Arithmetic()));
        }

        [Test]
        public async Task RunAsync_NoInput_CorrectOutput()
        {
            var result = await _service.RunAsync()
                .ConfigureAwait(false);

            Assert.IsNotEmpty(result);

            var totalLoan = result.Exists(x => x.Contains("1000"));
            Assert.IsTrue(totalLoan);
        }
    }
}
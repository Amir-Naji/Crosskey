using System;
using System.Threading.Tasks;
using Mathematics;
using Mortgage;
using NUnit.Framework;
using Repository;
using Repository.Models;
using Services.Interfaces;

namespace Services.Tests
{
    public class LoanServiceTests
    {
        private const string OutputString =
            " wants to borrow 0 € for period of 0 years and pay 0 € each month";

        private readonly ILoanService _service;


        public LoanServiceTests()
        {
            var arithmetic = new Arithmetic();
            _service = new LoanService(new CustomerRepository("prospects.txt"),
                new Plan(arithmetic), arithmetic);
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

        [Test]
        public void RunAsync_NullInput_Exception()
        {
            Assert.Throws<NullReferenceException>(() =>
                _service.RunAsync(null));
        }

        [Test]
        public void RunAsync_NewObject_EverythingIsEitherEmptyOrZero()
        {
            var result = _service.RunAsync(new Customer());
            Assert.AreEqual(OutputString, result);
        }

        [Test]
        public void RunAsync_WrongCustomerInput_ErrorMessageInstead()
        {
            var result = _service.RunAsync(new Customer
            {
                Name = "Test",
                Interest = -3,
                TotalLoan = -500,
                Years = -4
            });

            var message = result.StartsWith("One of ");
            Assert.IsTrue(message);
        }

        [Test]
        public void RunAsync_CorrectCustomer_CorrectResult()
        {
            var result = _service.RunAsync(new Customer
            {
                Name = "Test",
                Interest = 4,
                TotalLoan = 1000,
                Years = 5
            });

            var message = result.StartsWith("Test wants ");
            Assert.IsTrue(message);
        }
    }
}
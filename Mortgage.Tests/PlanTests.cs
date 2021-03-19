using System;
using Mortgage.Interfaces;
using NUnit.Framework;
using Repository.Models;

namespace Mortgage.Tests
{
    public class PlanTests
    {
        private readonly IPlan _plan;

        public PlanTests()
        {
            _plan = new Plan(new Mathematic());
        }

        [Test]
        public void FixedPayment_CorrectCustomerInput_CorrectPayment()
        {
            var result = _plan.FixedPayment(new Customer
            {
                TotalLoan = 1000,
                Interest = 5,
                Years = 5
            });

            result = Math.Round(result, 2);
            Assert.AreEqual(18.87, result);
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Repository.Interfaces;
using Repository.Models;

namespace Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private const int LocationOfName = 0;
        private const int LocationOfTotalLoan = 1;
        private const int LocationOfInterest = 2;
        private const int LocationOfYears = 3;
        private readonly string _path;

        public CustomerRepository(string path)
        {
            _path = path;
        }

        public async Task<List<Customer>> TryReadAsync()
        {
            try
            {
                return await ReadAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        private async Task<List<Customer>> ReadAsync()
        {
            var lines = await File.ReadAllLinesAsync(_path)
                                  .ConfigureAwait(false);

            return ConvertToCustomers(lines);
        }

        private static List<Customer> ConvertToCustomers(string[] lines)
        {
            return lines.Select(SplitLine)
                        .ToList()
                        .Where(x => x.TotalLoan != 0)
                        .ToList();
        }

        private static Customer SplitLine(string line)
        {
            var values = line.Split(',');
            return ValidLine(values) ? CreateCustomer(values) : new Customer();
        }

        private static bool ValidLine(string[] values)
        {
            return values.Length == 4;
        }

        private static Customer CreateCustomer(string[] values)
        {
            return new Customer
            {
                Name = values[LocationOfName],
                TotalLoan = ConvertTodouble(values[LocationOfTotalLoan]),
                Interest = ConvertTodouble(values[LocationOfInterest]),
                Years = ConvertToInt(values[LocationOfYears])
            };
        }

        private static int ConvertToInt(string input)
        {
            return int.TryParse(input, out var result) ? result : 0;
        }

        private static double ConvertTodouble(string input)
        {
            return double.TryParse(input, out var result) ? result : 0;
        }
    }
}
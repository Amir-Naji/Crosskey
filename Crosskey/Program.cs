using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NLog;
using Services.Interfaces;

namespace Crosskey
{
    internal class Program
    {
        private static readonly Logger _logger;

        static Program()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        private static async Task Main()
        {
            var mainService = TryLoanService();
            var loanString = await mainService.RunAsync()
                .ConfigureAwait(false);

            Print(loanString);
        }

        private static ILoanService TryLoanService()
        {
            try
            {
                return LoanService();
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                throw;
            }
        }

        private static ILoanService LoanService()
        {
            var di = new DependencyInjection();
            var serviceProvider =
                di.ConfigureServices().BuildServiceProvider();
            return serviceProvider.GetService<ILoanService>();
        }

        private static void Print(List<string> loanString)
        {
            Console.OutputEncoding = Encoding.UTF8;
            loanString.ForEach(Console.WriteLine);
        }
    }
}
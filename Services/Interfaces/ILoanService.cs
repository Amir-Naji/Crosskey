using System.Collections.Generic;
using System.Threading.Tasks;
using Repository.Models;

namespace Services.Interfaces
{
    public interface ILoanService
    {
        Task<List<string>> RunAsync();

        string RunAsync(Customer customer);
    }
}
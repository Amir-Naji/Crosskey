using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ILoanService
    {
        Task<List<string>> RunAsync();
    }
}
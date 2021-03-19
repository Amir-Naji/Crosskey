using System.Collections.Generic;
using System.Threading.Tasks;
using Repository.Models;

namespace Repository.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> TryReadAsync();
    }
}
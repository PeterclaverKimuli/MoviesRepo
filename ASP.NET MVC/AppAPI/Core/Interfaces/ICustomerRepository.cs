using AppAPI.Core.Models;

namespace AppAPI.Core.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> Get(int id);
        Task Add(Customer customer);
        void Remove(Customer customer);
    }
}

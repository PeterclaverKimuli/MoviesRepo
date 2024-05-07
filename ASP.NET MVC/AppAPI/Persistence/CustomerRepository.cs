using AppAPI.Core.Interfaces;
using AppAPI.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace AppAPI.Persistence
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext context;

        public CustomerRepository(AppDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Creates a new customer in the Customers table.
        /// </summary>
        /// <param name="customer">The customer object to add to the Database.</param>
        public async Task Add(Customer customer)
        {
            await context.Customers.AddAsync(customer);
        }

        /// <summary>
        /// Returns a customer object from the Database.
        /// </summary>
        /// <param name="id">The Id of the customer to search.</param>
        /// <returns>A customer object.</returns>
        public async Task<Customer> Get(int id)
        {
            return await context.Customers.Include(x => x.MembershipType).SingleOrDefaultAsync();
        }

        /// <summary>
        /// Deletes a customer object from the Database
        /// </summary>
        /// <param name="customer">The customer object to delete from the Database</param>
        public void Remove(Customer customer)
        {
            context.Remove(customer);
        }
    }
}

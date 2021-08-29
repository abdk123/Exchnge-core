using Abp.Domain.Repositories;
using System.Threading.Tasks;

namespace Bwr.Exchange.Customers.Services
{
    public class CustomerManager : ICustomerManager
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerManager(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> CreateAsync(Customer customer)
        {
            var customerId = await _customerRepository.InsertAndGetIdAsync(customer);
            return await GetByIdAsync(customerId);
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _customerRepository.FirstOrDefaultAsync(id);
        }
    }
}

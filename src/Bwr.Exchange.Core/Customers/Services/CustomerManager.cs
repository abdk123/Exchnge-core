using Abp.Domain.Repositories;
using System.Collections.Generic;
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

        public async Task<IList<Customer>> GetAllAsync()
        {
            return await _customerRepository.GetAllListAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _customerRepository.FirstOrDefaultAsync(id);
        }

        public async Task<Customer> GetByNameAsync(string symbol)
        {
            return await _customerRepository.FirstOrDefaultAsync(x => x.Name.StartsWith(symbol));
        }

        public async Task<Customer> CreateOrUpdateAsync(Customer customer)
        {
            var customerId = await _customerRepository.InsertOrUpdateAndGetIdAsync(customer);
            return await GetByIdAsync(customerId);
        }
    }
}

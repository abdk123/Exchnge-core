using Abp.Domain.Services;
using System.Threading.Tasks;

namespace Bwr.Exchange.Customers.Services
{
    public interface ICustomerManager: IDomainService
    {
        Task<Customer> GetByIdAsync(int id);
        Task<Customer> CreateAsync(Customer customer);
    }
}

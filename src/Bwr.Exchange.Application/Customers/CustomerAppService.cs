using Bwr.Exchange.Customers.Dto;
using Bwr.Exchange.Customers.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bwr.Exchange.Customers
{
    public class CustomerAppService : ExchangeAppServiceBase, ICustomerAppService
    {
        private readonly ICustomerManager _customerManager;

        public CustomerAppService(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }

        public async Task<IList<CustomerDto>> GetAllAsync()
        {
            var customers = await _customerManager.GetAllAsync();
            return ObjectMapper.Map<List<CustomerDto>>(customers);
        }

        public async Task<CustomerDto> GetByNameAsync(string symbol)
        {
            var customer = await _customerManager.GetByNameAsync(symbol);
            return ObjectMapper.Map<CustomerDto>(customer);
        }

        public IList<CustomerDto> GetTreasuryActionBeneficiaries()
        {
            return new List<CustomerDto>();
        }
    }
}

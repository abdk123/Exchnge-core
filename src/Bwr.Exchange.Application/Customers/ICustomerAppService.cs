using Abp.Application.Services;
using Bwr.Exchange.Customers.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bwr.Exchange.Customers
{
    public interface ICustomerAppService : IApplicationService
    {
        IList<CustomerDto> GetTreasuryActionBeneficiaries();
        Task<IList<CustomerDto>> GetAllAsync();
        Task<CustomerDto> GetByNameAsync(string name);
    }
}

using Abp.Application.Services;
using Bwr.Exchange.Customers.Dto;
using System.Collections.Generic;

namespace Bwr.Exchange.Customers
{
    public interface ICustomerAppService : IApplicationService
    {
        IList<CustomerDto> GetTreasuryActionBeneficiaries();
    }
}

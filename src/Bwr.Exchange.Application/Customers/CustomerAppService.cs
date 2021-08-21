using Bwr.Exchange.Customers.Dto;
using System.Collections.Generic;

namespace Bwr.Exchange.Customers
{
    public class CustomerAppService : ExchangeAppServiceBase, ICustomerAppService
    {
        
        public IList<CustomerDto> GetTreasuryActionBeneficiaries()
        {
            return new List<CustomerDto>();
        }
    }
}

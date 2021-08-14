using Abp.Application.Services;
using Bwr.Exchange.CashFlows.ClientCashFlows.Dto;
using System.Collections.Generic;

namespace Bwr.Exchange.CashFlows.ClientCashFlows
{
    public interface IClientCashFlowAppService : IApplicationService
    {
        IList<ClientCashFlowDto> Get(GetClientCashFlowInput input);
    }
}

using Bwr.Exchange.CashFlows.ClientCashFlows.Dto;
using Bwr.Exchange.CashFlows.ClientCashFlows.Services;
using System.Collections.Generic;

namespace Bwr.Exchange.CashFlows.ClientCashFlows
{
    public class ClientCashFlowAppService : ExchangeAppServiceBase, IClientCashFlowAppService
    {
        private readonly IClientCashFlowManager _clientCashFlowManager;

        public ClientCashFlowAppService(IClientCashFlowManager clientCashFlowManager)
        {
            _clientCashFlowManager = clientCashFlowManager;
        }

        public IList<ClientCashFlowDto> Get(GetClientCashFlowInput input)
        {
            var clientCashFlows = _clientCashFlowManager.Get(input.ClientId);
            var clientCashFlowsDto = ObjectMapper.Map<List<ClientCashFlowDto>>(clientCashFlows);
            return clientCashFlowsDto;
        }
    }
}

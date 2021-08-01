using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using Bwr.Exchange.CashFlows.ClientCashFlows.Services;
using System;
using System.Threading.Tasks;

namespace Bwr.Exchange.CashFlows.ClientCashFlows.Events
{
    public class ClientCashFlowCreatedHandler : IAsyncEventHandler<ClientCashFlowCreatedEventData>, ITransientDependency
    {
        private readonly IClientCashFlowManager _clientCashFlowManager;

        public ClientCashFlowCreatedHandler(IClientCashFlowManager clientCashFlowManager)
        {
            _clientCashFlowManager = clientCashFlowManager;
        }

        public async Task HandleEventAsync(ClientCashFlowCreatedEventData eventData)
        {
            var clientCashFlow = new ClientCashFlow(
                eventData.Date, 
                eventData.Amount, 
                eventData.TransactionId, 
                eventData.Type, 
                eventData.Commission, 
                eventData.ClientCommission);

            await _clientCashFlowManager.Create(clientCashFlow);
        }
    }
}

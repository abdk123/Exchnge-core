﻿using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using Bwr.Exchange.CashFlows.ClientCashFlows.Services;
using System.Threading.Tasks;

namespace Bwr.Exchange.CashFlows.ClientCashFlows.Events
{
    public class ClientCashFlowCreatedEventHandler : IAsyncEventHandler<ClientCashFlowCreatedEventData>, ITransientDependency
    {
        private readonly IClientCashFlowManager _clientCashFlowManager;

        public ClientCashFlowCreatedEventHandler(IClientCashFlowManager clientCashFlowManager)
        {
            _clientCashFlowManager = clientCashFlowManager;
        }

        public async Task HandleEventAsync(ClientCashFlowCreatedEventData eventData)
        {
            var clientCashFlow = new ClientCashFlow()
            {
                Date = eventData.Date,
                Amount = eventData.Amount,
                Transaction = new Transaction(eventData.TransactionId, eventData.Type),
                Commission = eventData.Commission,
                ClientCommission = eventData.ClientCommission
            };
                

            await _clientCashFlowManager.Create(clientCashFlow);
        }
    }
}
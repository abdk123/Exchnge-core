using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using Bwr.Exchange.CashFlows.ClientCashFlows.Services;
using Bwr.Exchange.Settings.Clients.Services;
using System.Threading.Tasks;

namespace Bwr.Exchange.CashFlows.ClientCashFlows.Events
{
    public class ClientCashFlowCreatedEventHandler : IAsyncEventHandler<ClientCashFlowCreatedEventData>, ITransientDependency
    {
        private readonly IClientCashFlowManager _clientCashFlowManager;
        private readonly IClientManager _clientManager;

        public ClientCashFlowCreatedEventHandler(
            IClientCashFlowManager clientCashFlowManager,
            IClientManager clientManager
            )
        {
            _clientCashFlowManager = clientCashFlowManager;
            _clientManager = clientManager;
        }

        public async Task HandleEventAsync(ClientCashFlowCreatedEventData eventData)
        {
            var previousBalance = await GetPreviousBalance(eventData.ClientId.Value, eventData.CurrencyId.Value);
            var clientCashFlow = new ClientCashFlow()
            {
                ClientId = eventData.ClientId.Value,
                CurrencyId = eventData.CurrencyId.Value,
                Date = eventData.Date,
                Amount = eventData.Amount,
                Note = eventData.Note,
                Type = eventData.Type,
                CurrentBalance = previousBalance + eventData.Amount,
                TransactionId = eventData.TransactionId,
                TransactionType = eventData.TransactionType,
                Commission = eventData.Commission,
                ClientCommission = eventData.ClientCommission
            };

            await _clientCashFlowManager.Create(clientCashFlow);
        }

        private async Task<double> GetPreviousBalance(int clientId, int currencyId)
        {
            var previousClientBalance = await _clientCashFlowManager.GetLastAsync(clientId, currencyId);
            if (previousClientBalance != null)
            {
                return previousClientBalance.CurrentBalance;
            }
            else
            {
                var clientBalance = _clientManager.GetClientBalance(clientId, currencyId);
                if (clientBalance != null)
                    return clientBalance.Balance;
            }

            return 0.0;
        }
    }
}

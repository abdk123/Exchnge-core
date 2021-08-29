using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using Bwr.Exchange.CashFlows.CompanyCashFlows.Services;
using Bwr.Exchange.Settings.Companies.Services;
using System.Threading.Tasks;

namespace Bwr.Exchange.CashFlows.CompanyCashFlows.Events
{
    public class CompanyCashFlowCreatedEventHandler : IAsyncEventHandler<CompanyCashFlowCreatedEventData>, ITransientDependency
    {
        private readonly ICompanyCashFlowManager _clientCashFlowManager;
        private readonly ICompanyManager _clientManager;

        public CompanyCashFlowCreatedEventHandler(
            ICompanyCashFlowManager clientCashFlowManager,
            ICompanyManager clientManager
            )
        {
            _clientCashFlowManager = clientCashFlowManager;
            _clientManager = clientManager;
        }

        public async Task HandleEventAsync(CompanyCashFlowCreatedEventData eventData)
        {
            var previousBalance = await GetPreviousBalance(eventData.CompanyId.Value, eventData.CurrencyId.Value);
            var clientCashFlow = new CompanyCashFlow()
            {
                CompanyId = eventData.CompanyId.Value,
                CurrencyId = eventData.CurrencyId.Value,
                Date = eventData.Date,
                Amount = eventData.Amount,
                Note = eventData.Note,
                Type = eventData.Type,
                CurrentBalance = previousBalance + eventData.Amount + eventData.CompanyCommission + eventData.Commission,
                TransactionId = eventData.TransactionId,
                TransactionType = eventData.TransactionType,
                Commission = eventData.Commission,
                CompanyCommission = eventData.CompanyCommission,
                Destination = eventData.Destination,
                Sender = eventData.Sender,
                Beneficiary = eventData.Beneficiary
            };

            await _clientCashFlowManager.Create(clientCashFlow);
        }

        private async Task<double> GetPreviousBalance(int clientId, int currencyId)
        {
            var previousCompanyBalance = await _clientCashFlowManager.GetLastAsync(clientId, currencyId);
            if (previousCompanyBalance != null)
            {
                return previousCompanyBalance.CurrentBalance;
            }
            else
            {
                var clientBalance = _clientManager.GetCompanyBalance(clientId, currencyId);
                if (clientBalance != null)
                    return clientBalance.Balance;
            }

            return 0.0;
        }
    }
}

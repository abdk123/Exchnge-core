using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using Bwr.Exchange.CashFlows.TreasuryCashFlows.Services;
using Bwr.Exchange.Settings.Treasuries.Services;
using System.Threading.Tasks;

namespace Bwr.Exchange.CashFlows.TreasuryCashFlows.Events
{
    public class TreasuryCashFlowCreatedEventHandler : IAsyncEventHandler<TreasuryCashFlowCreatedEventData>, ITransientDependency
    {

        private readonly ITreasuryCashFlowManager _treasuryCashFlowManager;
        private readonly ITreasuryBalanceManager _treasuryBalanceManager;

        public TreasuryCashFlowCreatedEventHandler(
            ITreasuryCashFlowManager treasuryCashFlowManager,
            ITreasuryBalanceManager treasuryBalanceManager
            )
        {
            _treasuryCashFlowManager = treasuryCashFlowManager;
            _treasuryBalanceManager = treasuryBalanceManager;
        }

        public async Task HandleEventAsync(TreasuryCashFlowCreatedEventData eventData)
        {
            var previousBalance = await GetPreviousBalance(eventData.TreasuryId.Value, eventData.CurrencyId.Value);
            var treasuryCashFlow = new TreasuryCashFlow()
            {
                Date = eventData.Date,
                Amount = eventData.Amount,
                CurrentBalance = previousBalance + eventData.Amount,
                CurrencyId = eventData.CurrencyId.Value,
                TreasuryId = eventData.TreasuryId.Value,
                TransactionId = eventData.TransactionId,
                TransactionType = eventData.TransactionType,
                Type = eventData.Type,
                Note = eventData.Note,
                Name = eventData.Name,
                Destination = eventData.Destination,
                Sender = eventData.Sender,
                Beneficiary = eventData.Beneficiary
            };

            await _treasuryCashFlowManager.CreateAsync(treasuryCashFlow);
        }

        private async Task<double> GetPreviousBalance(int treasuryId, int currencyId)
        {
            var previousTreasuryBalance = await _treasuryCashFlowManager.GetLastAsync(treasuryId, currencyId);
            if (previousTreasuryBalance != null)
            {
                return previousTreasuryBalance.CurrentBalance;
            }
            else
            {
                var treasuryBalance = _treasuryBalanceManager.GetByTreasuryIdAndCurrency(treasuryId, currencyId);
                if (treasuryBalance != null)
                    return treasuryBalance.InitilBalance;
            }

            return 0.0;
        }
    }
}

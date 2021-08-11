using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using Bwr.Exchange.CashFlows.TreasuryCashFlows.Services;
using Bwr.Exchange.Settings.Treasuries.Services;
using System;
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
            var treasuryBalance = _treasuryBalanceManager.GetByTreasuryIdAndCurrency(eventData.TreasuryId.Value, eventData.CurrencyId.Value);

            var treasuryCashFlow = new TreasuryCashFlow()
            {
                Date = eventData.Date,
                Amount = eventData.Amount,
                TreasuryBalance = treasuryBalance,
                TreasuryBalanceId = treasuryBalance.Id,
                Transaction = new Transaction(eventData.TransactionId, eventData.TransactionType),
                Type = eventData.Type,
                Note = eventData.Note,
                Name = eventData.Name
            };

            await _treasuryCashFlowManager.CreateAsync(treasuryCashFlow);
        }
    }
}

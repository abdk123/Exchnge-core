using Abp.Dependency;
using Abp.Events.Bus.Handlers;
using Bwr.Exchange.CashFlows.CompanyCashFlows.Services;
using System;
using System.Threading.Tasks;

namespace Bwr.Exchange.CashFlows.CompanyCashFlows.Events
{
    public class CompanyCashFlowCreatedHandler : IAsyncEventHandler<CompanyCashFlowCreatedEventData>, ITransientDependency
    {
        private readonly ICompanyCashFlowManager _companyCashFlowManager;

        public CompanyCashFlowCreatedHandler(ICompanyCashFlowManager companyCashFlowManager)
        {
            _companyCashFlowManager = companyCashFlowManager;
        }

        public async Task HandleEventAsync(CompanyCashFlowCreatedEventData eventData)
        {

            var companyCashFlow = new CompanyCashFlow()
            {
                Date = eventData.Date,
                Amount = eventData.Amount,
                Transaction = new Transaction(eventData.TransactionId, eventData.Type),
                Commission = eventData.Commission,
                CompanyCommission = eventData.CompanyCommission
            };

            await _companyCashFlowManager.Create(companyCashFlow);
        }
    }
}

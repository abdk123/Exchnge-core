using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Domain.Uow;
using Abp.Events.Bus;
using Bwr.Exchange.CashFlows.TreasuryCashFlows.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bwr.Exchange.TreasuryActions.Services.Implement
{
    public class ExpenseFromTreasuryDomainService : ITreasuryActionDomainService
    {
        private readonly IRepository<TreasuryAction> _treasuryActionRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private IEventBus EventBus { get; set; }
        public TreasuryAction TreasuryAction { get; set; }

        public ExpenseFromTreasuryDomainService(
            IRepository<TreasuryAction> treasuryActionRepository,
            IUnitOfWorkManager unitOfWorkManager,
            TreasuryAction treasuryAction
            )
        {
            _treasuryActionRepository = treasuryActionRepository;
            _unitOfWorkManager = unitOfWorkManager;
            TreasuryAction = treasuryAction;
        }

        public async Task<TreasuryAction> CreateTreasuryActionAsync()
        {
            int treasuryActionId;
            using (var unitOfWork = _unitOfWorkManager.Begin())
            {
                TreasuryAction.Date = DateTime.Now;
                treasuryActionId = await _treasuryActionRepository.InsertAndGetIdAsync(TreasuryAction);
                EventBus.Trigger(
                    new TreasuryCashFlowCreatedEventData(
                        TreasuryAction.Date,
                        TreasuryAction.CurrencyId,
                        TreasuryAction.TreasuryId,
                        treasuryActionId,
                        CashFlows.TransactionType.TreasuryAction,
                        TreasuryAction.Amount,
                        TransactionConst.GeneralExpenses,
                        TreasuryAction.Expense.Name,
                        string.Empty
                        ));

                unitOfWork.Complete();
            }
            return _treasuryActionRepository.FirstOrDefault(treasuryActionId);
        }
    }
}

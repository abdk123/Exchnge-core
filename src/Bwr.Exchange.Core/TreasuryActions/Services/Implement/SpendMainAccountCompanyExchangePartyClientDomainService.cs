﻿using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Events.Bus;
using Bwr.Exchange.CashFlows.ClientCashFlows.Events;
using Bwr.Exchange.CashFlows.CompanyCashFlows.Events;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Bwr.Exchange.TreasuryActions.Services.Implement
{
    public class SpendMainAccountCompanyExchangePartyClientDomainService : ITreasuryActionDomainService
    {
        private readonly IRepository<TreasuryAction> _treasuryActionRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        public TreasuryAction TreasuryAction { get; set; }

        public SpendMainAccountCompanyExchangePartyClientDomainService(
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

                TreasuryAction = GetByIdWithDetail(treasuryActionId);

                EventBus.Default.Trigger(
                    new ClientCashFlowCreatedEventData(
                        TreasuryAction.Date,
                        TreasuryAction.CurrencyId,
                        TreasuryAction.ExchangePartyClientId,
                        treasuryActionId,
                        CashFlows.TransactionType.TreasuryAction,
                        (TreasuryAction.Amount * -1),
                        TransactionConst.ReceiptFromHim,
                        0.0,
                        TreasuryAction.InstrumentNo,
                        0.0,
                        TreasuryAction.MainAccountCompany.Name
                        ));

                EventBus.Default.Trigger(
                    new CompanyCashFlowCreatedEventData(
                        TreasuryAction.Date,
                        TreasuryAction.CurrencyId,
                        TreasuryAction.MainAccountCompanyId,
                        treasuryActionId,
                        CashFlows.TransactionType.TreasuryAction,
                        TreasuryAction.Amount,
                        TransactionConst.Spend,
                        0.0,
                        TreasuryAction.InstrumentNo,
                        0.0,
                        TreasuryAction.ExchangePartyClient.Name
                        ));

                unitOfWork.Complete();
            }
            return TreasuryAction;
        }

        private TreasuryAction GetByIdWithDetail(int id)
        {
            return _treasuryActionRepository.
                GetAllIncluding(
                    m => m.MainAccountCompany,
                    e => e.ExchangePartyClient)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}

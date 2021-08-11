using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.Domain.Uow;
using Bwr.Exchange.TreasuryActions.Services;
using Bwr.Exchange.TreasuryActions.Services.Implement;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bwr.Exchange.TreasuryActions.Factories
{
    public class TreasuryActionFactory : ITreasuryActionFactory
    {
        private readonly IRepository<TreasuryAction> _treasuryActionRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        
        public TreasuryActionFactory(
            IRepository<TreasuryAction> treasuryActionRepository,
            IUnitOfWorkManager unitOfWorkManager
            )
        {
            
            _treasuryActionRepository = treasuryActionRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }
        public ITreasuryActionDomainService CreateService(TreasuryAction input)
        {
            if (input.ActionType == TreasuryActionType.Spend)
            {
                if(input.ExpenseId != null && input.TreasuryId != null)
                    return new ExpenseFromTreasuryDomainService(_treasuryActionRepository, _unitOfWorkManager, input);
            }

            return null;
        }
    }
}

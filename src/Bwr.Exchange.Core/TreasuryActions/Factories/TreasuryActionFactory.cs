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
            //صرف
            if (input.ActionType == TreasuryActionType.Spend)
            {
                //الحساب الرئيسي مصاريف عامة وجهة الصرف الصندوق
                if(input.MainAccount == MainAccountType.Expense && input.TreasuryId != null)
                    return new SpendMainAccountExpensesExchangePartyTreasuryDomainService(_treasuryActionRepository, _unitOfWorkManager, input);
                //الحساب الرئيسي ذمم عملاء وجهة الصرف الصندوق
                if (input.MainAccount == MainAccountType.ClientReceivables && input.TreasuryId != null)
                    return new SpendMainAccountClientExchangePartyTreasuryDomainService(_treasuryActionRepository, _unitOfWorkManager, input);

                //الحساب الرئيسي ذمم شركات وجهة الصرف الصندوق
                if (input.MainAccount == MainAccountType.CompanyReceivables && input.TreasuryId != null)
                    return new SpendMainAccountCompanyExchangePartyTreasuryDomainService(_treasuryActionRepository, _unitOfWorkManager, input);
            }

            //قبض
            if (input.ActionType == TreasuryActionType.Receipt)
            {
                //الحساب الرئيسي إيرادات عامة وجهة الصرف الصندوق
                if (input.IncomeId != null && input.TreasuryId != null)
                    return new ReceiptMainAccountIncomesExchangePartyTreasuryDomainService(_treasuryActionRepository, _unitOfWorkManager, input);

                //الحساب الرئيسي ذمم عملاء وجهة الصرف الصندوق
                if (input.MainAccount == MainAccountType.ClientReceivables && input.TreasuryId != null)
                    return new ReceiptMainAccountClientExchangePartyTreasuryDomainService(_treasuryActionRepository, _unitOfWorkManager, input);

                //الحساب الرئيسي ذمم شركات وجهة الصرف الصندوق
                if (input.MainAccount == MainAccountType.CompanyReceivables && input.TreasuryId != null)
                    return new ReceiptMainAccountCompanyExchangePartyTreasuryDomainService(_treasuryActionRepository, _unitOfWorkManager, input);

            }

            return null;
        }
    }
}

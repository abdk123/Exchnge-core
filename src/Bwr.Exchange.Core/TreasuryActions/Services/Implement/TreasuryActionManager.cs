using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Events.Bus;
using Bwr.Exchange.TreasuryActions.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bwr.Exchange.TreasuryActions.Services
{
    public class TreasuryActionManager : ITreasuryActionManager
    {
        private readonly ITreasuryActionFactory _treasuryActionFactory;
        public TreasuryActionManager(
            ITreasuryActionFactory treasuryActionFactory
            )
        {
            _treasuryActionFactory = treasuryActionFactory;
        }

        public async Task<TreasuryAction> CreateAsync(TreasuryAction input)
        {
            ITreasuryActionDomainService service = _treasuryActionFactory.CreateService(input);
            return await service.CreateTreasuryActionAsync();
        }

    }
}

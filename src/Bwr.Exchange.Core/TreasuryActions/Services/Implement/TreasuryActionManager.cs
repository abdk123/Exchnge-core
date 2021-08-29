using Bwr.Exchange.TreasuryActions.Factories;
using System;
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
            //Date and time
            var currentDate = DateTime.Now;
            input.Date = new DateTime(
                input.Date.Year,
                input.Date.Month,
                input.Date.Day,
                currentDate.Hour,
                currentDate.Minute,
                currentDate.Second
                );

            ITreasuryActionDomainService service = _treasuryActionFactory.CreateService(input);
            return await service.CreateTreasuryActionAsync();
        }

    }
}

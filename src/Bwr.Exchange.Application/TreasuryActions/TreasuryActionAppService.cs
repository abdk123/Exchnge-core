using Bwr.Exchange.TreasuryActions.Dto;
using Bwr.Exchange.TreasuryActions.Services;
using System.Threading.Tasks;

namespace Bwr.Exchange.TreasuryActions
{
    public class TreasuryActionAppService : ExchangeAppServiceBase, ITreasuryActionAppService
    {
        private readonly ITreasuryActionManager _treasuryActionManager;

        public TreasuryActionAppService(ITreasuryActionManager treasuryActionManager)
        {
            _treasuryActionManager = treasuryActionManager;
        }

        public async Task<TreasuryActionDto> CreateAsync(TreasuryActionDto input)
        {
            var treasuryAction = ObjectMapper.Map<TreasuryAction>(input);
            var createdTreasuryAction = await _treasuryActionManager.CreateAsync(treasuryAction);
            return ObjectMapper.Map<TreasuryActionDto>(createdTreasuryAction);
        }

    }
}

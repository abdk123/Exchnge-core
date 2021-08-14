using Bwr.Exchange.CashFlows.TreasuryCashFlows.Dto;
using Bwr.Exchange.CashFlows.TreasuryCashFlows.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bwr.Exchange.CashFlows.TreasuryCashFlows
{
    public class TreasuryCashFlowAppService : ExchangeAppServiceBase, ITreasuryCashFlowAppService
    {
        private readonly ITreasuryCashFlowManager _treasuryCashFlowManager;

        public TreasuryCashFlowAppService(ITreasuryCashFlowManager treasuryCashFlowManager)
        {
            _treasuryCashFlowManager = treasuryCashFlowManager;
        }

        public IList<TreasuryCashFlowDto> Get(GetTreasuryCashFlowInput input)
        {
            var treasuryCashFlows = _treasuryCashFlowManager.Get(input.TreasuryId);
            var treasuryCashFlowsDto = ObjectMapper.Map<List<TreasuryCashFlowDto>>(treasuryCashFlows);
            return treasuryCashFlowsDto;
        }
    }
}

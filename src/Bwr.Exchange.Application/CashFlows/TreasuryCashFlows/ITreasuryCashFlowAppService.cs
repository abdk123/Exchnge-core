using Abp.Application.Services;
using Bwr.Exchange.CashFlows.TreasuryCashFlows.Dto;
using System.Collections.Generic;

namespace Bwr.Exchange.CashFlows.TreasuryCashFlows
{
    public interface ITreasuryCashFlowAppService : IApplicationService
    {
        IList<TreasuryCashFlowDto> Get(GetTreasuryCashFlowInput input);
    }
}

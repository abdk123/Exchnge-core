using Abp.Application.Services;
using Bwr.Exchange.CashFlows.TreasuryCashFlows.Dto;
using Bwr.Exchange.Shared.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Collections.Generic;

namespace Bwr.Exchange.CashFlows.TreasuryCashFlows
{
    public interface ITreasuryCashFlowAppService : IApplicationService
    {
        IList<TreasuryCashFlowDto> Get(GetTreasuryCashFlowInput input);
        ReadGrudDto GetForGrid([FromBody] DataManagerRequest dm);
    }
}

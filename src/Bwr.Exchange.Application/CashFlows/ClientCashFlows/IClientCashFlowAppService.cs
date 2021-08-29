using Abp.Application.Services;
using Bwr.Exchange.CashFlows.ClientCashFlows.Dto;
using Bwr.Exchange.Shared.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Collections.Generic;

namespace Bwr.Exchange.CashFlows.ClientCashFlows
{
    public interface IClientCashFlowAppService : IApplicationService
    {
        IList<ClientCashFlowDto> Get(GetClientCashFlowInput input);
        ReadGrudDto GetForGrid([FromBody] DataManagerRequest dm);
    }
}

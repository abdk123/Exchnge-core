using Abp.Application.Services;
using Bwr.Exchange.CashFlows.CompanyCashFlows.Dto;
using Bwr.Exchange.Shared.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System.Collections.Generic;

namespace Bwr.Exchange.CashFlows.CompanyCashFlows
{
    public interface ICompanyCashFlowAppService : IApplicationService
    {
        IList<CompanyCashFlowDto> Get(GetCompanyCashFlowInput input);
        ReadGrudDto GetForGrid([FromBody] DataManagerRequest dm);
    }
}

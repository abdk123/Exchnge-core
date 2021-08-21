using Abp.Application.Services;
using Bwr.Exchange.TreasuryActions.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bwr.Exchange.TreasuryActions
{
    public interface ITreasuryActionAppService : IApplicationService
    {
        Task<TreasuryActionDto> CreateAsync(TreasuryActionDto input);
        Task<IList<ExchangePartyDto>> GetExchangeParties();
    }
}

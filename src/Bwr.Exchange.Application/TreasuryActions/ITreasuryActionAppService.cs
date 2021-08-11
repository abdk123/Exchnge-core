using Abp.Application.Services;
using Bwr.Exchange.TreasuryActions.Dto;
using System.Threading.Tasks;

namespace Bwr.Exchange.TreasuryActions
{
    public interface ITreasuryActionAppService : IApplicationService
    {
        Task<TreasuryActionDto> CreateAsync(TreasuryActionDto input);
    }
}

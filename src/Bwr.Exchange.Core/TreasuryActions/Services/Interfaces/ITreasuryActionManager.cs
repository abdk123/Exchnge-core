using Abp.Domain.Services;
using System.Threading.Tasks;

namespace Bwr.Exchange.TreasuryActions.Services
{
    public interface ITreasuryActionManager : IDomainService
    {
        Task<TreasuryAction> CreateAsync(TreasuryAction input);
    }
}

using Abp.Domain.Services;
using System.Threading.Tasks;

namespace Bwr.Exchange.Settings.Treasuries.Services
{
    public interface ITreasuryManager : IDomainService
    {
        Task<Treasury> GetTreasuryAsync();
    }
}

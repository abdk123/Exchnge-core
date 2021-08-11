using Abp.Domain.Services;
using System.Threading.Tasks;

namespace Bwr.Exchange.CashFlows.TreasuryCashFlows.Services
{
    public interface ITreasuryCashFlowManager : IDomainService
    {
        Task CreateAsync(TreasuryCashFlow input);
    }
}

using Abp.Domain.Services;
using System.Threading.Tasks;

namespace Bwr.Exchange.CashFlows.ClientCashFlows.Services
{
    public interface IClientCashFlowManager : IDomainService
    {
        Task Create(ClientCashFlow input);
    }
}

using Abp.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bwr.Exchange.CashFlows.ClientCashFlows.Services
{
    public interface IClientCashFlowManager : IDomainService
    {
        Task Create(ClientCashFlow input);
        Task<ClientCashFlow> GetLastAsync(int clientId, int currencyId);
        IList<ClientCashFlow> Get(int client);
    }
}

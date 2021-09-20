using Abp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bwr.Exchange.CashFlows.ClientCashFlows.Services
{
    public interface IClientCashFlowManager : IDomainService
    {
        Task Create(ClientCashFlow input);
        Task<ClientCashFlow> GetLastAsync(int clientId, int currencyId);
        Task<ClientCashFlow> GetByTransctionInfo(int transactionId, int transactionType);
        IList<ClientCashFlow> Get(int client);
        IList<ClientCashFlow> Get(int clientId, int currencyId, DateTime fromDate, DateTime toDate);
        double GetPreviousBalance(int clientId, int currencyId, DateTime date);
    }
}

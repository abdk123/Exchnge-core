using Abp.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bwr.Exchange.CashFlows.ClientCashFlows.Services
{
    public class ClientCashFlowManager : IClientCashFlowManager
    {
        private readonly IRepository<ClientCashFlow> _clientCashFlowRepository;

        public ClientCashFlowManager(IRepository<ClientCashFlow> clientCashFlowRepository)
        {
            _clientCashFlowRepository = clientCashFlowRepository;
        }

        public async Task Create(ClientCashFlow input)
        {
            await _clientCashFlowRepository.InsertAsync(input);
        }

        public IList<ClientCashFlow> Get(int clientId)
        {
            var clientCashFlows = _clientCashFlowRepository
                .GetAllIncluding(
                cu => cu.Currency,
                tr => tr.Client)
                .Where(x => x.ClientId == clientId);
            return clientCashFlows.ToList();
        }

        public async Task<ClientCashFlow> GetLastAsync(int clientId, int currencyId)
        {
            ClientCashFlow clientCashFlow = null;
            var clientCashFlows = await _clientCashFlowRepository
                .GetAllListAsync(x => x.ClientId == clientId && x.CurrencyId == currencyId);
            if (clientCashFlows.Any())
            {
                clientCashFlow = clientCashFlows.OrderByDescending(x => x.Id).FirstOrDefault();
            }
            return clientCashFlow;
        }
    }
}

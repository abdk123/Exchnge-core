using Abp.Domain.Repositories;
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
    }
}

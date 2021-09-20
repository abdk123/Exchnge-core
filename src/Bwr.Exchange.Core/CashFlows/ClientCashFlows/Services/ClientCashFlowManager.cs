using Abp.Domain.Repositories;
using Bwr.Exchange.Settings.Clients.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bwr.Exchange.CashFlows.ClientCashFlows.Services
{
    public class ClientCashFlowManager : IClientCashFlowManager
    {
        private readonly IRepository<ClientCashFlow> _clientCashFlowRepository;
        private readonly IClientManager _clientManager;
        public ClientCashFlowManager(
            IRepository<ClientCashFlow> clientCashFlowRepository,
            IClientManager clientManager
            )
        {
            _clientCashFlowRepository = clientCashFlowRepository;
            _clientManager = clientManager;
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

        public IList<ClientCashFlow> Get(int clientId, int currencyId, DateTime fromDate, DateTime toDate)
        {
            var clientCashFlows = _clientCashFlowRepository.GetAllIncluding(
                cu => cu.Currency,
                tr => tr.Client)
                .Where(x =>
                x.ClientId == clientId &&
                x.CurrencyId == currencyId &&
                x.Date >= fromDate &&
                x.Date <= toDate);

            return clientCashFlows.ToList();
        }

        public async Task<ClientCashFlow> GetByTransctionInfo(int transactionId, int transactionType)
        {
            return await _clientCashFlowRepository.FirstOrDefaultAsync(x =>
                x.TransactionId == transactionId &&
                x.TransactionType == (TransactionType)transactionType
            );
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

        public double GetPreviousBalance(int clientId, int currencyId, DateTime date)
        {
            double balance = 0.0;
            var clientCashFlows = _clientCashFlowRepository
                .GetAllList(x => x.ClientId == clientId && x.CurrencyId == currencyId && x.Date < date);

            if (clientCashFlows.Any())
            {
                balance = clientCashFlows.OrderByDescending(x => x.Id).FirstOrDefault().CurrentBalance;
            }
            else
            {
                var clientBalance = _clientManager.GetClientBalance(clientId, currencyId);
                balance = clientBalance != null ? clientBalance.Balance : 0.0;
            }

            return balance;
        }
    }


}

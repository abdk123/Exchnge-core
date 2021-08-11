using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bwr.Exchange.CashFlows.TreasuryCashFlows.Services
{
    public class TreasuryCashFlowManager : ITreasuryCashFlowManager
    {
        private readonly IRepository<TreasuryCashFlow> _treasuryCashFlowRepository;

        public TreasuryCashFlowManager(IRepository<TreasuryCashFlow> treasuryCashFlowRepository)
        {
            _treasuryCashFlowRepository = treasuryCashFlowRepository;
        }

        public async Task CreateAsync(TreasuryCashFlow input)
        {
            await _treasuryCashFlowRepository.InsertAsync(input);
        }
    }
}
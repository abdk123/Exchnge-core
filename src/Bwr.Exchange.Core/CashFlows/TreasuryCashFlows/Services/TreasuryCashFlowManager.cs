using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IList<TreasuryCashFlow> Get(int treasuryId)
        {
            var treasuryCashFlows = _treasuryCashFlowRepository
                .GetAllIncluding(
                cu => cu.Currency,
                tr => tr.Treasury).Where(tcf => tcf.TreasuryId == treasuryId);
            return treasuryCashFlows.ToList();
        }

        public IList<TreasuryCashFlow> Get(int treasuryId, int currencyId, DateTime fromDate, DateTime toDate)
        {
            var treasuryCashFlows = _treasuryCashFlowRepository.GetAllIncluding(
                cu => cu.Currency,
                tr => tr.Treasury)
                .Where(x =>
                x.TreasuryId == treasuryId &&
                x.CurrencyId == currencyId &&
                x.Date >= fromDate &&
                x.Date <= toDate);

            return treasuryCashFlows.ToList();
        }

        public async Task<TreasuryCashFlow> GetLastAsync(int treasuryId, int currencyId)
        {
            TreasuryCashFlow treasuryCashFlow = null;
            var treasuryCashFlows = await _treasuryCashFlowRepository
                .GetAllListAsync(x => x.TreasuryId == treasuryId && x.CurrencyId == currencyId);
            if (treasuryCashFlows.Any())
            {
                treasuryCashFlow = treasuryCashFlows.OrderByDescending(x => x.Id).FirstOrDefault();
            }
            return treasuryCashFlow;
        }
    }
}
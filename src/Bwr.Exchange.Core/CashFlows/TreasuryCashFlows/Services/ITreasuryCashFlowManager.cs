﻿using Abp.Domain.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bwr.Exchange.CashFlows.TreasuryCashFlows.Services
{
    public interface ITreasuryCashFlowManager : IDomainService
    {
        Task CreateAsync(TreasuryCashFlow input);
        Task<TreasuryCashFlow> GetLastAsync(int treasuryId, int currencyId);
        IList<TreasuryCashFlow> Get(int treasuryId);
    }
}

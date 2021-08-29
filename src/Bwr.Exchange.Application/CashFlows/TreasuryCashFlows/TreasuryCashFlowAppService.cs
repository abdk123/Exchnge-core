using Abp.Threading;
using Abp.UI;
using Bwr.Exchange.CashFlows.TreasuryCashFlows.Dto;
using Bwr.Exchange.CashFlows.TreasuryCashFlows.Services;
using Bwr.Exchange.Settings.Treasuries.Services;
using Bwr.Exchange.Shared.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Bwr.Exchange.CashFlows.TreasuryCashFlows
{
    public class TreasuryCashFlowAppService : ExchangeAppServiceBase, ITreasuryCashFlowAppService
    {
        private readonly ITreasuryCashFlowManager _treasuryCashFlowManager;
        private readonly ITreasuryManager _treasuryManager;

        public TreasuryCashFlowAppService(
            ITreasuryCashFlowManager treasuryCashFlowManager,
            ITreasuryManager treasuryManager
            )
        {
            _treasuryCashFlowManager = treasuryCashFlowManager;
            _treasuryManager = treasuryManager;
        }

        public IList<TreasuryCashFlowDto> Get(GetTreasuryCashFlowInput input)
        {
            var treasury = AsyncHelper.RunSync(_treasuryManager.GetTreasuryAsync);
            var treasuryCashFlows = _treasuryCashFlowManager.Get(input.TreasuryId, input.CurrencyId, input.FromDate, input.ToDate);
            var treasuryCashFlowsDto = ObjectMapper.Map<List<TreasuryCashFlowDto>>(treasuryCashFlows);
            return treasuryCashFlowsDto;
        }

        [HttpPost]
        public ReadGrudDto GetForGrid([FromBody] DataManagerRequest dm)
        {
            var treasury = AsyncHelper.RunSync(_treasuryManager.GetTreasuryAsync);
            if (treasury == null)
            {
                throw new UserFriendlyException(L(ValidationResultMessage.YouMustCreateTreasuryFirst));
            }

            int currencyId = 0;
            DateTime fromDate = new DateTime(), toDate = new DateTime();
            if (dm.Where != null)
            {
                var currencyFilter = GetWhereFilter(dm.Where, "currencyId");
                if (currencyFilter != null)
                {
                    int.TryParse(currencyFilter.value.ToString(), out currencyId);
                }

                var fromDateFilter = GetWhereFilter(dm.Where, "fromDate");
                if (fromDateFilter != null)
                {
                    DateTime.TryParse(fromDateFilter.value.ToString(), out fromDate);
                }

                var toDateFilter = GetWhereFilter(dm.Where, "toDate");
                if (toDateFilter != null)
                {
                    DateTime.TryParse(toDateFilter.value.ToString(), out toDate);
                    toDate = new DateTime(toDate.Year, toDate.Month, toDate.Day, 23, 59, 59);
                }
            }

            var treasuryCashFlows = _treasuryCashFlowManager.Get(treasury.Id, currencyId, fromDate, toDate);
            IEnumerable<TreasuryCashFlowDto> data = ObjectMapper.Map<List<TreasuryCashFlowDto>>(treasuryCashFlows);

            var operations = new DataOperations();

            IEnumerable groupDs = new List<TreasuryCashFlowDto>();
            if (dm.Group != null)
            {
                groupDs = operations.PerformSelect(data, dm.Group);
            }

            var count = data.Count();

            if (dm.Skip != 0)
            {
                data = operations.PerformSkip(data, dm.Skip);
            }

            if (dm.Take != 0)
            {
                data = operations.PerformTake(data, dm.Take);
            }

            return new ReadGrudDto() { result = data, count = 0, groupDs = groupDs };

        }

        private WhereFilter GetWhereFilter(List<WhereFilter> filterOptions, string name)
        {
            var filter = filterOptions.FirstOrDefault(x => x.Field == name);
            if (filter != null)
                return filter;

            foreach (var option in filterOptions)
            {
                return GetWhereFilter(option.predicates, name);
            }

            return null;
        }
    }
}

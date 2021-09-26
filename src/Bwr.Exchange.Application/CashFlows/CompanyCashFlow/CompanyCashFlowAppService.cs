using Bwr.Exchange.CashFlows.CompanyCashFlows.Dto;
using Bwr.Exchange.CashFlows.CompanyCashFlows.Services;
using Bwr.Exchange.Shared.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Bwr.Exchange.CashFlows.CompanyCashFlows
{
    public class CompanyCashFlowAppService : ExchangeAppServiceBase, ICompanyCashFlowAppService
    {
        private readonly ICompanyCashFlowManager _companyCashFlowManager;

        public CompanyCashFlowAppService(ICompanyCashFlowManager companyCashFlowManager)
        {
            _companyCashFlowManager = companyCashFlowManager;
        }

        public IList<CompanyCashFlowDto> Get(GetCompanyCashFlowInput input)
        {
            var companyCashFlows = _companyCashFlowManager.Get(input.CompanyId);
            var companyCashFlowsDto = ObjectMapper.Map<List<CompanyCashFlowDto>>(companyCashFlows);
            return companyCashFlowsDto;
        }

        [HttpPost]
        public ReadGrudDto GetForGrid([FromBody] DataManagerRequest dm)
        {
            int companyId = 0, currencyId = 0;
            DateTime fromDate = new DateTime(), toDate = new DateTime();
            if (dm.Where != null)
            {
                GetWhereFilter(dm.Where, "companyId");
                var companyFilter = GetWhereFilter(dm.Where, "companyId");
                if (companyFilter != null)
                {
                    int.TryParse(companyFilter.value.ToString(), out companyId);
                }

                var currencyFilter = GetWhereFilter(dm.Where, "currencyId");
                if (currencyFilter != null)
                {
                    int.TryParse(currencyFilter.value.ToString(), out currencyId);
                }

                var fromDateFilter = GetWhereFilter(dm.Where, "fromDate");
                if (fromDateFilter != null)
                {
                    DateTime.TryParse(fromDateFilter.value.ToString(), out fromDate);
                    fromDate = new DateTime(fromDate.Year, fromDate.Month, fromDate.Day, 12, 0, 0);
                }

                var toDateFilter = GetWhereFilter(dm.Where, "toDate");
                if (toDateFilter != null)
                {
                    DateTime.TryParse(toDateFilter.value.ToString(), out toDate);
                    toDate = new DateTime(toDate.Year, toDate.Month, toDate.Day, 23, 59, 59);
                }

            }

            var companyCashFlowsDto = new List<CompanyCashFlowDto>();
            if (companyId != 0 && currencyId != 0)
            {
                //Add Previous Balance
                var previousBalance = _companyCashFlowManager.GetPreviousBalance(companyId, currencyId, fromDate);
                companyCashFlowsDto.Add(new CompanyCashFlowDto
                {
                    CompanyId = companyId,
                    CurrencyId = currencyId,
                    CurrentBalance = previousBalance,
                    Type = TransactionConst.PreviousBalance
                });

                //Get Company Cash Flows
                var companyCashFlows = _companyCashFlowManager.Get(companyId, currencyId, fromDate, toDate);
                companyCashFlowsDto.AddRange(ObjectMapper.Map<List<CompanyCashFlowDto>>(companyCashFlows));
            }


            IEnumerable<CompanyCashFlowDto> data = companyCashFlowsDto;

            var operations = new DataOperations();

            IEnumerable groupDs = new List<CompanyCashFlowDto>();
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

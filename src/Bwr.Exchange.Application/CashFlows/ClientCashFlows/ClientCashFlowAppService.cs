using Bwr.Exchange.CashFlows.ClientCashFlows.Dto;
using Bwr.Exchange.CashFlows.ClientCashFlows.Services;
using Bwr.Exchange.Settings.Clients.Dto;
using Bwr.Exchange.Shared.Dto;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Bwr.Exchange.CashFlows.ClientCashFlows
{
    public class ClientCashFlowAppService : ExchangeAppServiceBase, IClientCashFlowAppService
    {
        private readonly IClientCashFlowManager _clientCashFlowManager;

        public ClientCashFlowAppService(IClientCashFlowManager clientCashFlowManager)
        {
            _clientCashFlowManager = clientCashFlowManager;
        }

        public IList<ClientCashFlowDto> Get(GetClientCashFlowInput input)
        {
            var clientCashFlows = _clientCashFlowManager.Get(input.ClientId);
            var clientCashFlowsDto = ObjectMapper.Map<List<ClientCashFlowDto>>(clientCashFlows);
            return clientCashFlowsDto;
        }

        [HttpPost]
        public ReadGrudDto GetForGrid([FromBody] DataManagerRequest dm)
        {
            int clientId = 0, currencyId = 0;
            DateTime fromDate = new DateTime(), toDate = new DateTime();
            if(dm.Where != null)
            {
                GetWhereFilter(dm.Where, "clientId");
                var clientFilter = GetWhereFilter(dm.Where, "clientId");
                if (clientFilter != null)
                {
                    int.TryParse(clientFilter.value.ToString(), out clientId);
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
                }

                var toDateFilter = GetWhereFilter(dm.Where, "toDate");
                if (toDateFilter != null)
                {
                    DateTime.TryParse(toDateFilter.value.ToString(), out toDate);
                    toDate = new DateTime(toDate.Year, toDate.Month, toDate.Day, 23, 59, 59);
                }

            }

            var clientCashFlowsDto = new List<ClientCashFlowDto>();
            if(clientId != 0 && currencyId != 0)
            {
                //Add Previous Balance
                var previousBalance = _clientCashFlowManager.GetPreviousBalance(clientId, currencyId, fromDate);
                clientCashFlowsDto.Add(new ClientCashFlowDto
                {
                    ClientId = clientId,
                    CurrencyId = currencyId,
                    CurrentBalance = previousBalance,
                    Type = TransactionConst.PreviousBalance
                });

                //Get Client Cash Flows
                var clientCashFlows = _clientCashFlowManager.Get(clientId, currencyId, fromDate, toDate);
                clientCashFlowsDto.AddRange(ObjectMapper.Map<List<ClientCashFlowDto>>(clientCashFlows));
            }
            

            IEnumerable<ClientCashFlowDto> data = clientCashFlowsDto;
            var operations = new DataOperations();

            IEnumerable groupDs = new List<ClientCashFlowDto>();
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
            
            return new ReadGrudDto() { result = data, count = count, groupDs = groupDs };
        }

        private WhereFilter GetWhereFilter(List<WhereFilter> filterOptions, string name)
        {
            var filter = filterOptions.FirstOrDefault(x => x.Field == name);
            if (filter != null)
                return filter;

            foreach(var option in filterOptions)
            {
                return GetWhereFilter(option.predicates, name);
            }

            return null;
        }
    }
}

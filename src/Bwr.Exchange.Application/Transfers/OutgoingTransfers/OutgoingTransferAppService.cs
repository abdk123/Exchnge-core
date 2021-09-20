using Bwr.Exchange.Customers;
using Bwr.Exchange.Customers.Dto;
using Bwr.Exchange.Customers.Services;
using Bwr.Exchange.Settings.Treasuries.Services;
using Bwr.Exchange.Shared.Dto;
using Bwr.Exchange.Transfers.OutgoingTransfers.Dto;
using Bwr.Exchange.Transfers.OutgoingTransfers.Services;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.EJ2.Base;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bwr.Exchange.Reflection.Extensions;

namespace Bwr.Exchange.Transfers.OutgoingTransfers
{
    public class OutgoingTransferAppService : ExchangeAppServiceBase, IOutgoingTransferAppService
    {
        private readonly IOutgoingTransferManager _outgoingTransferManager;
        private readonly ICustomerManager _customerManager;
        private readonly ITreasuryManager _treasuryManager;
        public OutgoingTransferAppService(
            OutgoingTransferManager outgoingTransferManager, 
            ICustomerManager customerManager,
            ITreasuryManager treasuryManager
            )
        {
            _outgoingTransferManager = outgoingTransferManager;
            _customerManager = customerManager;
            _treasuryManager = treasuryManager;
        }

        public async Task<OutgoingTransferDto> CreateAsync(OutgoingTransferDto input)
        {
            var treasury = await _treasuryManager.GetTreasuryAsync();
            var outgoingTransfer = ObjectMapper.Map<OutgoingTransfer>(input);

            var sender = await CreateOrUpdateCustomer(input.Sender);
            var beneficiary = await CreateOrUpdateCustomer(input.Beneficiary);

            outgoingTransfer.SenderId = sender?.Id;
            outgoingTransfer.BeneficiaryId = beneficiary?.Id;

            outgoingTransfer.TreasuryId = treasury.Id;

            var createdOutgoingTransfer = await _outgoingTransferManager.CreateAsync(outgoingTransfer);
            return ObjectMapper.Map<OutgoingTransferDto>(createdOutgoingTransfer);
        }

        public async Task<IList<OutgoingTransferDto>> Get(SearchOutgoingTransferInputDto input)
        {
            var dic = input.ToDictionary();
            var outgoingTransfers = await _outgoingTransferManager.GetAsync(dic);
            return ObjectMapper.Map<List<OutgoingTransferDto>>(outgoingTransfers);
        }

        public OutgoingTransferDto GetById(int id)
        {
            var outgoingTransfer = _outgoingTransferManager.GetById(id);
            return ObjectMapper.Map<OutgoingTransferDto>(outgoingTransfer);
        }

        public ReadGrudDto GetForGrid([FromBody] DataManagerRequest dm)
        {
            throw new NotImplementedException();
        }

        private async Task<Customer> CreateOrUpdateCustomer(CustomerDto customerDto)
        {
            var customer = ObjectMapper.Map<Customer>(customerDto);
            return await _customerManager.CreateOrUpdateAsync(customer);
        }

    }
}

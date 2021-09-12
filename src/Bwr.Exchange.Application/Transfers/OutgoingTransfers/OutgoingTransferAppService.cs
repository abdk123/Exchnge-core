using Bwr.Exchange.Customers;
using Bwr.Exchange.Customers.Dto;
using Bwr.Exchange.Customers.Services;
using Bwr.Exchange.Settings.Treasuries.Services;
using Bwr.Exchange.Transfers.OutgoingTransfers.Dto;
using Bwr.Exchange.Transfers.OutgoingTransfers.Services;
using System;
using System.Threading.Tasks;

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

        private async Task<Customer> CreateOrUpdateCustomer(CustomerDto customerDto)
        {
            var customer = ObjectMapper.Map<Customer>(customerDto);
            return await _customerManager.CreateOrUpdateAsync(customer);
        }
    }
}

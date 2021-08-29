using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Events.Bus;
using Bwr.Exchange.CashFlows;
using Bwr.Exchange.CashFlows.ClientCashFlows.Events;
using Bwr.Exchange.Transfers.OutgoingTransfers.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bwr.Exchange.Transfers.OutgoingTransfers.Services
{
    public class OutgoingTransferManager : IOutgoingTransferManager
    {
        private readonly IRepository<OutgoingTransfer> _outgoingTransferRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        private readonly IOutgoingTransferFactory _outgoingTransferFactory;
        public IEventBus EventBus { get; set; }

        public OutgoingTransferManager(
            IRepository<OutgoingTransfer> outgoingTransferRepository,
            IUnitOfWorkManager unitOfWorkManager,
            IOutgoingTransferFactory outgoingTransferFactory
            )
        {
            _outgoingTransferRepository = outgoingTransferRepository;
            _unitOfWorkManager = unitOfWorkManager;
            _outgoingTransferFactory = outgoingTransferFactory;
            EventBus = NullEventBus.Instance;
        }

        public async Task<OutgoingTransfer> Create(OutgoingTransfer input)
        {
            //Date and time
            var currentDate = DateTime.Now;
            input.Date = new DateTime(
                input.Date.Year,
                input.Date.Month,
                input.Date.Day,
                currentDate.Hour,
                currentDate.Minute,
                currentDate.Second
                );

            IOutgoingTransferDomainService service = _outgoingTransferFactory.CreateService(input);
            return await service.CreateAsync();

            int outgoingTransferId = 0;
            using (var unitOfWork = _unitOfWorkManager.Begin())
            {
                outgoingTransferId = await _outgoingTransferRepository.InsertAndGetIdAsync(input);
                EventBus.Trigger(new ClientCashFlowCreatedEventData
                {
                    Amount = input.Amount,
                    Commission = input.Commission,
                    ClientCommission = input.ClientCommission,
                    Date = input.Date,
                    TransactionId = outgoingTransferId,
                    TransactionType = TransactionType.OutgoingTransfer
                });
            }

            return await GetByIdAsync(outgoingTransferId);
        }

        public async Task<OutgoingTransfer> GetByIdAsync(int id)
        {
            return await _outgoingTransferRepository.FirstOrDefaultAsync(id);
        }
    }
}

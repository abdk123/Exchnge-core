using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Events.Bus;
using Bwr.Exchange.CashFlows;
using Bwr.Exchange.CashFlows.ClientCashFlows.Events;
using Bwr.Exchange.Transfers.OutgoingTransfers.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<OutgoingTransfer> CreateAsync(OutgoingTransfer input)
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
        }

        public async Task<OutgoingTransfer> GetByIdAsync(int id)
        {
            return await _outgoingTransferRepository.FirstOrDefaultAsync(id);
        }

        public OutgoingTransfer GetById(int id)
        {
            return _outgoingTransferRepository.GetAllIncluding(
                b => b.Beneficiary,
                s => s.Sender
                ).FirstOrDefault();
        }
    }
}

using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Events.Bus;
using Bwr.Exchange.CashFlows.CompanyCashFlows.Events;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Bwr.Exchange.Transfers.OutgoingTransfers.Services.Implements
{
    public class OutgoingTransferFromCompanyDomainService : IOutgoingTransferDomainService
    {
        private readonly IRepository<OutgoingTransfer> _outgoingTransferRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;
        public OutgoingTransfer OutgoingTransfer { get; set; }

        public OutgoingTransferFromCompanyDomainService(
            IRepository<OutgoingTransfer> outgoingTransferRepository,
            IUnitOfWorkManager unitOfWorkManager,
            OutgoingTransfer outgoingTransfer
            )
        {
            _outgoingTransferRepository = outgoingTransferRepository;
            _unitOfWorkManager = unitOfWorkManager;
            OutgoingTransfer = outgoingTransfer;
        }

        public async Task<OutgoingTransfer> CreateAsync()
        {
            int outgoingTransferId;
            using (var unitOfWork = _unitOfWorkManager.Begin())
            {
                
                outgoingTransferId = await _outgoingTransferRepository.InsertAndGetIdAsync(OutgoingTransfer);

                OutgoingTransfer = GetByIdWithDetail(outgoingTransferId);

                EventBus.Default.Trigger(
                    new CompanyCashFlowCreatedEventData() {
                        Date = OutgoingTransfer.Date,
                        CurrencyId = OutgoingTransfer.CurrencyId,
                        CompanyId = OutgoingTransfer.ToCompanyId,
                        TransactionId = outgoingTransferId,
                        TransactionType=CashFlows.TransactionType.OutgoingTransfer,
                        Amount = (OutgoingTransfer.Amount * -1),
                        Type = TransactionConst.TransferToHim,
                        Commission = 0.0,
                        InstrumentNo = OutgoingTransfer.InstrumentNo,
                        CompanyCommission=(OutgoingTransfer.CompanyCommission * -1),
                        Note = OutgoingTransfer.Sender.Name,
                        Beneficiary = OutgoingTransfer.Beneficiary.Name,
                        Sender = OutgoingTransfer.Sender.Name,
                        Destination = OutgoingTransfer.Country.Name
                    });

                EventBus.Default.Trigger(
                    new CompanyCashFlowCreatedEventData()
                    {
                        Date = OutgoingTransfer.Date,
                        CurrencyId = OutgoingTransfer.CurrencyId,
                        CompanyId = OutgoingTransfer.FromCompanyId,
                        TransactionId = outgoingTransferId,
                        TransactionType = CashFlows.TransactionType.OutgoingTransfer,
                        Amount = (OutgoingTransfer.Amount),
                        Type = TransactionConst.TransferFromHim,
                        Commission = OutgoingTransfer.Commission,
                        InstrumentNo = OutgoingTransfer.InstrumentNo,
                        CompanyCommission = 0.0,
                        Note = OutgoingTransfer.Sender.Name,
                        Beneficiary = OutgoingTransfer.Beneficiary.Name,
                        Sender = OutgoingTransfer.Sender.Name,
                        Destination = OutgoingTransfer.Country.Name
                    });

                unitOfWork.Complete();
            }
            return OutgoingTransfer;
        }

        private OutgoingTransfer GetByIdWithDetail(int id)
        {
            return _outgoingTransferRepository.
                GetAllIncluding(
                    m => m.ToCompany,
                    e => e.FromCompany,
                    s => s.Sender,
                    b => b.Beneficiary,
                    ds => ds.Country)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}

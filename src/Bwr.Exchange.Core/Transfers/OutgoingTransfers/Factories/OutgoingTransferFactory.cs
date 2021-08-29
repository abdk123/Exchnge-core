using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Bwr.Exchange.Transfers.OutgoingTransfers.Services;
using Bwr.Exchange.Transfers.OutgoingTransfers.Services.Implements;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bwr.Exchange.Transfers.OutgoingTransfers.Factories
{
    public class OutgoingTransferFactory : IOutgoingTransferFactory
    {
        private readonly IRepository<OutgoingTransfer> _outgoingTransferRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public OutgoingTransferFactory(
            IRepository<OutgoingTransfer> outgoingTransferRepository,
            IUnitOfWorkManager unitOfWorkManager
            )
        {

            _outgoingTransferRepository = outgoingTransferRepository;
            _unitOfWorkManager = unitOfWorkManager;
        }
        public IOutgoingTransferDomainService CreateService(OutgoingTransfer input)
        {
            switch (input.PaymentType)
            {
                case PaymentType.Cash:
                    return new OutgoingTransferFromCashDomainService(_outgoingTransferRepository, _unitOfWorkManager, input);
                case PaymentType.Client:
                    return new OutgoingTransferFromClientDomainService(_outgoingTransferRepository, _unitOfWorkManager, input);
                case PaymentType.Company:
                    return new OutgoingTransferFromCompanyDomainService(_outgoingTransferRepository, _unitOfWorkManager, input);
                default:
                    return null;
            }

        }
    }
}

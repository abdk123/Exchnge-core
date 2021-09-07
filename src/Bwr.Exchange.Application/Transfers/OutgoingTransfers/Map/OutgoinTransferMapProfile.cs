using AutoMapper;
using Bwr.Exchange.Transfers.OutgoingTransfers.Dto;

namespace Bwr.Exchange.Transfers.OutgoingTransfers.Map
{
    public class OutgoinTransferMapProfile : Profile
    {
        public OutgoinTransferMapProfile()
        {
            CreateMap<OutgoingTransfer, OutgoingTransferDto>()
            .ForMember(x => x.Sender, m => m.Ignore())
            .ForMember(x => x.Beneficiary, m => m.Ignore());

            CreateMap<OutgoingTransferDto, OutgoingTransfer>();
        }
    }
}

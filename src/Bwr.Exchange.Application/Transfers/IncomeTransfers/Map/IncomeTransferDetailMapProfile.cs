using AutoMapper;
using Bwr.Exchange.Transfers.IncomeTransfers.Dto;

namespace Bwr.Exchange.Transfers.IncomeTransfers.Map
{
    public class IncomeTransferDetailMapProfile : Profile
    {
        public IncomeTransferDetailMapProfile()
        {
            CreateMap<IncomeTransferDetail, IncomeTransferDetailDto>();
            CreateMap<IncomeTransferDetailDto, IncomeTransferDetail>();
        }
    }
}

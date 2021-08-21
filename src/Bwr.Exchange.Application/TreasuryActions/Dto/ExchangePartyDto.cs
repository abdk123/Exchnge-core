using Abp.Application.Services.Dto;

namespace Bwr.Exchange.TreasuryActions.Dto
{
    public class ExchangePartyDto : EntityDto
    {
        public string Name { get; set; }
        public string Group { get; set; }
    }
}

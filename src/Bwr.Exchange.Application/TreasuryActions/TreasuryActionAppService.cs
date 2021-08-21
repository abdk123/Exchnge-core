using Bwr.Exchange.Settings.Clients.Services;
using Bwr.Exchange.Settings.Companies.Services;
using Bwr.Exchange.Settings.Treasuries.Services;
using Bwr.Exchange.TreasuryActions.Dto;
using Bwr.Exchange.TreasuryActions.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bwr.Exchange.TreasuryActions
{
    public class TreasuryActionAppService : ExchangeAppServiceBase, ITreasuryActionAppService
    {
        private readonly ITreasuryActionManager _treasuryActionManager;
        private readonly ITreasuryManager _treasuryManager;
        private readonly IClientManager _clientManager;
        private readonly ICompanyManager _companyManager;

        public TreasuryActionAppService(
            ITreasuryActionManager treasuryActionManager,
            ITreasuryManager treasuryManager,
            IClientManager clientManager,
            ICompanyManager companyManager
            )
        {
            _treasuryActionManager = treasuryActionManager;
            _treasuryManager = treasuryManager;
            _clientManager = clientManager;
            _companyManager = companyManager;
        }

        public async Task<TreasuryActionDto> CreateAsync(TreasuryActionDto input)
        {
            var treasuryAction = ObjectMapper.Map<TreasuryAction>(input);
            var createdTreasuryAction = await _treasuryActionManager.CreateAsync(treasuryAction);
            return ObjectMapper.Map<TreasuryActionDto>(createdTreasuryAction);
        }
        public async Task<IList<ExchangePartyDto>> GetExchangeParties()
        {
            var exchangePartiesDto = new List<ExchangePartyDto>();
            var clients = await _clientManager.GetAllAsync();
            var treasury = await _treasuryManager.GetTreasuryAsync();
            var companies = await _companyManager.GetAllAsync();

            exchangePartiesDto.Add(new ExchangePartyDto
            {
                Id = treasury.Id,
                Name = treasury.Name,
                Group = "Treasury"
            });

            exchangePartiesDto.AddRange((from e in clients
                                         select new ExchangePartyDto
                                         {
                                             Id = e.Id,
                                             Name = e.Name,
                                             Group = "Client"
                                         }).ToList());

            exchangePartiesDto.AddRange((from e in companies
                                         select new ExchangePartyDto
                                         {
                                             Id = e.Id,
                                             Name = e.Name,
                                             Group = "Company"
                                         }).ToList());
            return exchangePartiesDto;
        }
    }
}

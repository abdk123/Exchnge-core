using Abp.Domain.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace Bwr.Exchange.Settings.Treasuries.Services
{
    public class TreasuryManager : ITreasuryManager
    {
        private readonly IRepository<Treasury> _treasuryRepository;
        public TreasuryManager(IRepository<Treasury> treasuryRepository)
        {
            _treasuryRepository = treasuryRepository;
        }

        public async Task<Treasury> GetTreasuryAsync()
        {
            var treasuries = await _treasuryRepository.GetAllListAsync();
            return treasuries != null ? treasuries.FirstOrDefault() : null;
        }
    }
}

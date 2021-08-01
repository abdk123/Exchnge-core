using Abp.Domain.Repositories;
using System.Threading.Tasks;

namespace Bwr.Exchange.CashFlows.CompanyCashFlows.Services
{
    public class CompanyCashFlowManager : ICompanyCashFlowManager
    {
        private readonly IRepository<CompanyCashFlow> _companyCashFlowRepository;

        public CompanyCashFlowManager(IRepository<CompanyCashFlow> companyCashFlowRepository)
        {
            _companyCashFlowRepository = companyCashFlowRepository;
        }

        public async Task Create(CompanyCashFlow input)
        {
            await _companyCashFlowRepository.InsertAsync(input);
        }
    }
}

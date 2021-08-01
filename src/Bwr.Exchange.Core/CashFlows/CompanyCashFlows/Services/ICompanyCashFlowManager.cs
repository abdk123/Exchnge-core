using Abp.Domain.Services;
using System.Threading.Tasks;

namespace Bwr.Exchange.CashFlows.CompanyCashFlows.Services
{
    public interface ICompanyCashFlowManager : IDomainService
    {
        Task Create(CompanyCashFlow input);
    }
}

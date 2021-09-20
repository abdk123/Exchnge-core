using Abp.Application.Services;
using Bwr.Exchange.Settings.Companies.Dto;
using Bwr.Exchange.Settings.Companies.Dto.CompanyBalance;
using Bwr.Exchange.Settings.Companies.Dto.CompanyBalances;
using Bwr.Exchange.Shared.Interfaces;
using System.Threading.Tasks;

namespace Bwr.Exchange.Settings.Companies
{
    public interface ICompanyAppService : IApplicationService, ICrudEjAppService<CompanyDto, CreateCompanyDto, UpdateCompanyDto>
    {
        Task<CompanyBalanceDto> GetCurrentBalance(CompanyBalanceInputDto input);
        Task<CompanyBalanceDto> GetBalanceForEdit(CompanyBalanceForEditInputDto input);
    }
}

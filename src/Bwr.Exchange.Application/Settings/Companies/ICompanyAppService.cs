using Abp.Application.Services;
using Bwr.Exchange.Settings.Companies.Dto;
using Bwr.Exchange.Shared.Interfaces;

namespace Bwr.Exchange.Settings.Companies
{
    public interface ICompanyAppService : IApplicationService, ICrudEjAppService<CompanyDto, CreateCompanyDto, UpdateCompanyDto>
    {

    }
}

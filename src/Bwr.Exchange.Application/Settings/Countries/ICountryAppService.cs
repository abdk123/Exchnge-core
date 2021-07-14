
using Abp.Application.Services;
using Bwr.Exchange.Settings.Countries.Dto;
using Bwr.Exchange.Shared.Interfaces;

namespace Bwr.Exchange.Settings.Countries
{
    public interface ICountryAppService : IApplicationService, ICrudEjAppService<CountryDto, CreateCountryDto, UpdateCountryDto>
    {

    }
}

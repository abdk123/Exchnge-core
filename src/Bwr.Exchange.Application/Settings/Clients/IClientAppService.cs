using Abp.Application.Services;
using Bwr.Exchange.Settings.Clients.Dto;
using Bwr.Exchange.Shared.Interfaces;

namespace Bwr.Exchange.Settings.Clients
{
    public interface IClientAppService : IApplicationService, ICrudEjAppService<ClientDto, CreateClientDto, UpdateClientDto>
    {

    }
}

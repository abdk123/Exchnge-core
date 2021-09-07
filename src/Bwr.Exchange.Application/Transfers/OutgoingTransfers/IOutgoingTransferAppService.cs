using Abp.Application.Services;
using Bwr.Exchange.Transfers.OutgoingTransfers.Dto;
using System.Threading.Tasks;

namespace Bwr.Exchange.Transfers.OutgoingTransfers
{
    public interface IOutgoingTransferAppService : IApplicationService
    {
        Task<OutgoingTransferDto> CreateAsync(OutgoingTransferDto input);
    }
}

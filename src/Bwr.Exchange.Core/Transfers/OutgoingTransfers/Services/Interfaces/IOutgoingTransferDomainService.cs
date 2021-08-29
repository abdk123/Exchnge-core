using Abp.Domain.Services;
using System.Threading.Tasks;

namespace Bwr.Exchange.Transfers.OutgoingTransfers.Services
{
    public interface IOutgoingTransferDomainService : IDomainService
    {
        Task<OutgoingTransfer> CreateAsync();
    }
}

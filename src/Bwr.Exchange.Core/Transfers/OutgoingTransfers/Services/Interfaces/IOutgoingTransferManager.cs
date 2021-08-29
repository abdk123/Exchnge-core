using Abp.Domain.Services;
using System.Threading.Tasks;

namespace Bwr.Exchange.Transfers.OutgoingTransfers.Services
{
    public interface IOutgoingTransferManager : IDomainService
    {
        Task<OutgoingTransfer> Create(OutgoingTransfer input);
        Task<OutgoingTransfer> GetByIdAsync(int id);
    }
}

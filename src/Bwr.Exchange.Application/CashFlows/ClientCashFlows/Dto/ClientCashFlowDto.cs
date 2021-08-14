using Bwr.Exchange.CashFlows.Shared.Dto;
using Bwr.Exchange.Settings.Clients.Dto;
using Bwr.Exchange.Settings.Currencies.Dto;

namespace Bwr.Exchange.CashFlows.ClientCashFlows.Dto
{
    public class ClientCashFlowDto : CashFlowDto
    {

        #region Client 
        public int ClientId { get; set; }
        public ClientDto Client { get; set; }
        #endregion
    }
}

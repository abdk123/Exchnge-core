using System;

namespace Bwr.Exchange.CashFlows.ClientCashFlows.Dto
{
    public class GetClientCashFlowInput
    {
        public int ClientId { get; set; }
        public int CurrencyId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}

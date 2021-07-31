using Bwr.Exchange.Shared;

namespace Bwr.Exchange.CashFlows.ClientCashFlows
{
    public class ClientCashFlow : CashFlowBase
    {
        public double Commission { get; set; }
        public double ClientCommission { get; set; }
    }
}

using Bwr.Exchange.Shared;
using System;

namespace Bwr.Exchange.CashFlows.ClientCashFlows
{
    public class ClientCashFlow : CashFlowBase
    {
        public ClientCashFlow(
            DateTime date,
            double amount,
            int transactionId,
            TransactionType type,
            double commission,
            double clientCommission
            )
        {
            Date = date;
            Amount = amount;
            Transaction = new Transaction(transactionId, type);
            Commission = commission;
            ClientCommission = clientCommission;
        }
        public double Commission { get; set; }
        public double ClientCommission { get; set; }
    }
}

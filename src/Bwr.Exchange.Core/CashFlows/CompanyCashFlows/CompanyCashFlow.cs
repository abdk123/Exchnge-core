using Bwr.Exchange.Shared;
using System;

namespace Bwr.Exchange.CashFlows.CompanyCashFlows
{
    public class CompanyCashFlow : CashFlowBase
    {
        public CompanyCashFlow(
            DateTime date,
            double amount,
            int transactionId,
            TransactionType type,
            double commission,
            double companyCommission
            )
        {
            Date = date;
            Amount = amount;
            Transaction = new Transaction(transactionId, type);
            Commission = commission;
            CompanyCommission = companyCommission;
        }
        public double Commission { get; set; }
        public double CompanyCommission { get; set; }
    }
}

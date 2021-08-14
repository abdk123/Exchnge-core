using Abp.Events.Bus;
using System;

namespace Bwr.Exchange.CashFlows.CompanyCashFlows.Events
{
    public class CompanyCashFlowCreatedEventData : EventData
    {
        public CompanyCashFlowCreatedEventData() { }
        public CompanyCashFlowCreatedEventData(
            DateTime date,
            int? currencyId,
            int? clientId,
            int transactionId,
            TransactionType transactionType,
            double amount,
            string type,
            double commission = 0.0,
            string instrumentNo = "",
            double clientCommission = 0.0,
            string note = ""
            )
        {
            CurrencyId = currencyId;
            CompanyId = clientId;
            Date = date;
            TransactionId = transactionId;
            TransactionType = transactionType;
            Type = type;
            Amount = amount;
            Commission = commission;
            CompanyCommission = clientCommission;
            InstrumentNo = instrumentNo;
            Note = note;
        }

        public int? CurrencyId { get; set; }
        public int? CompanyId { get; set; }
        public DateTime Date { get; set; }
        public int TransactionId { get; set; }
        public TransactionType TransactionType { get; set; }
        public string Type { get; set; }
        public string Note { get; set; }
        public double Amount { get; set; }
        public double Commission { get; set; }
        public double CompanyCommission { get; set; }
        public string InstrumentNo { get; set; }
    }
}

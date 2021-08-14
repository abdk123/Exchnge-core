using Abp.Events.Bus;
using System;

namespace Bwr.Exchange.CashFlows.ClientCashFlows.Events
{
    public class ClientCashFlowCreatedEventData : EventData
    {
        public ClientCashFlowCreatedEventData() { }
        public ClientCashFlowCreatedEventData(
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
            ClientId = clientId;
            Date = date;
            TransactionId = transactionId;
            TransactionType = transactionType;
            Type = type;
            Amount = amount;
            Commission = commission;
            ClientCommission = clientCommission;
            InstrumentNo = instrumentNo;
            Note = note;
        }

        public int? CurrencyId { get; set; }
        public int? ClientId { get; set; }
        public DateTime Date { get; set; }
        public int TransactionId { get; set; }
        public TransactionType TransactionType { get; set; }
        public string Type { get; set; }
        public string Note { get; set; }
        public double Amount { get; set; }
        public double Commission { get; set; }
        public double ClientCommission { get; set; }
        public string InstrumentNo { get; set; }
    }
}

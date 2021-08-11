using Abp.Events.Bus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bwr.Exchange.CashFlows.TreasuryCashFlows.Events
{
    public class TreasuryCashFlowCreatedEventData : EventData
    {
        public TreasuryCashFlowCreatedEventData(
            DateTime date, 
            int? currencyId, 
            int? treasuryId, 
            int transactionId, 
            TransactionType transactionType, 
            double amount, 
            string type, 
            string name,
            string note
            )
        {
            Date = date;
            CurrencyId = currencyId;
            TreasuryId = treasuryId;
            TransactionId = transactionId;
            TransactionType = transactionType;
            Amount = amount;
            Type = type;
            Name = name;
            Note = note;
        }

        public DateTime Date { get; set; }
        public int? CurrencyId { get; set; }
        public int? TreasuryId { get; set; }
        public int TransactionId { get; set; }
        public TransactionType TransactionType { get; set; }
        public double Amount { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Note { get; set; }
    }
}

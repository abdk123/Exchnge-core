using Abp.Events.Bus;
using System;

namespace Bwr.Exchange.CashFlows.CompanyCashFlows.Events
{
    public class CompanyCashFlowCreatedEventData : EventData
    {
        public DateTime Date { get; set; }
        public int TransactionId { get; set; }
        public TransactionType Type { get; set; }
        public double Amount { get; set; }
        public double Commission { get; set; }
        public double CompanyCommission { get; set; }
    }
}

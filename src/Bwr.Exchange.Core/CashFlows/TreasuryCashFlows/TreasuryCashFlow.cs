using Abp.Domain.Entities.Auditing;
using System;

namespace Bwr.Exchange.CashFlows.TreasuryCashFlows
{
    public class TreasuryCashFlow : FullAuditedEntity
    {
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public double CurrentBalance { get; set; }
        public Bwr.Exchange.CashFlows.Transaction Transaction { get; set; }
    }
}

using Abp.Domain.Entities.Auditing;
using Bwr.Exchange.Settings.Treasuries;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bwr.Exchange.CashFlows.TreasuryCashFlows
{
    public class TreasuryCashFlow : FullAuditedEntity
    {
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public double CurrentBalance { get; set; }
        public Bwr.Exchange.CashFlows.Transaction Transaction { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Note { get; set; }

        #region Treasury Balance 
        public int TreasuryBalanceId { get; set; }
        [ForeignKey("TreasuryBalanceId")]
        public virtual TreasuryBalance TreasuryBalance { get; set; }
        #endregion
        
    }
}

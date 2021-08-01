using Abp.Domain.Entities.Auditing;
using Bwr.Exchange.Authorization.Users;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bwr.Exchange.Shared
{
    public class CashFlowBase : FullAuditedEntity
    {
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public double CurrentBalance { get; set; }
        public Bwr.Exchange.CashFlows.Transaction Transaction { get; set; }
        public bool Matched { get; set; }
        public bool? Shaded { get; set; }
        public string Note { get; set; }

        #region User
        public long? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        #endregion
    }
}

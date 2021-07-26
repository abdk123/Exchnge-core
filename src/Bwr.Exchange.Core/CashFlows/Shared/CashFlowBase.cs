using Abp.Domain.Entities.Auditing;
using Bwr.Exchange.Settings.Currencies;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bwr.Exchange.CashFlows.Shared
{
    public class CashFlowBase : FullAuditedEntity
    {
        public double Amount { get; set; }
        public double CurrentBalance { get; set; }

        #region Currency
        public int CurrencyId { get; set; }
        [ForeignKey("CurrencyId")]
        public virtual Currency Currency { get; set; }
        #endregion
    }
}

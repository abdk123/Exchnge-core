using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bwr.Exchange.TreasuryActions
{
    public class TreasuryAction : FullAuditedEntity
    {
        public TreasuryActionType ActionType { get; set; }
        public DateTime Date { get; set; }
        public MainAccountType MainAccount { get; set; }

        #region MainAccount

        #endregion
    }
}

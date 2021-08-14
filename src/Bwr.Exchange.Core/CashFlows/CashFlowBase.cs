﻿using Abp.Domain.Entities.Auditing;
using Bwr.Exchange.Authorization.Users;
using Bwr.Exchange.CashFlows;
using Bwr.Exchange.Settings.Currencies;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bwr.Exchange.Shared
{
    public class CashFlowBase : FullAuditedEntity
    {
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public double CurrentBalance { get; set; }
        public int TransactionId { get; set; }
        public TransactionType TransactionType { get; set; }
        public bool Matched { get; set; }
        public bool? Shaded { get; set; }
        public string Type { get; set; }
        public string Note { get; set; }
        public string InstrumentNo { get; set; }

        #region Currency 
        public int CurrencyId { get; set; }
        [ForeignKey("CurrencyId")]
        public virtual Currency Currency { get; set; }
        #endregion

        #region User who do matching
        public long? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        #endregion
    }
}

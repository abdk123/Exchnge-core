using Abp.Domain.Entities.Auditing;
using Bwr.Exchange.Settings.Clients;
using Bwr.Exchange.Settings.Companies;
using Bwr.Exchange.Settings.Countries;
using Bwr.Exchange.Settings.Currencies;
using Bwr.Exchange.Settings.Expenses;
using Bwr.Exchange.Settings.Incomes;
using Bwr.Exchange.Settings.Treasuries;
using Bwr.Exchange.Transfers.IncomeTransfers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bwr.Exchange.TreasuryActions
{
    public class TreasuryAction : FullAuditedEntity
    {
        public TreasuryActionType ActionType { get; set; }
        public DateTime Date { get; set; }
        public MainAccountType MainAccount { get; set; }

        #region Currency 
        public int? CurrencyId { get; set; }
        [ForeignKey("CurrencyId")]
        public virtual Currency Currency { get; set; }
        #endregion

        #region To Company 
        public int? ToCompanyId { get; set; }
        [ForeignKey("ToCompanyId")]
        public virtual Company ToCompany { get; set; }
        #endregion

        #region To Client 
        public int? ToClientId { get; set; }
        [ForeignKey("ToClientId")]
        public virtual Client ToClient { get; set; }
        #endregion

        #region From Company 
        public int? FromCompanyId { get; set; }
        [ForeignKey("FromCompanyId")]
        public virtual Company FromCompany { get; set; }
        #endregion

        #region From Client 
        public int? FromClientId { get; set; }
        [ForeignKey("FromClientId")]
        public virtual Client FromClient { get; set; }
        #endregion

        #region Treasury 
        public int? TreasuryId { get; set; }
        [ForeignKey("TreasuryId")]
        public virtual Treasury Treasury { get; set; }
        #endregion

        #region Expense 
        public int? ExpenseId { get; set; }
        [ForeignKey("ExpenseId")]
        public virtual Expense Expense { get; set; }
        #endregion

        #region Income 
        public int? IncomeId { get; set; }
        [ForeignKey("IncomeId")]
        public virtual Income Income { get; set; }
        #endregion

        #region IncomeTransferDetail 
        public int? IncomeTransferDetailId { get; set; }
        [ForeignKey("IncomeTransferDetailId")]
        public virtual IncomeTransferDetail IncomeTransferDetail { get; set; }
        #endregion

        public double Amount { get; set; }
        public string Note { get; set; }
        public string InstrumentNo { get; set; }
        public string IdentificationNumber { get; set; }
        public string Issuer { get; set; }

    }
}

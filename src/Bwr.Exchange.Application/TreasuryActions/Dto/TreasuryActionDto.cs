using Abp.Application.Services.Dto;
using Bwr.Exchange.Settings.Clients.Dto;
using Bwr.Exchange.Settings.Companies.Dto;
using Bwr.Exchange.Settings.Currencies.Dto;
using Bwr.Exchange.Settings.Expenses.Dto;
using Bwr.Exchange.Settings.Incomes.Dto;
using Bwr.Exchange.Transfers.IncomeTransfers.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bwr.Exchange.TreasuryActions.Dto
{
    public class TreasuryActionDto : EntityDto
    {
        public TreasuryActionType ActionType { get; set; }
        public DateTime Date { get; set; }
        public MainAccountType MainAccount { get; set; }

        #region Currency 
        public int? CurrencyId { get; set; }
        public CurrencyDto Currency { get; set; }
        #endregion

        #region To Company 
        public int? ToCompanyId { get; set; }
        public CompanyDto ToCompany { get; set; }
        #endregion

        #region To Client 
        public int? ToClientId { get; set; }
        public ClientDto ToClient { get; set; }
        #endregion

        #region From Company 
        public int? FromCompanyId { get; set; }
        public CompanyDto FromCompany { get; set; }
        #endregion

        #region From Client 
        public int? FromClientId { get; set; }
        public ClientDto FromClient { get; set; }
        #endregion

        #region Expense 
        public int? ExpenseId { get; set; }
        public ExpenseDto Expense { get; set; }
        #endregion

        #region Income 
        public int? IncomeId { get; set; }
        public IncomeDto Income { get; set; }
        #endregion

        #region IncomeTransferDetail 
        public int? IncomeTransferDetailId { get; set; }
        public IncomeTransferDetailDto IncomeTransferDetail { get; set; }
        #endregion

        public double Amount { get; set; }
        public string Note { get; set; }
        public string InstrumentNo { get; set; }
        public string IdentificationNumber { get; set; }
        public string Issuer { get; set; }
    }
}

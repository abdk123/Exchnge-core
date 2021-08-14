using Abp.Application.Services.Dto;
using Bwr.Exchange.Settings.Clients.Dto;
using Bwr.Exchange.Settings.Companies.Dto;
using Bwr.Exchange.Settings.Currencies.Dto;
using Bwr.Exchange.Settings.Expenses.Dto;
using Bwr.Exchange.Settings.Incomes.Dto;
using Bwr.Exchange.Settings.Treasury.Dto;
using Bwr.Exchange.Transfers.IncomeTransfers.Dto;
using System;

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

        #region Exchange Party Company 
        public int? ExchangePartyCompanyId { get; set; }
        public CompanyDto ExchangePartyCompany { get; set; }
        #endregion

        #region Exchange Party Client 
        public int? ExchangePartyClientId { get; set; }
        public ClientDto ExchangePartyClient { get; set; }
        #endregion

        #region Main Account Company 
        public int? MainAccountCompanyId { get; set; }
        public CompanyDto MainAccountCompany { get; set; }
        #endregion

        #region Main Account Client 
        public int? MainAccountClientId { get; set; }
        public ClientDto MainAccountClient { get; set; }
        #endregion

        #region Expense 
        public int? ExpenseId { get; set; }
        public ExpenseDto Expense { get; set; }
        #endregion

        #region Income 
        public int? IncomeId { get; set; }
        public IncomeDto Income { get; set; }
        #endregion

        #region Treasury 
        public int? TreasuryId { get; set; }
        public TreasuryDto Treasury { get; set; }
        #endregion

        #region Income Transfer Detail 
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

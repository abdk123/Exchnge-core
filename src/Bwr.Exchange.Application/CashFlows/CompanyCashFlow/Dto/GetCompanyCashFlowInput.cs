using System;

namespace Bwr.Exchange.CashFlows.CompanyCashFlows.Dto
{
    public class GetCompanyCashFlowInput
    {
        public int CompanyId { get; set; }
        public int CurrencyId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}

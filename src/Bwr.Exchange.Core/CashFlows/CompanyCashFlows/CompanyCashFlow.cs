using Bwr.Exchange.Shared;
using System;

namespace Bwr.Exchange.CashFlows.CompanyCashFlows
{
    public class CompanyCashFlow : CashFlowBase
    {
        public double Commission { get; set; }
        public double CompanyCommission { get; set; }
    }
}

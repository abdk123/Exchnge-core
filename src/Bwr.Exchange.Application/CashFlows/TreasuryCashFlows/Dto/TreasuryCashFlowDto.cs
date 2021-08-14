using Bwr.Exchange.CashFlows.Shared.Dto;
using Bwr.Exchange.Settings.Currencies.Dto;

namespace Bwr.Exchange.CashFlows.TreasuryCashFlows.Dto
{
    public class TreasuryCashFlowDto : CashFlowDto
    {
        public string Name { get; set; }

        #region Currency 
        public int CurrencyId { get; set; }
        public virtual CurrencyDto Currency { get; set; }
        #endregion
    }
}

﻿using Abp.Application.Services.Dto;
using Bwr.Exchange.Settings.Currencies.Dto;
using System;

namespace Bwr.Exchange.CashFlows.Shared.Dto
{
    public class CashFlowDto : EntityDto
    {
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public double CurrentBalance { get; set; }
        public int TransactionId { get; set; }
        public int TransactionType { get; set; }
        public bool Matched { get; set; }
        public bool? Shaded { get; set; }
        public string Type { get; set; }
        public string Note { get; set; }
        public string InstrumentNo { get; set; }

        #region Currency 
        public int CurrencyId { get; set; }
        public CurrencyDto Currency { get; set; }
        #endregion

        
    }
}

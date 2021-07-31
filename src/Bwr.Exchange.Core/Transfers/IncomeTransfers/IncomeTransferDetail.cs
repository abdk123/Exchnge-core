using Abp.Domain.Entities.Auditing;
using Bwr.Exchange.Customers;
using Bwr.Exchange.Settings.Clients;
using Bwr.Exchange.Settings.Companies;
using Bwr.Exchange.Settings.Currencies;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bwr.Exchange.Transfers.IncomeTransfers
{
    public class IncomeTransferDetail : Transfer
    {
        #region Receiver

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

        #endregion

        #region Income Transfer
        public int IncomeTransferId { get; set; }
        [ForeignKey("IncomeTransferId")]
        public virtual IncomeTransfer IncomeTransfer { get; set; }
        #endregion
    }
}

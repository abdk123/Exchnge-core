using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bwr.Exchange.Settings.Currencies
{
    public class Currency : FullAuditedEntity
    {
        public Currency(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }
    }
}

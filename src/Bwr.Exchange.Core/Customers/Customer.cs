using Abp.Domain.Entities.Auditing;

namespace Bwr.Exchange.Customers
{
    public class Customer : FullAuditedEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
